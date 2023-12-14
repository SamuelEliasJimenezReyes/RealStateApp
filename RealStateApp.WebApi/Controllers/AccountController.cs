using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.Interface.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace RealStateApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Inicio de Sesion/Mantenimiento de Sesiones")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
               
        [HttpPost("authenticate")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Autenticación",
            Description = "aqui nos logueamos con nuestra cuenta"

          )]
        public async Task<IActionResult> AuthenticateAsync([FromQuery] AuthenticationRequest request)

        {
            var account = await _accountService.AuthenticateAsync(request, true);
        
            if (account.Roles.Contains("Agent") || account.Roles.Contains("Client"))  
            {
                return Unauthorized("Agent and Client not authorized for login");
            }

            return Ok(account);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register-admin")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Registro Admin",
            Description = "Aqui registramos una cuenta con el rol de admin"

          )]
        public async Task<IActionResult> RegisterAdminAsync([FromQuery] RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterBasicUserAsync(request, origin, "Admin"));
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("register-developer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Registro Desarrollador",
            Description = "Aqui registramos una cuenta con el rol de desarrollador"

          )]
        public async Task<IActionResult> RegisterDeveloperAsync([FromQuery] RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterBasicUserAsync(request, origin, "Developer"));
        }

       
      
    }
}


