using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.Properties;

namespace RealStateApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly IPropertiesService _propertiesService;
        private readonly IPropertiesTypesService _propertiesTypesService;
        private readonly IUserService _userService;

        public ClientController(IPropertiesService propertiesService, 
            IPropertiesTypesService propertiesTypesService, 
            IUserService userService)
        {
            _propertiesService = propertiesService;
            _propertiesTypesService = propertiesTypesService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PropertyTypes = await _propertiesTypesService.GetAllViewModel();
            var list = await _propertiesService.GetPropertiesForClient();
            ViewBag.PropertiesList = list.OrderByDescending(x => x.Id).ToList();
            return View(new PropertiesFilterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Search(PropertiesFilterVM filter)
        {
            ViewBag.PropertyTypes = await _propertiesTypesService.GetAllViewModel();
            ViewBag.PropertiesList = await _propertiesService.GetAllPropertiesVM(filter);
            return View("Index", filter);
        }

        [HttpPost]
        public async Task<IActionResult> Filter(PropertiesFilterVM filter)
        {
            ViewBag.PropertyTypes = await _propertiesTypesService.GetAllViewModel();
            ViewBag.PropertiesList = await _propertiesService.GetAllPropertiesVM(filter);
            return View("Index", filter);
        }

        public async Task<IActionResult> PropertyDetail(string code)
        {
            var property = await _propertiesService.GetPropertyByCode(code);
            return View(property);
        }

        public async Task<IActionResult> FavoriteProperties()
        {
            var list = await _propertiesService.GetFavoritePropertiesForClient();
            ViewBag.PropertiesList = list.OrderByDescending(x => x.Id).ToList();
            return View(new PropertiesFilterVM());
        }

        public async Task<IActionResult> AddFavoriteProperty(string clientId, int propertyId)
        {
            await _propertiesService.AddFavoriteProperties(propertyId, clientId);
            ViewBag.PropertyTypes = await _propertiesTypesService.GetAllViewModel();
            ViewBag.PropertiesList = await _propertiesService.GetPropertiesForClient();
            return View("Index",new PropertiesFilterVM());
        }

        public async Task<IActionResult> DeleteFavoriteProperty(string clientId, int propertyId, bool isForFavorite)
        {
            await _propertiesService.RemoveFavoriteProperty(clientId, propertyId);
            ViewBag.PropertyTypes = await _propertiesTypesService.GetAllViewModel();
            if (isForFavorite)
            {
                ViewBag.PropertiesList = await _propertiesService.GetFavoritePropertiesForClient();
                return View("FavoriteProperties", new PropertiesFilterVM());
            }
            ViewBag.PropertiesList = await _propertiesService.GetPropertiesForClient();
            return View("Index", new PropertiesFilterVM());

        }

    }
}
