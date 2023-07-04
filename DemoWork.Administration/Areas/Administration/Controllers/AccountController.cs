using DemoWork.Entities.Models;
using DemoWork.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWork.Administration.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class AccountController : Controller
    {
        private readonly UserManager<AccountUser> _userManager;
        private readonly SignInManager<AccountUser> _signInManager;

        public AccountController(UserManager<AccountUser> userManager, SignInManager<AccountUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //../Account/Register
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }


        
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AccountUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    DateOfBirth = model.DateOfBirth,
                    Country = model.Country,
                    City = model.City,
                    Status = "Active",
                    CreatedAt = DateTime.Now,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }

        //../Account/login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            ViewBag.SolutionBaseURL = Startup.BaseURL["SolutionBaseURL"];
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(RegistrationViewModel user)
        {
            user.ConfirmPassword = user.Password;

            //if (ModelState.IsValid)
            //{
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            //}
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
