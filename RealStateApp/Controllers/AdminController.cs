using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.Helpers;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.Admin;
using RealStateApp.Core.Application.ViewModels.User;
using System.Collections.Generic;

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

        public async Task<IActionResult> DeleteAgents(int ID)
        {
            var list = await _userService.GetAllAgentVM();

            var agentToDelete = list.FirstOrDefault(x => x.Id == ID);
            if (agentToDelete != null)
            {
                list.Remove(agentToDelete);
            }
            return View("AgentList", list);
        }
        //public async Task<IActionResult> AdminCreate()
        //{
        //    SaveAdminViewModel vm = new();
        //    vm = _userService.GetAllAdminVM();
        //    return View("AgentList", vm);
        //}
    }
}
