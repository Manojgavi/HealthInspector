using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInspector.IControllerServices;
using HealthInspector.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HealthInspector.Controllers
{
    public class PatientRecordController : Controller
    {
        private readonly IPatientRecordRepository patientRepository;
        private readonly IPatientRecordServices patientServices;

        public IActionResult Index()
        {
            return View();
        }
    }
}
