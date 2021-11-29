using HealthInspector.IControllerServices;
using HealthInspector.IRepository;
using HealthInspector.Models;
using HealthInspector.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        public DoctorController(IDoctorRepository doctorRepository,IDoctorServices doctorServices)
        {
            this.doctorRepository = doctorRepository;
            this.doctorServices = doctorServices;
        }
        public IActionResult Index()
        {
            try
            {
                List<DoctorDataViewModel> doctorDataViewModels = new List<DoctorDataViewModel>();
                doctorDataViewModels = doctorServices.GetDoctorData(int.Parse(TempData["Id"].ToString()));
                return View(doctorDataViewModels);
            }
            catch(Exception ex)
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
            catch(Exception ex)
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
            catch(Exception ex)
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

    }
}
