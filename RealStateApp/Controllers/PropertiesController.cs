using Microsoft.AspNetCore.Mvc;

namespace RealStateApp.Controllers
{
    public class PropertiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
