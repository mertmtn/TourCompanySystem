#nullable disable
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace TourCompany.Web.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly INotyfService _notyf;

        public LanguageController(ILanguageService languageService, INotyfService notyf)
        {
            _languageService = languageService;
            _notyf = notyf;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_languageService.GetAll());
        }

        public IActionResult Detail(int? id)
        {
            var language = _languageService.GetById(id.Value);
            return (language != null) ? PartialView("~/Views/Language/Partials/Detail.cshtml", language) : NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("~/Views/Language/Partials/Create.cshtml");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(LanguageCreateOrEditViewModel languageViewModel)
        {
            var result = _languageService.Add(new Language()
            {
                Name = languageViewModel.Name,
                IsActive = languageViewModel.IsActive
            });

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }

                return PartialView("~/Views/Language/Partials/Create.cshtml", languageViewModel);
            }

            return Json(result);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var language = _languageService.GetById(id.Value);

            return (language != null) ? PartialView(new LanguageCreateOrEditViewModel()
            {
                LanguageId = language.LanguageId,
                Name = language.Name,
                IsActive = language.IsActive
            }) : NotFound();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LanguageCreateOrEditViewModel languageViewModel)
        {
            if (id != languageViewModel.LanguageId) return NotFound();

            var result = _languageService.Update(new Language()
            {
                LanguageId = languageViewModel.LanguageId,
                Name = languageViewModel.Name,
                IsActive = languageViewModel.IsActive
            });

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }

                return PartialView("~/Views/Language/Partials/Create.cshtml", languageViewModel);
            }

            return Json(result);
        }

        public IActionResult Delete(int? id)
        { 
            var language = _languageService.GetById(id.Value);
            return (language != null) ? PartialView("~/Views/Language/Partials/Delete.cshtml", language) : NotFound();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var language = _languageService.GetById(id);
            _languageService.Delete(language);
            _notyf.Success("Silme işlemi başarılıdır.");
            return RedirectToAction(nameof(Index));
        }
    }
}
