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
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Equinox.WebApi.Controllers
{
    [Authorize]
    public class ManageController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password
        private readonly IConfiguration _configuration;
=======
>>>>>>> 48ff526... daily commit
=======
        private readonly IHostingEnvironment _hostingEnvironment;
>>>>>>> 86e6256... Daily commit
<<<<<<< HEAD
=======
=======
        private readonly IConfiguration _configuration;
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
        private readonly IConfiguration _configuration;
>>>>>>> c3e8855... Fixing rebase errors

        public ManageController(
            INotificationHandler<DomainNotification> notifications,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
<<<<<<< HEAD
<<<<<<< HEAD
            IHostingEnvironment hostingEnvironment
>>>>>>> 86e6256... Daily commit
<<<<<<< HEAD
=======
=======
            IConfiguration configuration
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
            IConfiguration configuration
>>>>>>> c3e8855... Fixing rebase errors
            ) : base(notifications)
        {
            _userManager = userManager;
            _signInManager = signInManager;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors
            _configuration = configuration;
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors
            if (!file.fileType.Contains("image"))
            {
                NotifyError("Type", "Invalid filetype");
                return Response();
            }

            var user = await _userManager.GetUserAsync(User);
            var container = await GetBlobContainer();
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password

            await RemovePreviousImage(user, container);

            var newPicture = await UploadNewOne(file, container);

            user.Picture = newPicture.StorageUri.PrimaryUri.AbsoluteUri;
            await _userManager.UpdateAsync(user);

            return Response(user.Picture);
        }

        private async Task<CloudBlobContainer> GetBlobContainer()
        {
            var storageCredentials = new StorageCredentials(_configuration.GetSection("AzureBlob").GetSection("AccountName").Value, _configuration.GetSection("AzureBlob").GetSection("AccountKey").Value);
            var cloudStorageAccount = new CloudStorageAccount(storageCredentials, true);
            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            var container = cloudBlobClient.GetContainerReference("images");
            await container.CreateIfNotExistsAsync();
            return container;
        }

        private static async Task<CloudBlockBlob> UploadNewOne(FileUpload file, CloudBlobContainer container)
        {
            // Upload the new one.
            var newImageName = Guid.NewGuid() + file.fileType.Replace("image/", ".");
            var newPicture = container.GetBlockBlobReference(newImageName);
            byte[] imageBytes = Convert.FromBase64String(file.value);
            newPicture.Properties.ContentType = file.fileType; //.Replace("image/", "");
            await newPicture.UploadFromByteArrayAsync(imageBytes, 0, imageBytes.Length);
            return newPicture;
        }

        private static async Task RemovePreviousImage(ApplicationUser user, CloudBlobContainer container)
        {
            // Remove previous image
            if (!string.IsNullOrEmpty(user.Picture))
            {
                var pictureName = Path.GetFileName(user.Picture);
                var oldImage = container.GetBlockBlobReference(pictureName);
                await oldImage.DeleteIfExistsAsync();
            }
        }


=======
            //var user = await _userManager.GetUserAsync(User);
            //RemovePreviousImage(user);
            //await UpdatePictureLocation(user, dbPath);
=======
>>>>>>> 383c77b... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors

            await RemovePreviousImage(user, container);

            var newPicture = await UploadNewOne(file, container);

            user.Picture = newPicture.StorageUri.PrimaryUri.AbsoluteUri;
            await _userManager.UpdateAsync(user);

            return Response(user.Picture);
        }

        private async Task<CloudBlobContainer> GetBlobContainer()
        {
            var storageCredentials = new StorageCredentials(_configuration.GetSection("AzureBlob").GetSection("AccountName").Value, _configuration.GetSection("AzureBlob").GetSection("AccountKey").Value);
            var cloudStorageAccount = new CloudStorageAccount(storageCredentials, true);
            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            var container = cloudBlobClient.GetContainerReference("images");
            await container.CreateIfNotExistsAsync();
            return container;
        }

        private static async Task<CloudBlockBlob> UploadNewOne(FileUpload file, CloudBlobContainer container)
        {
            // Upload the new one.
            var newImageName = Guid.NewGuid() + file.fileType.Replace("image/", ".");
            var newPicture = container.GetBlockBlobReference(newImageName);
            byte[] imageBytes = Convert.FromBase64String(file.value);
            newPicture.Properties.ContentType = file.fileType; //.Replace("image/", "");
            await newPicture.UploadFromByteArrayAsync(imageBytes, 0, imageBytes.Length);
            return newPicture;
        }

        private static async Task RemovePreviousImage(ApplicationUser user, CloudBlobContainer container)
        {
            // Remove previous image
            if (!string.IsNullOrEmpty(user.Picture))
            {
                var pictureName = Path.GetFileName(user.Picture);
                var oldImage = container.GetBlockBlobReference(pictureName);
                await oldImage.DeleteIfExistsAsync();
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 86e6256... Daily commit
=======
<<<<<<< HEAD
>>>>>>> 86e6256... Daily commit
=======

>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======

>>>>>>> c3e8855... Fixing rebase errors
        [HttpGet]
        [Route("account-management/profile")]
        public async Task<IActionResult> GetProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            return Response(new UserProfile(user));
        }

    }
}
