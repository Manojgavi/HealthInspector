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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
       
        public ActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                   
                    user.UserId = userServices.GetUserId(user.FirstName, user.PhoneNumber);
                    if (!userRepository.UserExists(user.UserId))
                    {
                        string userId = userRepository.PostUser(user);

                        if (user.UserId == userId)
                        {
                            return Content("User Id created sucessfully, please remember this user id for login : " + userId);
                        }
                        else
                        {
                            return Content("Something went wrong please try again");
                        }
                    }
                    else
                    {
                        return Content("User already exist in database");
                    }

                        
                }
                

                return View(user);
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }

        
        public ActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

       
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel,string returnUrl)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    ClaimsIdentity identity = null;
                    bool IsAuthenticate = false;
                    if (userRepository.UserExists(loginViewModel.UserId, loginViewModel.Password))
                    {
                        identity = new ClaimsIdentity(new[]
                        {
                           new Claim(ClaimTypes.Name,loginViewModel.UserId),
                           new Claim(ClaimTypes.Role,userRepository.GetRole(loginViewModel.UserId))
                       },CookieAuthenticationDefaults.AuthenticationScheme) ;
                        IsAuthenticate = true;
                    }

                    if (IsAuthenticate)
                    {
                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(principal);
                        if (returnUrl == null)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction(returnUrl);
                        }
                        
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "The user name or password is incorrect");
                        return View(loginViewModel);
                    }
                }



                return View(loginViewModel);
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

       
    }
}
