using Microsoft.AspNetCore.Mvc;

namespace Equinox.UI.Web.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default");
        }
    }
}