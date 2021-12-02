using HealthInspector.IControllerServices;
using HealthInspector.IRepository;
using HealthInspector.Models;
using HealthInspector.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Controllers
{
    public class PatientController : Controller
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IPatientServices patientServices;

        public PatientController(IAppointmentRepository appointmentRepository,IPatientServices patientServices)
        {
            this.appointmentRepository = appointmentRepository;
            this.patientServices = patientServices;
        }
        public IActionResult Index()
        {
            return View();
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
                return Content("AppointmentBooked Successfully");
            }
            return View(appointment);
        }
        public IActionResult Status()
        {
            List<StatusDataViewModel> statusDataViewModels = new List<StatusDataViewModel>();
            statusDataViewModels = patientServices.GetStatusForUser((int)HttpContext.Session.GetInt32("SessionId"));
            return View(statusDataViewModels);
        }
    }
}
