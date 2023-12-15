using DRSocialNetwork.Application.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Enums;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.ImagesProperties;
using RealStateApp.Core.Application.ViewModels.Properties;

namespace RealStateApp.Controllers
{
    [Authorize(Roles = "Agent")]
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

        public async Task<IActionResult> Index(string agentId)
        {
            var list = await _propertiesService.GetAllPropertiesVM(new PropertiesFilterVM { AgentId = agentId });
            ViewBag.PropertiesList = list.OrderByDescending(x => x.Id).ToList();
            return View(new PropertiesFilterVM());
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

                return RedirectToRoute(new {controller = "Properties", action = "Index", agentId = svm.AgentId });

            }

            return View(svm);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var savePropertiesVM = new SavePropertiesVM();
            savePropertiesVM.PropertiesTypes = await _propertiesTypesService.GetAllViewModel();
            savePropertiesVM.SalesTypes = await _salesTypeService.GetAllViewModel();
            savePropertiesVM.Improvements = await _ImprovementsService.GetAllViewModel();

            var list = await _propertiesService.GetAllPropertiesVM(new PropertiesFilterVM());
           var property = list.FirstOrDefault(x => x.Id ==  id);
            var pForRelationshipsId = await _propertiesService.GetByIdSaveViewModel(property.Id);

            savePropertiesVM.Price = property.Price;
            savePropertiesVM.Id = property.Id;
            savePropertiesVM.LandSizeMeter = property.LandSizeMeter;
            savePropertiesVM.BathroomQuantity = property.BathroomQuantity;
            savePropertiesVM.RoomQuantity = property.RoomQuantity;
            savePropertiesVM.AgentId = property.Agent.UserId;
            savePropertiesVM.Code = property.Code;
            savePropertiesVM.Description = property.Description;
            savePropertiesVM.SaleTypeId = pForRelationshipsId.SaleTypeId;
            savePropertiesVM.Code = property.Code;
            savePropertiesVM.PropertiesTypeId = pForRelationshipsId.PropertiesTypeId;

            savePropertiesVM.PropertiesImprovementsId = property.PropertiesImprovements.Select(x => x.Id).ToList();
            savePropertiesVM.ImagesProperties = property.ImagesProperties;
                
                return View(savePropertiesVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePropertiesVM svm)
        {
            var imagesNeeditList = await _imagesPropertiesService.GetAllImagesByPropertyId(svm.Id);
            int imagesNeedIt = imagesNeeditList.Count;
            if (!ModelState.IsValid)
            {
                if (svm.File !=null && svm.File.Count > imagesNeedIt)
                {
                    svm.HasError = true;
                    svm.ErrorMessage = $"Solo Puede seleccionar {imagesNeedIt} Imagenes, {svm.File.Count} exceden el número máximo de Imagenes";
                    svm.PropertiesTypes = await _propertiesTypesService.GetAllViewModel();
                    svm.SalesTypes = await _salesTypeService.GetAllViewModel();
                    svm.Improvements = await _ImprovementsService.GetAllViewModel();
                    svm.ImagesProperties = await _imagesPropertiesService.GetAllImagesByPropertyId(svm.Id);
                    return View(svm);
                }
                
                await _propertiesService.Update(svm, svm.Id);

                if (svm.File != null && svm.File.Count >= 1)
                {
                    foreach (var file in svm.File)
                    {
                        var imagesgenerated = FileManager.Upload(file, svm.Code, "Properties");

                        svm.ImagesProperties.Add(imagesgenerated);
                    }

                    foreach (var imagespath in svm.ImagesProperties)
                    {
                        var ip = new SaveImagesPropertiesVM
                        {
                            PropertiesId = svm.Id,
                            ImageUrl = imagespath
                        };

                        await _imagesPropertiesService.Add(ip);
                    }

                }

                return RedirectToRoute(new { controller = "Properties", action = "Index", agentId = svm.AgentId });

            }

            return View(svm);

        }


        public async Task<IActionResult> DeleteImages(int propertyId, string oldImagesPath)
        {
            await _imagesPropertiesService.DeleteImagesProperties(propertyId, oldImagesPath);
            return RedirectToRoute(new { controller = "Properties", action = "Edit", id = propertyId });
        }

        public async Task<IActionResult> Delete(int propertyId, string agentId)
        {
            await _propertiesService.Delete(propertyId);
             return RedirectToRoute(new { controller = "Properties", action = "Index", agentId = agentId });
  
        }
    }
}
