#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;
using TourCompany.Web.Models.Validation;

namespace TourCompany.Web.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_languageService.GetAll());
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            Language language = _languageService.GetById(id.Value);

            return (language != null) ? View(language) : NotFound();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LanguageCreateOrEditViewModel languageViewModel)
        {
            var result = new LanguageValidator().Validate(languageViewModel);
            if (result.IsValid)
            {
                _languageService.Add(new Language()
                {
                    Name = languageViewModel.Name,
                    IsActive = languageViewModel.IsActive
                });
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View(languageViewModel);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            Language language = _languageService.GetById(id.Value);
            if (language != null)
            {
                return View(new LanguageCreateOrEditViewModel()
                {
                    LanguageId = language.LanguageId,
                    Name = language.Name,
                    IsActive = language.IsActive
                });
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LanguageCreateOrEditViewModel languageViewModel)
        {
            if (id != languageViewModel.LanguageId)
            {
                return NotFound();
            }

            var result = new LanguageValidator().Validate(languageViewModel);
            if (result.IsValid)
            {
                try
                {
                    _languageService.Update(new Language()
                    {
                        LanguageId = languageViewModel.LanguageId,
                        Name = languageViewModel.Name,
                        IsActive = languageViewModel.IsActive
                    });
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageExists(languageViewModel.LanguageId))
                    {
                        return NotFound();
                    }
                }
                return View(languageViewModel);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(languageViewModel);
            }
        }


        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Language language = _languageService.GetById(id.Value);
            return (language != null) ? View(language) : NotFound();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Language language = _languageService.GetById(id);
            _languageService.Delete(language);
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageExists(int id)
        {
            return _languageService.GetById(id) != null;
        }
    }
}
