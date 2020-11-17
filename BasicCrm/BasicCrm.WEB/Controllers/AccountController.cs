using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCrm.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using BasicCrm.WEB.Dto;
using BasicCrm.WEB.Models;

namespace BasicCrm.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> logger;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        public AccountController(UserManager<AppUser> userManager, ILogger<AccountController> logger, SignInManager<AppUser> signInManager)
        {
            this.logger = logger;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Customer");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    RedirectToAction("Index", "Customer");
                }
            }
            ModelState.AddModelError("","Failed To Login");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Customer");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                
                var result = await userManager.CreateAsync(user, model.Password);

                
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Customer");
                }

                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
