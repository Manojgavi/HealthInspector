using HealthInspector.IRepository;
using HealthInspector.Models;
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

        public DoctorController(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpdateSpeciality()
        {
            DoctorSpecality doctorSpecality = new DoctorSpecality();
            doctorSpecality.UserId = int.Parse(TempData["Id"].ToString());
            return View(doctorSpecality);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSpeciality(DoctorSpecality doctorSpecality)
        {
            if(ModelState.IsValid)
            {
                doctorRepository.PostDoctorSpeciality(doctorSpecality);
                return RedirectToAction("Index");
            }
            return View(doctorSpecality);
        }
        public IActionResult AddAvailability()
        {
            DoctorAvailability doctorAvailability = new DoctorAvailability();
            doctorAvailability.UserId = int.Parse(TempData["Id"].ToString());
            return View(doctorAvailability);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAvailability(DoctorAvailability doctorAvailability)
        {
            if (ModelState.IsValid)
            {
                doctorRepository.PostDoctorAvailability(doctorAvailability);
                return RedirectToAction("Index");
            }
            return View(doctorAvailability);
        }

    }
}
