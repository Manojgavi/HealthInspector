using AutoMapper;
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
        private readonly ITreatementRepository treatementRepository;
        private readonly IMapper mapper;

        public DoctorController(IMapper mapper,ITreatementRepository treatementRepository,IDoctorRepository doctorRepository,IDoctorServices doctorServices,IAppointmentRepository appointmentRepository)
        {
            this.doctorRepository = doctorRepository;
            this.doctorServices = doctorServices;
            this.appointmentRepository = appointmentRepository;
            this.treatementRepository = treatementRepository;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            try
            {
                List<DoctorDataViewModel> doctorDataViewModels = new List<DoctorDataViewModel>();
                int a = (int)HttpContext.Session.GetInt32("SessionId");
                doctorDataViewModels = doctorServices.GetDoctorData((int)HttpContext.Session.GetInt32("SessionId"));
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
                doctorSpecality.UserId = (int)HttpContext.Session.GetInt32("SessionId");

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
                doctorAvailability.UserId = (int)HttpContext.Session.GetInt32("SessionId");
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
            doctorServices.GeneratePatientRecord(id);
            appointmentRepository.Approve(id);
            
            return RedirectToAction("Appointments");
        }
        public IActionResult Reject(int id)
        {
            appointmentRepository.Reject(id);
            return RedirectToAction("Appointments");
        }

        public IActionResult Patients()
        {
            List<Treatment> treatments = new List<Treatment>();
            treatments = doctorServices.GetPatientIdList((int)HttpContext.Session.GetInt32("SessionId"));
            return View(treatments);
        }
        public IActionResult PatientDetails(int id,int treatementId)
        {
            List<AppointmentDataVm> appointmentDataVms = new List<AppointmentDataVm>();
            appointmentDataVms = doctorServices.GetApprovedAppointmentDetails((int)HttpContext.Session.GetInt32("SessionId"));
            AppointmentDataVm appointmentDataVm = new AppointmentDataVm();
            appointmentDataVm = appointmentDataVms.Where(m => m.Id == id).FirstOrDefault();
            appointmentDataVm.TreatementId = treatementId;
            return View(appointmentDataVm);

        }

        public IActionResult UpdateTreatement(int id)
        {
            Treatment treatment = new Treatment();
            TreatementVm treatementVm = new TreatementVm();
            treatment = treatementRepository.GetTreatementById(id);
            treatementVm = mapper.Map<TreatementVm>(treatment);
            return View(treatementVm);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult UpdateTreatement(TreatementVm treatementVm)
        {
            if(ModelState.IsValid)
            {
                Treatment treatment = new Treatment();
                treatment = mapper.Map<Treatment>(treatementVm);
                treatementRepository.UpdateTreatement(treatment);
                return RedirectToAction("Patients");
            }

            
            return View(treatementVm);
        }
    }
}
