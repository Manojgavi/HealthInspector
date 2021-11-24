using AutoMapper;

using HealthInspector.IRepository;
using HealthInspector.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInspector.IControllerServices;

namespace HealthInspector.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IUserServices userServices;

        public AccountController(IMapper mapper,IUserRepository userRepository,IUserServices userServices)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.userServices = userServices;
        }
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                   
                    user.UserId = userServices.GetUserId(user.FirstName, user.PhoneNumber);

                   
                    string userId = userRepository.PostUser(user);
                    if(user.UserId==userId)
                    {
                        return Content("User Id created sucessfully, please remember this user id for login : "+userId);
                    }
                    else
                    {
                        return Content("Something went wrong please try again");
                    }
                }
                

                return View(user);
            }
            catch
            {
                return View(user);
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Success(string userId)
        {
            return View(userId);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
