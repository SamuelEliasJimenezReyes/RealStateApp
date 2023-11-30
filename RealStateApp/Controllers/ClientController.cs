using Microsoft.AspNetCore.Mvc;

namespace RealStateApp.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
