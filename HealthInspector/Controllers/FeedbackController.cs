using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthInspector.IRepository;
using HealthInspector.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthInspector.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository feedbackRepository;
        private readonly IMapper mapper;


        public FeedbackController(IMapper mapper, IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Feedbackdata()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Feedbackdata(FeedbackViewModel user)
        {
            if (ModelState.IsValid)
            {
               feedbackRepository.PostUser(user);
               return Content("Your Feedback have received sucessfully");
            }
            return View(user);
        }

    }
}