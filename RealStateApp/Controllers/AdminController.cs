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

        public AdminController(IAccountService service, AuthenticationResponse userSession, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _userSession = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task<IActionResult> IndexAsync()
        {
            var list = await _service.GetAllUsers();
            return View(list);
        }
    }
}
