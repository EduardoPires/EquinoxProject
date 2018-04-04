<<<<<<< HEAD
<<<<<<< HEAD
﻿using Equinox.Infra.CrossCutting.Identity.Models;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Equinox.Domain.Core.Models;
using Equinox.Infra.CrossCutting.Identity.Models;
>>>>>>> c0e4a03... adding some files
=======
﻿using Equinox.Infra.CrossCutting.Identity.Models;
>>>>>>> 86e6256... Daily commit

namespace Equinox.WebApi.ViewModels
{
    public class UserProfile
    {
        public UserProfile() { }
        public UserProfile(ApplicationUser user)
        {
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 86e6256... Daily commit
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            UserName = user.UserName;
            Picture = user.Picture;
            Name = user.Name;
            Url = user.Url;
            Company = user.Company;
            JobTitle = user.JobTitle;
            Bio = user.Bio;
<<<<<<< HEAD
        }

        public string Bio { get; set; }

        public string JobTitle { get; set; }

        public string Company { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

=======
            this.Email = user.Email;
            this.PhoneNumber = user.PhoneNumber;
            this.UserName = user.UserName;
            this.Picture = user.Picture;
        }

>>>>>>> c0e4a03... adding some files
=======
        }

        public string Bio { get; set; }

        public string JobTitle { get; set; }

        public string Company { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

>>>>>>> 86e6256... Daily commit
        public string Picture { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
