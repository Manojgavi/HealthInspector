using HealthInspector.IControllerServices;
using HealthInspector.IRepository;
using HealthInspector.Models;
using HealthInspector.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Controllers
{
    [Authorize(Roles ="Doctor")]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IDoctorServices doctorServices;
        private readonly IAppointmentRepository appointmentRepository;

        public DoctorController(IDoctorRepository doctorRepository,IDoctorServices doctorServices,IAppointmentRepository appointmentRepository)
        {
            this.doctorRepository = doctorRepository;
            this.doctorServices = doctorServices;
            this.appointmentRepository = appointmentRepository;
        }
        public IActionResult Index()
        {
            try
            {
                List<DoctorDataViewModel> doctorDataViewModels = new List<DoctorDataViewModel>();
                int a = (int)HttpContext.Session.GetInt32("SessionId");
                doctorDataViewModels = doctorServices.GetDoctorData(int.Parse(TempData["Id"].ToString()));
                return View(doctorDataViewModels);
            }
            catch(Exception )
            {
                return RedirectToAction("Logout", "Account");
            }
            
        }
        public IActionResult UpdateSpeciality()
        {
            try
            {
                DoctorSpecalityVm doctorSpecality = new DoctorSpecalityVm();
                doctorSpecality.UserId = int.Parse(TempData["Id"].ToString());

                return View(doctorSpecality);
            }
            catch(Exception )
            {
                return RedirectToAction("Logout", "Account");
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSpeciality(DoctorSpecalityVm doctorSpecality)
        {
            if(ModelState.IsValid)
            {
                doctorServices.PostDoctorSpeciality(doctorSpecality);
                return RedirectToAction("Index");
            }
            return View(doctorSpecality);
        }
        public IActionResult AddAvailability()
        {
            try
            {
                DoctorAvailabilityVm doctorAvailability = new DoctorAvailabilityVm();
                doctorAvailability = doctorServices.GenerateAvailability();
                doctorAvailability.UserId = int.Parse(TempData["Id"].ToString());
                return View(doctorAvailability);
            }
            catch(Exception )
            {
                return RedirectToAction("Logout", "Account");
            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAvailability(DoctorAvailabilityVm doctorAvailability)
        {
            if (ModelState.IsValid)
            {
                doctorServices.PostDoctorAvailability(doctorAvailability);
                return RedirectToAction("Index");
            }
            return View(doctorAvailability);
        }
        public IActionResult Appointments()
        {
            List<AppointmentDataVm> appointmentDataVms = new List<AppointmentDataVm>();
            appointmentDataVms = doctorServices.GetAppointmentDetails((int)HttpContext.Session.GetInt32("SessionId"));
            return View(appointmentDataVms);
        }
        public IActionResult Approve(int id)
        {
            appointmentRepository.Approve(id);
            doctorServices.GeneratePatientRecord(id);
            return RedirectToAction("Appointments");
        }
        public IActionResult Reject(int id)
        {
            appointmentRepository.Reject(id);
            return RedirectToAction("Appointments");
        }
    }
}
