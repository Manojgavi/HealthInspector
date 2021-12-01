using HealthInspector.IControllerServices;
using HealthInspector.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchServices searchServices;

        public SearchController(ISearchServices searchServices)
        {
            this.searchServices = searchServices;
        }
        public IActionResult Index()
        {
            Search search = new Search();
            search = searchServices.CreateSearch();
            return View(search);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(Search search)
        {
            if (ModelState.IsValid)
            {
                List<SearchDataVm> searchDataVms = new List<SearchDataVm>();
                searchDataVms = searchServices.GetSearchData(search);
                if (searchDataVms == null)
                {
                    ModelState.AddModelError("", "No details found, try with other combination");
                    return View(search);
                }
                else
                {

                    ViewBag.searchDataVms = searchDataVms;
                    return View("SearchResult", searchDataVms);
                }

            }
            return View(search);
        }

        //public IActionResult SearchResult()
        //{
        //    List<SearchDataVm> searchDataVms = new List<SearchDataVm>();
        //    searchDataVms = TempData["searchDataVms"] as List<SearchDataVm>;

        //    return View(searchDataVms);
        //}
    }
}