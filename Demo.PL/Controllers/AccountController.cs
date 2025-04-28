using Demo.DAL.Models;
using Demo.PL.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class AccountController(UserManager<ApplicatioUser> userManager, SignInManager<ApplicatioUser> signInManager) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid) // server side validation
            {
                var user = new ApplicatioUser()
                {
                    UserName = viewModel.Email.Split('@')[0], // mahaahmed@gmail.com => mahaahmed
                    Email = viewModel.Email,
                    IsAgree = viewModel.IsAgree,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                };
                var result = userManager.CreateAsync(user, viewModel.Password).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                return View(viewModel);


            }

            return View(viewModel);

        }
    }
}
