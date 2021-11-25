using HealthInspector.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInspector.IRepository;
namespace HealthInspector.Controllers
{
    public class LocalityController : Controller
    {
        private readonly ILocalityRepository localityRepository;

        public LocalityController(ILocalityRepository localityRepository)
        {
            this.localityRepository = localityRepository;

        }
        public IActionResult Index()
        {
            List<Locality> localities = new List<Locality>();
            localities = localityRepository.GetLocalities();
            return View(localities);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Locality locality)
        {
            if(ModelState.IsValid)
            {
                localityRepository.postLocality(locality);
                return RedirectToAction("Index");
            }
            return View(locality);
        }
    }
}
