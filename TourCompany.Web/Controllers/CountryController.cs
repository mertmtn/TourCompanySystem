#nullable disable
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace TourCompany.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly INotyfService _notyf;

        public CountryController(ICountryService countryService, INotyfService notyf)
        {
            _notyf = notyf;
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_countryService.GetAll());
        }

        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            var country = _countryService.GetById(id.Value);
            return (country != null) ? PartialView("~/Views/Country/Partials/Detail.cshtml", country) : NotFound();
        }

        public IActionResult Create()
        {
            return PartialView("~/Views/Country/Partials/Create.cshtml");
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(CountryCreateOrEditViewModel countryViewModel)
        {
            var result = _countryService.Add(new Country()
            {
                Name = countryViewModel.Name,
                IsActive = countryViewModel.IsActive
            });

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }

                return PartialView("~/Views/Country/Partials/Create.cshtml", countryViewModel);
            }

            return Json(result);
        }

        public IActionResult Edit(int? id)
        {
            var country = _countryService.GetById(id.Value);

            return (country != null) ? PartialView("~/Views/Country/Partials/Edit.cshtml", new CountryCreateOrEditViewModel()
            {
                Name = country.Name,
                CountryId = country.CountryId,
                IsActive = country.IsActive
            }) : NotFound();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(CountryCreateOrEditViewModel countryViewModel)
        {
            var result = _countryService.Update(new Country()
            {
                Name = countryViewModel.Name,
                CountryId = countryViewModel.CountryId,
                IsActive = countryViewModel.IsActive
            });

            return Json(result);
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
            _notyf.Success("Silme işlemi başarılıdır.");
            return RedirectToAction(nameof(Index));
        }
    }
}
