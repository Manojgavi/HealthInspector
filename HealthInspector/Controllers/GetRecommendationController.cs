using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthInspector.IControllerServices;
using HealthInspector.IRepository;
using HealthInspector.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthInspector.Controllers
{
    public class GetRecommendationController : Controller
    {

        private readonly IBmiRepository bmiRepository;
        private readonly IMapper mapper;
        private readonly IBmiServices bmiServices;

        public GetRecommendationController(IMapper mapper, IBmiRepository bmiRepository, IBmiServices bmiServices)
        {
            this.bmiRepository = bmiRepository;
            this.mapper = mapper;
            this.bmiServices = bmiServices;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Underweight()
        {
            return View();
        }

        public IActionResult Healthy()
        {
            return View();
        }

        public IActionResult Overweight()
        {
            return View();
        }


        [HttpGet]
        public IActionResult BmiCalculator()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BmiCalculator(BmiViewModel bmi)
        {
            if (ModelState.IsValid)
            {
                double value = bmiServices.Calculator(bmi.Height, bmi.Weight);
                bmiRepository.PostUser(bmi);

                if (value < 18.5)
                {
                    return RedirectToAction("Underweight");
                }
                else if (value >= 18.5 && value < 24.9)
                {
                    return RedirectToAction("Healthy");
                }
                else if (value >= 24.9 && value < 30)
                {
                    return RedirectToAction("Overweight");
                }
                return null;
            }
            return View(bmi);
        }

        



    }
}
