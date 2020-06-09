using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.UI.Web.Controllers
{
    public class BaseController : Controller
    {
        public ICollection<string> Errors = new List<string>();

        protected bool ResponseHasErrors(ValidationResult result)
        {
            if (result == null || result.IsValid) return false;

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }

            return true;
        }

        protected void AddProcessError(string erro)
        {
            Errors.Add(erro);
        }

        public bool IsValidOperation()
        {
            return !Errors.Any();
        }
    }
}
