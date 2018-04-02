using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Equinox.Domain.Core.Notifications;
using Equinox.Infra.CrossCutting.Identity.Models;
using Equinox.Infra.CrossCutting.Identity.Models.ManageViewModels;
using Equinox.WebApi.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.WebApi.Controllers
{
    [Authorize]
    public class ManageController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ManageController(
            INotificationHandler<DomainNotification> notifications,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHostingEnvironment hostingEnvironment
            ) : base(notifications)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [Route("account-management/change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (changePasswordResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return Response(changePasswordResult);
        }


        [HttpPost]
        [Route("account-management/update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UserProfile model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            user.Company = model.Company;
            user.Bio = model.Bio;
            user.Name = model.Name;
            user.Url = model.UserName;
            user.JobTitle = model.JobTitle;

            var result = await _userManager.UpdateAsync(user);
            return Response(result);
        }


        [HttpPost]
        [Route("account-management/update-picture")]
        public async Task<IActionResult> UploadFile([FromBody] FileUpload file)
        {
            //var user = await _userManager.GetUserAsync(User);
            //RemovePreviousImage(user);
            //await UpdatePictureLocation(user, dbPath);


            return Response("");
        }


        private async Task UpdatePictureLocation(ApplicationUser user, string dbPath)
        {
            user.Picture = dbPath;
            await _userManager.UpdateAsync(user);
        }

        private void RemovePreviousImage(ApplicationUser user)
        {
            var filename = Path.GetFileName(user.Picture);
            System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "uploads", filename));
        }

        [HttpGet]
        [Route("account-management/profile")]
        public async Task<IActionResult> GetProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            return Response(new UserProfile(user));
        }

    }
}
