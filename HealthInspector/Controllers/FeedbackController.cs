using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthInspector.IRepository;
using HealthInspector.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthInspector.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository feedbackRepository;
        private readonly IMapper mapper;
        private readonly IClinicRepository clinicRepository;

        public FeedbackController(IClinicRepository clinicRepository,IMapper mapper, IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
            this.mapper = mapper;
            this.clinicRepository = clinicRepository;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult Feedbackdata()
        {
            FeedbackViewModel feedbackViewModel = new FeedbackViewModel();
            feedbackViewModel.Clinics = clinicRepository.GetClinics();
            
            return View(feedbackViewModel);
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
        [Authorize(Roles="Admin")]
        public IActionResult FeedbackList()
        {
            List<FeedbackDataViewModel> feedbackDataViewModels = new List<FeedbackDataViewModel>();
            feedbackDataViewModels = feedbackRepository.GetFeedbackList();
            return View(feedbackDataViewModels);
        }

    }
}