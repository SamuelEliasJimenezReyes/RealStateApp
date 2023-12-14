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
        private readonly IUserService _userService;

        public AdminController(IAccountService service, AuthenticationResponse userSession, IHttpContextAccessor httpContextAccessor, IStatisticsService statisticsService, IUserService userService)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _userSession = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _statisticsService = statisticsService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _statisticsService.GetDashBoard();
            return View(list);
        }
        public async Task<IActionResult> AgentList()
        {
            var list = await _userService.GetAllAgentVM();
            return View(list);
        }
        public async Task<IActionResult> ChangeUserStatus(string userID)
        {
            await _userService.ChangeUserStatus(userID);
            var list = await _userService.GetAllAgentVM();
            return View("AgentList", list);
        }


    }
}
