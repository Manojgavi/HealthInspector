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

       
    }
}
