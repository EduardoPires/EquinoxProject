using Microsoft.AspNetCore.Identity;

namespace Equinox.Infra.CrossCutting.Identity.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Picture { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 86e6256... Daily commit
        public string Url { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Bio { get; set; }
        public string JobTitle { get; set; }
<<<<<<< HEAD
=======
>>>>>>> c0e4a03... adding some files
=======
>>>>>>> 86e6256... Daily commit
    }
}
