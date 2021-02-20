using System;
using Repository;
using System.Linq;
using ViewModels.Account;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace My_Application.Controllers
{
    public class AccountController : Controller
    {
        // IMessageSender 
        private readonly IMessageSender _messageSender;

        // User Manager
        private readonly UserManager<IdentityUser> _userManager;

        // SignInManager
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager , IMessageSender messageSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _messageSender = messageSender;
        }

        #region Register
        // Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.Username,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                // Create Succeeded 
                if (result.Succeeded)
                {
                    // Generate Email Token
                    var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    // Url email message
                    var emailMessage =
                        Url.Action("ConfirmEmail", "Account",
                                    new { username = user.UserName,
                                        token = emailConfirmationToken },
                                    Request.Scheme);

                    // Send Email
                    await _messageSender.SendEmailAsync(model.Email, subject: "E-Mail Confirmation", emailMessage ,  isMessageHtml : false ) ;

                    return RedirectToAction("Index", "Home");
                }

                // Create Error
                foreach (var identityError in result.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }
            }

            return View(model);
        }

        #endregion

        #region Login
        // Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            // Cheking Is Sign In
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            // Cheking Url
            ViewData["returnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            // Cheking Is Sign In
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            // Cheking Url
            ViewData["returnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username,
                                                                       model.Password,
                                                                       model.RememberMe,
                                                                       true);
                // Password Succeeded
                if (result.Succeeded)
                {
                    // Password dont null or empty and WebSite Url Succeeded
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                // Password Is Locked Out 
                if (result.IsLockedOut)
                {
                    ViewData["ErrorMessage"] = "You've been temporarily locked out of your account for 5 hours";
                    return View(model);
                }

                // Error Message
                ModelState.AddModelError("", "Your User Username Or Password Is Incorrect");
            }
            return View(model);
        }
        #endregion

        #region LogOut
        // LogOut
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Check Duplicate
        // Duplicate Email
        [HttpGet]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            // Find by email 
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }

            return Json("The Entered Email Is Already Available");
        }

        // Duplicate Username
        [HttpGet]
        public async Task<IActionResult> IsUsernameInUse(string username)
        {
            // Find bu name (Username)
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return Json(true);
            }

            return Json("The Entered Username Is Already Available");
        }
        #endregion

        #region Confirm Email
        // Confirm Email
        public async Task<IActionResult> ConfirmEmail(string username , string token)
        {
            // Null or Empty Username or token
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(token))
            {
                return NotFound();
            }

            // Find Username
            var user = await _userManager.FindByNameAsync(username);
            
            if (user == null)
            {
                return NotFound();
            }

            // Confirm Email
            var result = await _userManager.ConfirmEmailAsync(user , token);

            return Content(result.Succeeded ? " Email Confirmed " : "Email Not Confirmed");
        }
        #endregion

    }
}