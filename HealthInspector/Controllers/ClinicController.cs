using HealthInspector.IControllerServices;
using HealthInspector.IRepository;
using HealthInspector.Models;
using HealthInspector.ViewModels;
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
        private readonly IClinicServices clinicServices;

        public ClinicController(IClinicRepository clinicRepository,IClinicServices clinicServices)
        {
            this.clinicRepository = clinicRepository;
            this.clinicServices = clinicServices;
        }
        public IActionResult Index()
        {
            List<ClinicDataViewModel> clinics = new List<ClinicDataViewModel>();
            clinics = clinicServices.GetClinics();
            return View(clinics);
        }
        public IActionResult Create()
        {
            ClinicViewModel clinicViewModel = new ClinicViewModel();
            clinicViewModel=clinicServices.Create();
            return View(clinicViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClinicViewModel clinic)
        {
            if(ModelState.IsValid)
            {

                clinicServices.PostClinic(clinic);
                return RedirectToAction("Index");
            }
            else
            {
                return View(clinic);
            }
            
        }
    }
}
