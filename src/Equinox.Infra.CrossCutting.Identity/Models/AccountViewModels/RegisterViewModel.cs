using System.ComponentModel.DataAnnotations;

namespace Equinox.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Phone]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 86e6256... Daily commit

        public string Name { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
<<<<<<< HEAD
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 86e6256... Daily commit
    }
}
