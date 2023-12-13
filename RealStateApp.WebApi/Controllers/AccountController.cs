using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.Interface.Services;

namespace RealStateApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
               
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            var account = await _accountService.AuthenticateAsync(request, true);
        
            if (account.Roles.Contains("Agent") || account.Roles.Contains("Client"))  
            {
                return Unauthorized();
            }

            return Ok(account);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdminAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterBasicUserAsync(request, origin, "Admin"));
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("register-developer")]
        public async Task<IActionResult> RegisterDeveloperAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterBasicUserAsync(request, origin, "Developer"));
        }

       
      
    }
}


