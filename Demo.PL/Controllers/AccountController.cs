using Demo.DAL.Models;
using Demo.PL.Utilties;
using Demo.PL.ViewModels.Account;
using Demo.PL.Views.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

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

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            {
                if (!ModelState.IsValid) return View(viewModel);

                var user = userManager.FindByEmailAsync(viewModel.Email).Result;
                if (user != null)
                {
                    bool flag = userManager.CheckPasswordAsync(user, viewModel.Password).Result;
                    if (flag)
                    {
                        var Result = signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false).Result;
                        if (!Result.IsNotAllowed)
                            ModelState.AddModelError(string.Empty, "Your Account Is Not Allowed");
                        if (Result.IsLockedOut)
                            ModelState.AddModelError(string.Empty, "Your Account is locked out");
                        if (Result.Succeeded)
                            return RedirectToAction(nameof(HomeController.Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Login");
                    }
                }
                return View(viewModel);

            }

        }


        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Forgrtpassowrd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPassowrdViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByEmailAsync(viewModel.Email).Result;
                if (user is not null)
                {

                    var Token = userManager.GeneratePasswordResetTokenAsync(user).Result;

                    // baseURL/Account/ResetPassword/routemaha@gmail.com/token
                    var ResetPasswordUrl = Url.Action("ResetPassword", "Account", new { email = viewModel.Email, Token }, Request.Scheme);

                    // create Email


                    var email = new Email()
                    {
                        To = viewModel.Email,
                        Subject = "Reset Password",
                        Body = ResetPasswordUrl // TODO
                    };

                    // send Email
                    EmailSettings.SendEmail(email);
                    return RedirectToAction("CheckYourInbox");

                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Operation");
            return View(nameof(ForgotPassword), viewModel);
        }


        [HttpGet]

        public IActionResult ChecYourInbox()
        {
            return View();
        }

        public IActionResult ResatPassword() => View();



    }
}
