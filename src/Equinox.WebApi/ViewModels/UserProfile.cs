using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Equinox.Domain.Core.Models;
using Equinox.Infra.CrossCutting.Identity.Models;

namespace Equinox.WebApi.ViewModels
{
    public class UserProfile
    {
        public UserProfile() { }
        public UserProfile(ApplicationUser user)
        {
            this.Email = user.Email;
            this.PhoneNumber = user.PhoneNumber;
            this.UserName = user.UserName;
            this.Picture = user.Picture;
        }

        public string Picture { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
