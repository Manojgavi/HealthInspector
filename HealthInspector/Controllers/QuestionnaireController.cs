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
    public class QuestionnaireController : Controller
    {

        private readonly IQuestionnaireRepository questionnaireRepository;
        private readonly IMapper mapper;


        public QuestionnaireController(IMapper mapper, IQuestionnaireRepository questionnaireRepository)
        {
            this.questionnaireRepository = questionnaireRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult QuestionnaireData()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult QuestionnaireData(QuestionnaireViewModel user)
        {
            if (ModelState.IsValid)
            {
                questionnaireRepository.PostUser(user);
                return Content("Your Feedback have received sucessfully");
            }
            return View(user);
        }

    }
}
