#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;
using TourCompany.Web.Models.Validation;

namespace TourCompany.Web.Controllers
{
    public class TouristController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly INationalityService _nationalityService;
        private readonly ITouristService _touristService;
        public TouristController(ICountryService countryService,
            INationalityService nationalityService,
            ITouristService touristService)
        {
            _countryService = countryService;
            _nationalityService = nationalityService;
            _touristService = touristService;
        }

        public IActionResult Index()
        {
            return View(_touristService.GetAll());
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            Tourist tourist = _touristService.GetById(id.Value);
            return (tourist != null) ? View(tourist) : NotFound();
        }

        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_countryService.GetAll(), "CountryId", "Name");
            ViewData["NationalityId"] = new SelectList(_nationalityService.GetAll(), "NationalityId", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TouristCreateOrEditViewModel touristViewModel)
        {
            var result = new TouristValidator().Validate(touristViewModel);
            if (result.IsValid)
            {
                Tourist tourist = new()
                {
                    Name = touristViewModel.Name,
                    BirthDate = touristViewModel.BirthDate.Value,
                    Gender = touristViewModel.Gender,
                    CountryId = touristViewModel.CountryId.Value,
                    NationalityId = touristViewModel.NationalityId.Value,
                    Surname = touristViewModel.Surname
                };
                _touristService.Add(tourist);
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }


            ViewData["CountryId"] = new SelectList(_countryService.GetAll(), "CountryId", "Name", touristViewModel.CountryId);
            ViewData["NationalityId"] = new SelectList(_nationalityService.GetAll(), "NationalityId", "Name", touristViewModel.NationalityId);
            return View(touristViewModel);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var tourist = _touristService.GetById(id.Value);
            if (tourist != null)
            {
                ViewData["CountryId"] = new SelectList(_countryService.GetAll(), "CountryId", "Name", tourist.CountryId);
                ViewData["NationalityId"] = new SelectList(_nationalityService.GetAll(), "NationalityId", "Name", tourist.NationalityId);

                return View(new TouristCreateOrEditViewModel()
                {
                    TouristId = tourist.TouristId,
                    Name = tourist.Name,
                    BirthDate = tourist.BirthDate,
                    Gender = tourist.Gender,
                    CountryId = tourist.CountryId,
                    NationalityId = tourist.NationalityId,
                    Surname = tourist.Surname
                });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TouristCreateOrEditViewModel touristViewModel)
        {
            if (id != touristViewModel.TouristId)
            {
                return NotFound();
            }

            var result = new TouristValidator().Validate(touristViewModel);
            if (result.IsValid)
            {
                try
                {
                    Tourist tourist = new()
                    {
                        TouristId = touristViewModel.TouristId,
                        Name = touristViewModel.Name,
                        BirthDate = touristViewModel.BirthDate.Value,
                        Gender = touristViewModel.Gender,
                        CountryId = touristViewModel.CountryId.Value,
                        NationalityId = touristViewModel.NationalityId.Value,
                        Surname = touristViewModel.Surname
                    };

                    _touristService.Update(tourist);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TouristExists(touristViewModel.TouristId))
                    {
                        return NotFound();
                    } 
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            ViewData["CountryId"] = new SelectList(_countryService.GetAll(), "CountryId", "Name", touristViewModel.CountryId);
            ViewData["NationalityId"] = new SelectList(_nationalityService.GetAll(), "NationalityId", "Name", touristViewModel.NationalityId);
            return View(touristViewModel);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Tourist tourist = _touristService.GetById(id.Value);

            return (tourist != null) ? View(tourist) : NotFound();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Tourist tourist = _touristService.GetById(id);
            _touristService.Delete(tourist);
            return RedirectToAction(nameof(Index));
        }

        private bool TouristExists(int id)
        {
            return _touristService.GetById(id) != null;
        }
    }
}
