using System.Security.Claims;
using System.Threading.Tasks;
using Equinox.Domain.Core.Notifications;
using Equinox.Infra.CrossCutting.Identity.Models;
using Equinox.Infra.CrossCutting.Identity.Models.AccountViewModels;
using Equinox.WebApi.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Equinox.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            INotificationHandler<DomainNotification> notifications,
            ILoggerFactory loggerFactory) : base(notifications)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpPost]
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

            {
                NotifyError(result.ToString(), "Login failure");
                return Response(result);
            }

            return Response(new { SignInResult = result, Profile = new UserProfile(user) });

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

            var user = new ApplicationUser { UserName = model.Username, Email = model.Email, PhoneNumber = model.Telephone, Name = model.Name };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // User claim for write customers data
                await _userManager.AddClaimAsync(user, new Claim("Customers", "Write"));

                await _signInManager.SignInAsync(user, false);
                _logger.LogInformation(3, "User created a new account with password.");
                return Response(model);
            }

            AddIdentityErrors(result);
            return Response(model);
        }

        [HttpGet]
        [Route("account/checkUsername")]
        public async Task<IActionResult> CheckUsername(string username)
        {

            var result = await _userManager.FindByNameAsync(username);

            return Response(result != null);
        }


        [HttpGet]
        [Route("account/checkEmail")]
        public async Task<IActionResult> CheckEmail(string email)
        {

            var result = await _userManager.FindByEmailAsync(email);

            return Response(result != null);
        }
    }
}
