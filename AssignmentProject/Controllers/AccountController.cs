using AssignmentProject.Models;
using AssignmentProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepo;
        public AccountController(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepo.CreateUserAsync(signUpModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View();
                }
                ModelState.Clear();
            }
            return View();
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel signInModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepo.PasswordSignIn(signInModel);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid");
            }
            return View(signInModel);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepo.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
