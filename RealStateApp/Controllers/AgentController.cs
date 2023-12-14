using DRSocialNetwork.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Dtos.User;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.Agents;
using RealStateApp.Core.Application.ViewModels.Properties;


namespace RealStateApp.Controllers
{
    public class AgentController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPropertiesService _propertiesService;

        public AgentController(IUserService userService, IPropertiesService propertiesService)
        {
            _userService = userService;
            _propertiesService = propertiesService;
        }

        public IActionResult Index()
        {
            return View();

        }

        public async Task<IActionResult> MyProfile()
        {
            var user = await _userService.GetUserDTOAsync();
            var editUser = new UpdateAgentVM
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                ImagePath = user.ImagePath,
                agentId = user.UserId
            };
            return View(editUser);
        }

        [HttpPost]
        public async Task<IActionResult> MyProfile(UpdateAgentVM vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            UserDTO value = new();

            value.Phone = vm.Phone;
            value.FirstName = vm.FirstName;
            value.LastName = vm.LastName;
            var imagesgenerated = FileManager.Upload(vm.File, vm.agentId, "Agent");
            value.ImagePath = imagesgenerated;
            
            await _userService.UpdateUserByUserId(value);

            return RedirectToRoute(new { controller = "Home", action = "AgentProperties" });
        }

      
    }
}
