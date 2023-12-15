
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.PropertiesTypes;

namespace realstateapp.Controllers
{
    [Authorize(Roles = "Admin")]

    public class PropertiesTypesController : Controller
    {
        private readonly IPropertiesTypesService _propertiesTypesService;

        public PropertiesTypesController(IPropertiesTypesService propertiesTypesService)
        {
            _propertiesTypesService = propertiesTypesService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _propertiesTypesService.GetAllViewModel();
            return View(list);
        }


        public IActionResult AddPropertiesTypes()
        {
            ViewBag.EditMode = false;
            return View(new SavePropertiesTypesVM());
        }

        [HttpPost]
        public async Task<IActionResult> AddPropertiesTypes(SavePropertiesTypesVM svm)
        {
            if (ModelState.IsValid)
            {
                await _propertiesTypesService.Add(svm);
                var list = await _propertiesTypesService.GetAllViewModel();
                return View("Index", list);
            }
            return View(svm);
        }

        public async Task<IActionResult> EditPropertiesTypes(int Id)
        {
            ViewBag.EditMode = true;
            var caseStatusVM = await _propertiesTypesService.GetByIdSaveViewModel(Id);
            return View("AddPropertiesTypes", caseStatusVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditPropertiesTypes(SavePropertiesTypesVM svm, int id)
        {
            if (ModelState.IsValid)
            {
                await _propertiesTypesService.Update(svm, id);
                var list = await _propertiesTypesService.GetAllViewModel();
                return View("Index", list);
            }
            return View(svm);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _propertiesTypesService.Delete(Id);
            var list = await _propertiesTypesService.GetAllViewModel();
            return View("Index",list);
        }
    }
}

