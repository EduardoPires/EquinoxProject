using Microsoft.AspNetCore.Mvc;

namespace Equinox.UI.Web.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Route("welcome")]
        [Route("")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("[action]")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("[action]")]
        public IActionResult Error()
        {
            return View();
        }

        [Route("access-denied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}