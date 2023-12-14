using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.ViewModels.User;
using RealStateApp.Core.Application.Helpers;
using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.Interface.Services;
using WebApp.RealStateApp.Middlewares;
using DRSocialNetwork.Application.Helpers;
using RealStateApp.Core.Application.ViewModels.AgentImages;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.RealStateApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAgentImagesService _agentImagesService;

        public UserController(IUserService userService, IAgentImagesService agentImagesService)
        {
            _userService = userService;
            _agentImagesService = agentImagesService;
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            AuthenticationResponse userVm = await _userService.LoginAsync(vm, false);
            if (userVm != null && userVm.HasError != true)
            {
                HttpContext.Session.Set<AuthenticationResponse>("user", userVm);
                if (userVm.Roles.Contains("Client"))
                {
                    return RedirectToRoute(new { controller = "Client", action = "Index" });
                }
                return RedirectToRoute(new { controller = "Home", action = "AgentProperties",agentId = userVm.Id });
            }
            else
            {
                vm.HasError = userVm.HasError;
                vm.Error = userVm.Error;
                return View(vm);
            }
        }

        
        public async Task<IActionResult> LogOut()
        {
            await _userService.SignOutAsync();
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            return View(new SaveUserViewModel());
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel vm)
        {
            var origin = Request.Headers["origin"];

            RegisterResponse response = new();

            if (ModelState.IsValid)
            {
                if (vm.IsAgent)
                {
                    response = await _userService.RegisterAsync(vm, origin, "Agent");
                }
                else
                {
                    response = await _userService.RegisterAsync(vm, origin, "Client");

                }
                if (!response.HasError && vm.IsAgent)
                {
                    var imagesgenerated = FileManager.Upload(vm.File, response.UserId , "Agent");
                    SaveAgentImagesVM saveAgentImages = new()
                    {
                        AgentId = response.UserId, 
                        ImagePath = imagesgenerated
                    };
                    await _agentImagesService.Add(saveAgentImages);
                }
                if (response.HasError)
                {
                    vm.HasError = true;
                    vm.ErrorMessage = response.Error;
                    return View(vm);
                }
                
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            return View(vm);
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            string response = await _userService.ConfirmEmailAsync(userId, token);
            return View("ConfirmEmail", response);
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordViewModel());
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var origin = Request.Headers["origin"];
            ForgotPasswordResponse response = await _userService.ForgotPasswordAsync(vm, origin);
            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View(vm);
            }
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        public IActionResult ResetPassword(string token, string email)
        {
            return View(new ResetPasswordViewModel { Token = token, Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel vm)
        {
            if (vm.Email == null && vm.Password == null && vm.ConfirmPassword == null)
            {
                return View(vm);
            }
            
            ResetPasswordResponse response = await _userService.ResetPasswordAsync(vm);
            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View(vm);
            }
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}

