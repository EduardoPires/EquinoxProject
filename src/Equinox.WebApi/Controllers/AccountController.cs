using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Equinox.Domain.Core.Notifications;
using Equinox.Infra.CrossCutting.Identity.Extensions;
using Equinox.Infra.CrossCutting.Identity.Models;
using Equinox.Infra.CrossCutting.Identity.Models.AccountViewModels;
<<<<<<< HEAD
<<<<<<< HEAD
using Equinox.Infra.CrossCutting.Identity.Services;
=======
>>>>>>> c0e4a03... adding some files
=======
using Equinox.Infra.CrossCutting.Identity.Services;
>>>>>>> 383c77b... * Recover Password
using Equinox.WebApi.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
<<<<<<< HEAD
<<<<<<< HEAD
using ServiceStack;
=======
>>>>>>> 86e6256... Daily commit
=======
using ServiceStack;
>>>>>>> 383c77b... * Recover Password
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Equinox.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            INotificationHandler<DomainNotification> notifications,
            ILoggerFactory loggerFactory,
            IEmailSender emailSender,
            IConfiguration configuration) : base(notifications)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _configuration = configuration;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpPost]
<<<<<<< HEAD
<<<<<<< HEAD
=======
        [AllowAnonymous]
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 86e6256... Daily commit
        [Route("account/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }
            SignInResult result = null;
            ApplicationUser user = null;
<<<<<<< HEAD

            if (model.IsUsernameEmail())
            {
                user = await _userManager.FindByEmailAsync(model.Username);
                result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe,
                    lockoutOnFailure: true);
            }
            else
            {
                user = await _userManager.FindByNameAsync(model.Username);
                result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe,
                    lockoutOnFailure: true);
            }

<<<<<<< HEAD
=======
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
>>>>>>> fd1205c... Bug fix while creating new Db.
            if (!result.Succeeded)
<<<<<<< HEAD

=======
>>>>>>> c0e4a03... adding some files
=======

            if (model.IsUsernameEmail())
            {
                user = await _userManager.FindByEmailAsync(model.Username);
                result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe,
                    lockoutOnFailure: true);
            }
            else
            {
                user = await _userManager.FindByNameAsync(model.Username);
                result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe,
                    lockoutOnFailure: true);
            }

            if (!result.Succeeded)

>>>>>>> 86e6256... Daily commit
            {
                NotifyError(result.ToString(), "Login failure");
                return Response(result);
            }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            return Response(new { SignInResult = result, Profile = new UserProfile(user) });
        }

        [HttpPost]
        [Route("account/reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return Response(false);
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            return Response(result);
        }

        [HttpPost]
        [Route("account/forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(false);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist or is not confirmed
                return Response(false);
            }

            // For more information on how to enable account confirmation and password reset please
            // visit https://go.microsoft.com/fwlink/?LinkID=532713
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = $"{_configuration.GetSection("WebAppUrl").Value}/reset-password?email={user.Email.UrlEncode()}&code={code.UrlEncode()}";

            await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");

            return Response(true);
        }

        [HttpGet]
        [Route("account/is-logged-in")]
        public IActionResult IsLoggedIn()
        {
            return Response(User.Identity.IsAuthenticated);
        }

        [HttpPost]
        [Route("account/logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return Response(true);
=======
            return Response(result);
=======
            var userProfile = await _userManager.FindByEmailAsync(model.Email);

            return Response(new { SignInResult = result, Profile = new UserProfile(userProfile) });

>>>>>>> c0e4a03... adding some files
            //if (result.Succeeded)
            //{
            //    _logger.LogInformation("User logged in.");
            //    return Response(model);
            //}
            //if (result.RequiresTwoFactor)
            //{
            //    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
            //}
            //if (result.IsLockedOut)
            //{
            //    _logger.LogWarning("User account locked out.");
            //    return RedirectToAction(nameof(Lockout));
            //}
            //else
            //{
            //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            //    return View(model);
            //}

=======
            return Response(new { SignInResult = result, Profile = new UserProfile(user) });
<<<<<<< HEAD
>>>>>>> 86e6256... Daily commit

<<<<<<< HEAD
            _logger.LogInformation(1, "User logged in.");
            
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> c0e4a03... adding some files
=======
        }

        [HttpPost]
        [Route("account/reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return Response(false);
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            return Response(result);
        }

        [HttpPost]
        [Route("account/forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(false);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist or is not confirmed
                return Response(false);
            }

            // For more information on how to enable account confirmation and password reset please
            // visit https://go.microsoft.com/fwlink/?LinkID=532713
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = $"{_configuration.GetSection("WebAppUrl").Value}/reset-password?email={user.Email.UrlEncode()}&code={code.UrlEncode()}";

            await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");

            return Response(true);
        }

        [HttpGet]
        [Route("account/is-logged-in")]
        public IActionResult IsLoggedIn()
        {
            return Response(User.Identity.IsAuthenticated);
>>>>>>> 383c77b... * Recover Password
        }


        [HttpPost]
        [Route("account/logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return Response(true);
        }


        [HttpPost]
        [Route("account/register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

<<<<<<< HEAD
<<<<<<< HEAD
            var user = new ApplicationUser { UserName = model.Username, Email = model.Email, PhoneNumber = model.Telephone, Name = model.Name };
=======
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.Telephone, };
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
            var user = new ApplicationUser { UserName = model.Username, Email = model.Email, PhoneNumber = model.Telephone, Name = model.Name };
>>>>>>> 86e6256... Daily commit

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // User claim for write customers data
                await _userManager.AddClaimAsync(user, new Claim("Customers", "Write"));
                _logger.LogInformation("User created a new account with password.");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = $"{_configuration.GetSection("WebAppUrl").Value}/confirm-email?userId={user.Id.UrlEncode()}&code={code.UrlEncode()}";
                await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                await _signInManager.SignInAsync(user, false);
                _logger.LogInformation(3, "User created a new account with password.");
                return Response(model);
            }

            AddIdentityErrors(result);
            return Response(model);
        }

        [HttpGet]
<<<<<<< HEAD
<<<<<<< HEAD
=======
        [AllowAnonymous]
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 86e6256... Daily commit
        [Route("account/checkUsername")]
        public async Task<IActionResult> CheckUsername(string username)
        {

            var result = await _userManager.FindByNameAsync(username);

            return Response(result != null);
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 86e6256... Daily commit


        [HttpGet]
        [Route("account/checkEmail")]
        public async Task<IActionResult> CheckEmail(string email)
        {

            var result = await _userManager.FindByEmailAsync(email);

            return Response(result != null);
        }
<<<<<<< HEAD
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 86e6256... Daily commit
    }
}
