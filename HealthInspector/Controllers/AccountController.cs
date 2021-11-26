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
using System.Net.Mail;
using System.Net;

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
                            #region mail sending
                            SendVerificationLinkEmail(user.UserId,user.Email);
                            #endregion
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
        public ActionResult ForgotUserId()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotUserId(ForgotUserIdViewModel model)
        {
            if(ModelState.IsValid)
            {
                string userId = userRepository.GetUserId(model);
                if(userId==null)
                {
                    ModelState.AddModelError(string.Empty,"Wrong Details, Please verify and try again");
                    return View(model);
                }
                else
                {
                    return Content("Your UserId Is : " + userId);
                }
                
            }
            else
            {
                return View(model);
            }
            
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool correct = userRepository.IsCorrect(model);
                
                if (correct)
                {
                    TempData["UserId"] = model.UserId;
                    return RedirectToAction("ChangePassword","Account");
                    
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Wrong Details, Please verify and try again");
                    return View(model);
                }

            }
            else
            {
                return View(model);
            }

        }
        
        public ActionResult ChangePassword()
        {
            ChangePasswordViewModel viewModel = new ChangePasswordViewModel();
            viewModel.UserId = TempData["UserId"].ToString();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                userRepository.ChangePassword(model);
                return RedirectToAction("Login","Account");
            }
            else
            {
                return View(model);
            }
            
        }
        [NonAction]
        public void SendVerificationLinkEmail(string userId, string Email)
        {
            var fromEmail = new MailAddress("greeshother@gmail.com");
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "othergreesh";
            string subject = "You are successfully registered for Vaccination";

            string body = "Hi " + "<br/><br/>We are excited to tell you that you are successfully registered in our website. Your user id is : <br/>"+userId;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)

            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })

                smtp.Send(message);

        }

    }
}
