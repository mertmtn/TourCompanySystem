#nullable disable
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.Validation;
using TourCompany.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TourCompany.Web.Controllers
{
    public class NationalityController : Controller
    {
        private readonly INationalityService _nationalityService;

        public NationalityController(INationalityService nationalityService)
        {
            _nationalityService = nationalityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_nationalityService.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            Nationality nationality = _nationalityService.GetById(id.Value);

            return (nationality != null) ? PartialView("~/Views/Nationality/Partials/Detail.cshtml", nationality) : NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NationalityCreateOrEditViewModel nationalityViewModel)
        {
            var result = new NationalityValidator().Validate(nationalityViewModel);
            if (result.IsValid)
            {
                _nationalityService.Add(new Nationality()
                {
                    Name = nationalityViewModel.Name,
                    IsActive = nationalityViewModel.IsActive
                });
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(nationalityViewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            Nationality nationality = _nationalityService.GetById(id.Value);

            if (nationality != null)
            {
                return View(new NationalityCreateOrEditViewModel()
                {
                    Name = nationality.Name,
                    IsActive = nationality.IsActive,
                    NationalityId = nationality.NationalityId
                });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, NationalityCreateOrEditViewModel nationalityViewModel)
        {
            if (id != nationalityViewModel.NationalityId)
            {
                return NotFound();
            }

            var result = new NationalityValidator().Validate(nationalityViewModel);
            if (result.IsValid)
            {
                try
                {
                    _nationalityService.Update(new Nationality()
                    {
                        Name = nationalityViewModel.Name,
                        NationalityId = nationalityViewModel.NationalityId,
                        IsActive = nationalityViewModel.IsActive
                    });
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NationalityExists(nationalityViewModel.NationalityId))
                    {
                        return NotFound();
                    }
                }
                return View(nationalityViewModel);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(nationalityViewModel);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Nationality nationality = _nationalityService.GetById(id.Value);

            return (nationality != null) ? PartialView("~/Views/Nationality/Partials/Delete.cshtml", nationality) : NotFound();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Nationality nationality = _nationalityService.GetById(id);
            _nationalityService.Delete(nationality);
            return RedirectToAction(nameof(Index));
        }

        private bool NationalityExists(int id)
        {
            return _nationalityService.GetById(id) != null;
        }
    }
}
