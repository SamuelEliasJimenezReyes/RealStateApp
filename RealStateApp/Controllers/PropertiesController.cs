using DRSocialNetwork.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.ImagesProperties;
using RealStateApp.Core.Application.ViewModels.Properties;

namespace RealStateApp.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertiesService _propertiesService;
        private readonly IPropertiesTypesService _propertiesTypesService;
        private readonly ISalesTypeService _salesTypeService;
        private readonly IImprovementsService _ImprovementsService;
        private readonly IImagesPropertiesService _imagesPropertiesService;

        public PropertiesController(IPropertiesService propertiesService, 
            IPropertiesTypesService propertiesTypesService,
            ISalesTypeService salesTypeService, 
            IImprovementsService improvementsService, 
            IImagesPropertiesService imagesPropertiesService)
        {
            _propertiesService = propertiesService;
            _propertiesTypesService = propertiesTypesService;
            _salesTypeService = salesTypeService;
            _ImprovementsService = improvementsService;
            _imagesPropertiesService = imagesPropertiesService;
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

        [HttpPost]
        public async Task<IActionResult> Create(SavePropertiesVM svm)
        {

            if (!ModelState.IsValid)
            {
                if (svm.File.Count >= 5)
                {
                    svm.HasError = true;
                    svm.ErrorMessage = $"Solo Puede seleccionar 4 Imagenes, {svm.File.Count} exceden el número máximo de Imagenes";
                    svm.PropertiesTypes = await _propertiesTypesService.GetAllViewModel();
                    svm.SalesTypes = await _salesTypeService.GetAllViewModel();
                    svm.Improvements = await _ImprovementsService.GetAllViewModel();
                    return View(svm);
                }

               var saveProperties = await _propertiesService.Add(svm);

                if (svm.File != null && svm.File.Count >= 1)
                {
                    foreach (var file in svm.File)
                    {
                        var imagesgenerated = FileManager.Upload(file, saveProperties.Code.ToString(), "Properties");

                        svm.ImagesProperties.Add(imagesgenerated);

                    }

                    foreach(var imagespath in svm.ImagesProperties)
                    {
                        var ip = new SaveImagesPropertiesVM
                        {
                            PropertiesId = saveProperties.Id,
                            ImageUrl = imagespath
                        };

                        await _imagesPropertiesService.Add(ip);
                    }

                }

                return RedirectToRoute(new {controller = "Properties", action = "Index" });

            }

            return View(svm);

        }
    }
}
