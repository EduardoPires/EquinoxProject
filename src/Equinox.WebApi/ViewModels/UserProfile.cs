using Equinox.Infra.CrossCutting.Identity.Models;

namespace Equinox.WebApi.ViewModels
{
    public class UserProfile
    {
        public UserProfile() { }
        public UserProfile(ApplicationUser user)
        {
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            UserName = user.UserName;
            Picture = user.Picture;
            Name = user.Name;
            Url = user.Url;
            Company = user.Company;
            JobTitle = user.JobTitle;
            Bio = user.Bio;
        }

        public string Bio { get; set; }

        public string JobTitle { get; set; }

        public string Company { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
