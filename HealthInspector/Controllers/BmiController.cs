using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthInspector.Data;
using HealthInspector.IControllerServices;
using HealthInspector.IRepository;
using HealthInspector.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthInspector.Controllers
{
    public class BmiController : Controller
    {
        private readonly IBmiRepository bmiRepository;
        private readonly IMapper mapper;
        private readonly IBmiServices bmiServices;

        public BmiController(IMapper mapper, IBmiRepository bmiRepository, IBmiServices bmiServices)
        {
            this.bmiRepository = bmiRepository;
            this.mapper = mapper;
            this.bmiServices = bmiServices;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateBmi()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBmi(BmiViewModel user)
        {
            if (ModelState.IsValid)
            {
                double value = bmiServices.Calculator(user.Height, user.Weight);
                bmiRepository.PostUser(user);

                if (value < 18.5)
                {
                    string result = "Your BMI is " + value.ToString("0.00") + " and you are underweight";
                    return Content(result);
                }
                else if (value >= 18.5 && value < 24.9)
                {
                    string result = "Your BMI is " + value.ToString("0.00") + " and you are Healthy";
                    return Content(result);
                }
                else if (value >= 24.9 && value < 30)
                {
                    string result = "Your BMI is " + value.ToString("0.00") + " and you are overweight";
                    return Content(result);
                }
                return null;
            }
                   return View(user);
        }

    }
}

