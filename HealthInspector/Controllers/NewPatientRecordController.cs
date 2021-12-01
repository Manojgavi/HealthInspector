using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthInspector.Data;

namespace HealthInspector.Controllers
{
    public class NewPatientRecordController : Controller
    {
        private readonly ApplicationDbContext _cc;
        public NewPatientRecordController(ApplicationDbContext cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Patient patient)
        {
            _cc.Add(patient);
            _cc.SaveChanges();
            ViewBag.message = "The Record " + patient.PatientName + "Is Saved successfully..";
            return View();
        }
    }
}
