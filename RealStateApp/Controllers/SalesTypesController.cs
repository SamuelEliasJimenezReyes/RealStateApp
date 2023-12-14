
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.PropertiesTypes;
using RealStateApp.Core.Application.ViewModels.SalesTypes;

namespace realstateapp.Controllers
{
    [Authorize(Roles = "Admin")]

    public class SalesTypesController : Controller
    {
       private readonly ISalesTypeService _salesTypeService;

        public SalesTypesController(ISalesTypeService salesTypeService)
        {
            _salesTypeService = salesTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _salesTypeService.GetAllViewModel();
            return View(list);
        }

        public IActionResult AddSalesTypes()
        {
            ViewBag.EditMode = false;
            return View(new SaveSalesTypesVM());
        }

        [HttpPost]
        public async Task<IActionResult> AddSalesTypes(SaveSalesTypesVM svm)
        {
            if (ModelState.IsValid)
            {
                await _salesTypeService.Add(svm);
                var list = await _salesTypeService.GetAllViewModel();
                return View("Index", list);
            }
            return View(svm);
        }

        public async Task<IActionResult> EditSalesTypes(int Id)
        {
            ViewBag.EditMode = true;
            var caseStatusVM = await _salesTypeService.GetByIdSaveViewModel(Id);
            return View("AddPropertiesTypes", caseStatusVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditSalesTypes(SaveSalesTypesVM svm, int id)
        {
            if (ModelState.IsValid)
            {
                await _salesTypeService.Update(svm, id);
                var list = await _salesTypeService.GetAllViewModel();
                return View("Index", list);
            }
            return View(svm);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _salesTypeService.Delete(Id);
            var list = await _salesTypeService.GetAllViewModel();
            return View("Index",list);
        }
    }
}

