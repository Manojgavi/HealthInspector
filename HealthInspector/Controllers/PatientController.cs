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
    [Authorize(Roles ="Patient")]
    public class PatientController : Controller
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IPatientServices patientServices;
        private readonly ITreatementRepository treatementRepository;

        public PatientController(ITreatementRepository treatementRepository,IAppointmentRepository appointmentRepository,IPatientServices patientServices)
        {
            this.appointmentRepository = appointmentRepository;
            this.patientServices = patientServices;
            this.treatementRepository = treatementRepository;
        }
        public IActionResult Index()
        {
            List<StatusDataViewModel> statusDataViewModels = new List<StatusDataViewModel>();
            statusDataViewModels = patientServices.GetStatusForUser((int)HttpContext.Session.GetInt32("SessionId"));
            NotificationVM notificationVM = new NotificationVM();
           if(statusDataViewModels!=null)
            {
                foreach (var item in statusDataViewModels)
                {
                    Treatment treatment = new Treatment();
                    treatment = treatementRepository.GetTreatementByAppointmentId(item.Id);
                    int diff2 = 10;
                    

                    int diff = (item.Date-DateTime.Now).Days;
                    if (treatment != null)
                    {
                        diff2 = (treatment.NextRevisitDate-DateTime.Now).Days;
                    }

                    if (diff <= 5 && diff>=0)
                    {
                        notificationVM.Appointment = true;
                    }
                    if (diff2 <=5 && diff2 >= 0)
                    {
                        notificationVM.Revisit = true;
                    }
                    if (diff <= 0 && diff2 >= -1)
                    {
                        notificationVM.Review = true;
                    }
                }
            }
            
            return View(notificationVM);
        }

        public IActionResult BookAppointment(int availId)
        {
            Appointment appointment = new Appointment();
            appointment.UserId=  (int)HttpContext.Session.GetInt32("SessionId");
            appointment.DoctorAvailabilityId = availId;
            appointment.Status = "Registered";
            return View(appointment);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult BookAppointment(Appointment appointment)
        {
            if(ModelState.IsValid)
            {
                appointmentRepository.PostAppointment(appointment);
                //TempData["msg"] = "<script>alert('Appointment Booked Successfully')</script>";
                //ViewBag.Alert = "Appointment Booked Successfully";
                return RedirectToAction("Status");
            }
            return View(appointment);
        }
        public IActionResult Status()
        {
            List<StatusDataViewModel> statusDataViewModels = new List<StatusDataViewModel>();
            statusDataViewModels = patientServices.GetStatusForUser((int)HttpContext.Session.GetInt32("SessionId"));
            return View(statusDataViewModels);
        }
        public IActionResult TreatementResults(int id)
        {
            Treatment treatment = new Treatment();
            treatment = treatementRepository.GetTreatementByAppointmentId(id);
            return View(treatment);
        }
    }
}
