using Microsoft.AspNetCore.Mvc;

namespace Personalportfolio.Controllers
{
    public class SocialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
