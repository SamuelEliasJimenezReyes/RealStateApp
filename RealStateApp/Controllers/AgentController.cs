using Microsoft.AspNetCore.Mvc;

namespace RealStateApp.Controllers
{
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
    }
}
