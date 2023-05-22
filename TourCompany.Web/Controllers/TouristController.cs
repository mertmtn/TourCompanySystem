#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace TourCompany.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TouristController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly INationalityService _nationalityService;
        private readonly ITouristService _touristService;
        private readonly INotyfService _notyf;

        public TouristController(ICountryService countryService, INationalityService nationalityService, ITouristService touristService, INotyfService notyf)
        {
            _countryService = countryService;
            _nationalityService = nationalityService;
            _touristService = touristService;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View(_touristService.GetAll());
        }

        public IActionResult Detail(int? id)
        { 
            var tourist = _touristService.GetById(id.Value);
            return (tourist != null) ? PartialView("~/Views/Tourist/Partials/Detail.cshtml", tourist) : NotFound();
        }

        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_countryService.GetAll(), "CountryId", "Name");
            ViewData["NationalityId"] = new SelectList(_nationalityService.GetAll(), "NationalityId", "Name");
            return PartialView("~/Views/Tourist/Partials/Create.cshtml");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TouristCreateOrEditViewModel touristViewModel)
        { 
            var result = _touristService.Add(new()
            {
                Name = touristViewModel.Name,
                BirthDate = touristViewModel.BirthDate.GetValueOrDefault(),
                Gender = touristViewModel.Gender,
                CountryId = touristViewModel.CountryId.GetValueOrDefault(),
                NationalityId = touristViewModel.NationalityId.GetValueOrDefault(),
                Surname = touristViewModel.Surname
            });

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }
                ViewData["CountryId"] = new SelectList(_countryService.GetAll(), "CountryId", "Name", touristViewModel.CountryId);
                ViewData["NationalityId"] = new SelectList(_nationalityService.GetAll(), "NationalityId", "Name", touristViewModel.NationalityId);
                return PartialView("~/Views/Tourist/Partials/Create.cshtml", touristViewModel);
            }

            return Json(result); 
        }


        public IActionResult Edit(int? id)
        { 
            var tourist = _touristService.GetById(id.Value);
            if (tourist != null)
            {
                ViewData["CountryId"] = new SelectList(_countryService.GetAll(), "CountryId", "Name", tourist.CountryId);
                ViewData["NationalityId"] = new SelectList(_nationalityService.GetAll(), "NationalityId", "Name", tourist.NationalityId);

                return PartialView("~/Views/Tourist/Partials/Edit.cshtml", new TouristCreateOrEditViewModel()
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
            var result = _touristService.Update(new()
            {
                TouristId = touristViewModel.TouristId,
                Name = touristViewModel.Name,
                BirthDate = touristViewModel.BirthDate.GetValueOrDefault(),
                Gender = touristViewModel.Gender,
                CountryId = touristViewModel.CountryId.GetValueOrDefault(),
                NationalityId = touristViewModel.NationalityId.GetValueOrDefault(),
                Surname = touristViewModel.Surname
            });

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }
                ViewData["CountryId"] = new SelectList(_countryService.GetAll(), "CountryId", "Name", touristViewModel.CountryId);
                ViewData["NationalityId"] = new SelectList(_nationalityService.GetAll(), "NationalityId", "Name", touristViewModel.NationalityId);
                return PartialView("~/Views/Tourist/Partials/Edit.cshtml", touristViewModel);
            }

            return Json(result);
        }

        public IActionResult Delete(int? id)
        {
           var tourist = _touristService.GetById(id.Value);            
            return (tourist != null) ? PartialView("~/Views/Tourist/Partials/Delete.cshtml", tourist) : NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tourist = _touristService.GetById(id);
            _touristService.Delete(tourist);
            _notyf.Success("Silme işlemi başarılıdır.");
            return RedirectToAction(nameof(Index));
        }
    }
}
