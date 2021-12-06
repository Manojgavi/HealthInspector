using HealthInspector.Data;
using HealthInspector.Models;
using HealthInspector.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Controllers
{
    public class HelpController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HelpController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Help> objHelpList = _db.Helps;
            return View(objHelpList);
        }

        public ActionResult Create()
        {
            HelpViewModel model = new HelpViewModel();
            return View(model);
        }

        [HttpPost]


        public async Task<ActionResult> Create(HelpViewModel model)
        {
            if(ModelState.IsValid)
            {
                _db.Helps.Add(new Help() { Issue = model.Issue, UserId = model.UserId, Description = model.Description });
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult ListOfIssues()
        {
            List<Help> helps = new List<Help>();
            helps = _db.Helps.ToList();
            return View(helps);
        }
        public IActionResult Resolution(int id)
        {
            Help help = new Help();
            help = _db.Helps.FirstOrDefault(m => m.Id == id);
            return View(help);
        }
        [HttpPost]
        public IActionResult Resolution(Help help)
        {
            if(ModelState.IsValid)
            {
                _db.Helps.Update(help);
                _db.SaveChanges();
                return RedirectToAction("ListOfIssues");
            }
            return View(help);
        }


        public IActionResult ListOfResolutions()
        {
            List<Help> helps = new List<Help>();
            helps = _db.Helps.ToList();
            return View(helps);
        }


    }
}
