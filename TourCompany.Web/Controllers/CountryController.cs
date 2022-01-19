#nullable disable
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;

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

            return (country != null) ? PartialView("~/Views/Country/Partials/Detail.cshtml", country) : NotFound();
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CountryCreateOrEditViewModel countryViewModel)
        {
            var result = _countryService.Add(new Country()
            {
                Name = countryViewModel.Name,
                IsActive = countryViewModel.IsActive
            });

            if (result.StatusCode == 200) return RedirectToAction(nameof(Index));
            
            foreach (var message in result.MessageList)
            {
                ModelState.AddModelError(message.Key, message.Value);
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
            if (id != countryViewModel.CountryId) return NotFound();            

            var result = _countryService.Update(new Country()
            {
                Name = countryViewModel.Name,
                CountryId = countryViewModel.CountryId,
                IsActive = countryViewModel.IsActive
            });

            if (result.StatusCode==200) return RedirectToAction(nameof(Index));

            foreach (var message in result.MessageList)
            {
                ModelState.AddModelError(message.Key, message.Value);
            }
            return View(countryViewModel);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Country country = _countryService.GetById(id.Value);

            return (country != null) ? PartialView("~/Views/Country/Partials/Delete.cshtml", country) : NotFound();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Country country = _countryService.GetById(id);
            _countryService.Delete(country);
            return RedirectToAction(nameof(Index));
        } 
    }
}
