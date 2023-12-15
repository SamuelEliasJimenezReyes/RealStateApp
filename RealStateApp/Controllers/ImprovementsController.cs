
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.Services;
using RealStateApp.Core.Application.ViewModels.Improvements;
using RealStateApp.Core.Application.ViewModels.PropertiesTypes;

namespace realstateapp.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ImprovementsController : Controller
    {
        private readonly IImprovementsService _improvementsService;

        public ImprovementsController(IImprovementsService improvementsService)
        {
            _improvementsService = improvementsService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _improvementsService.GetAllViewModel();
            return View(list);
        }

        public IActionResult AddImprovements()
        {
            ViewBag.EditMode = false;
            return View(new SavePropertiesTypesVM());
        }

        [HttpPost]
        public async Task<IActionResult> AddImprovements(SaveImprovementsVM svm)
        {
            if (ModelState.IsValid)
            {
                await _improvementsService.Add(svm);
                var list = await _improvementsService.GetAllViewModel();
                return View("Index", list);
            }
            return View(svm);
        }

        public async Task<IActionResult> EditImprovements(int Id)
        {
            ViewBag.EditMode = true;
            var caseStatusVM = await _improvementsService.GetByIdSaveViewModel(Id);
            return View("AddPropertiesTypes", caseStatusVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditImprovements(SaveImprovementsVM svm, int id)
        {
            if (ModelState.IsValid)
            {
                await _improvementsService.Update(svm, id);
                var list = await _improvementsService.GetAllViewModel();
                return View("Index", list);
            }
            return View(svm);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _improvementsService.Delete(Id);
            var list = await _improvementsService.GetAllViewModel();
            return View("Index", list);
        }
    }
}

