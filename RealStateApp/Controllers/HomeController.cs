using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.Properties;

namespace RealStateApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPropertiesService _propertiesService;
        private readonly IPropertiesTypesService _propertiesTypesService;

        public HomeController(IPropertiesService propertiesService, IPropertiesTypesService propertiesTypesService)
        {
            _propertiesService = propertiesService;
            _propertiesTypesService = propertiesTypesService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PropertyTypes = await _propertiesTypesService.GetAllViewModel();
            ViewBag.PropertiesList = await _propertiesService.GetAllPropertiesVM(new PropertiesFilterVM());
            return View(new PropertiesFilterVM());
        }

        [HttpPost]
        public async Task <IActionResult> Search(PropertiesFilterVM filter)
        
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


    }
}
