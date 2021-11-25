using HealthInspector.IRepository;
using HealthInspector.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Controllers
{
    public class ClinicController : Controller
    {
        private readonly IClinicRepository clinicRepository;

        public ClinicController(IClinicRepository clinicRepository)
        {
            this.clinicRepository = clinicRepository;
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
        public IActionResult Create(Clinic clinic)
        {
            if(ModelState.IsValid)
            {
                clinicRepository.PostClinic(clinic);
                return RedirectToAction("Index");
            }
            else
            {
                return View(clinic);
            }
            
        }
    }
}
