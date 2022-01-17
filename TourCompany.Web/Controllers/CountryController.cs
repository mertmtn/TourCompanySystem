#nullable disable
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.Validation;
using TourCompany.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TourCompany.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_countryService.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            Country country = _countryService.GetById(id.Value);

            return (country != null) ? View(country) : NotFound();
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CountryCreateOrEditViewModel countryViewModel)
        {
            var result = new CountryValidator().Validate(countryViewModel);
            if (result.IsValid)
            {
                _countryService.Add(new Country()
                {
                    Name = countryViewModel.Name,
                    IsActive = countryViewModel.IsActive
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
            return View(countryViewModel);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            Country country = _countryService.GetById(id.Value);

            if (country != null)
            {
                return View(new CountryCreateOrEditViewModel()
                {
                    Name = country.Name,
                    CountryId = country.CountryId,
                    IsActive = country.IsActive
                });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, CountryCreateOrEditViewModel countryViewModel)
        {
            if (id != countryViewModel.CountryId)
            {
                return NotFound();
            }

            var result = new CountryValidator().Validate(countryViewModel);
            if (result.IsValid)
            {
                try
                {
                    _countryService.Update(new Country()
                    {
                        Name = countryViewModel.Name,
                        CountryId = countryViewModel.CountryId,
                        IsActive = countryViewModel.IsActive
                    });
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(countryViewModel.CountryId))
                    {
                        return NotFound();
                    }
                }
                return View(countryViewModel);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(countryViewModel);
            }
        }


        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Country country = _countryService.GetById(id.Value);

            return (country != null) ? View(country) : NotFound();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Country country = _countryService.GetById(id);
            _countryService.Delete(country);
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
        {
            return _countryService.GetById(id) != null;
        }
    }
}
