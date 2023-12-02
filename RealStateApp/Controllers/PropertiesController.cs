using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.Properties;

namespace RealStateApp.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertiesService _propertiesService;
        private readonly IPropertiesTypesService _propertiesTypesService;
        private readonly ISalesTypeService _salesTypeService;
        private readonly IImprovementsService _ImprovementsService;

        public PropertiesController(IPropertiesService propertiesService, 
            IPropertiesTypesService propertiesTypesService, 
            ISalesTypeService salesTypeService, 
            IImprovementsService ImprovementsService)
        {
            _propertiesService = propertiesService;
            _propertiesTypesService = propertiesTypesService;
            _salesTypeService = salesTypeService;
            _ImprovementsService = ImprovementsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var savePropertiesVM = new SavePropertiesVM();
            savePropertiesVM.PropertiesTypes = await _propertiesTypesService.GetAllViewModel();
            savePropertiesVM.SalesTypes = await _salesTypeService.GetAllViewModel();
            savePropertiesVM.Improvements = await _ImprovementsService.GetAllViewModel();

            return View(savePropertiesVM);
        }
    }
}
