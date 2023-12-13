using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.Helpers;
using RealStateApp.Core.Application.Interface.Services;

namespace RealStateApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountService _service;
        private readonly AuthenticationResponse _userSession;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStatisticsService _statisticsService;

        public AdminController(IAccountService service, AuthenticationResponse userSession, IHttpContextAccessor httpContextAccessor, IStatisticsService statisticsService)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _userSession = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _statisticsService = statisticsService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _statisticsService.GetDashBoard();
            return View(list);
        }
    }
}
