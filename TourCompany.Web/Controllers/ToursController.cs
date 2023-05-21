#nullable disable
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace TourCompany.Web.Controllers
{
    public class ToursController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IPlaceService _placeService;
        private readonly IGuideService _guideService;
        private readonly INotyfService _notyf;

        public ToursController(ITourService tourService, IPlaceService placeService, IGuideService guideService, INotyfService notyf)
        {
            _tourService = tourService;
            _placeService = placeService;
            _guideService = guideService;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View(_tourService.GetAll());
        }

        public IActionResult Details(int? id)
        {
            var tour = _tourService.GetById(id.Value);
            return (tour != null) ? PartialView("~/Views/Tours/Partials/Detail.cshtml", tour) : NotFound();
        }

        public IActionResult Create()
        {
            return PartialView("~/Views/Tours/Partials/Create.cshtml", new TourCreateOrEditViewModel
            {
                Places = _placeService.GetAll(x => x.IsActive == true),
                Guides = _guideService.GetAll()
            });
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(TourCreateOrEditViewModel tourViewModel)
        {
            var result = _tourService.Add(new()
            {
                GuideId = tourViewModel.GuideId.GetValueOrDefault(),
                IsActive = tourViewModel.IsActive,
                Name = tourViewModel.Name,
                TourDate = tourViewModel.TourDate.GetValueOrDefault()
            }, tourViewModel.SelectedPlaces);

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }
                tourViewModel.Places = _placeService.GetAll(x => x.IsActive == true);
                tourViewModel.Guides = _guideService.GetAll();
                return PartialView("~/Views/Tours/Partials/Create.cshtml", tourViewModel);
            }

            return Json(result);
        }


        public IActionResult Edit(int? id)
        {
            var tour = _tourService.GetById(id.Value);

            return (tour != null)
            ?
                 PartialView("~/Views/Tourist/Partials/Edit.cshtml", new TourCreateOrEditViewModel()
                 {
                     GuideId = tour.GuideId,
                     Guides = _guideService.GetAll(),
                     Places = _placeService.GetAll(),
                     SelectedPlaces = tour.Places.Select(x => x.PlaceId.ToString()).ToArray(),
                     Name = tour.Name,
                     TourDate = tour.TourDate,
                     IsActive = tour.IsActive,
                     TourId = tour.TourId
                 })
            : NotFound();
        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TourCreateOrEditViewModel tourViewModel)
        {
            var result = _tourService.Update(new()
            {
                GuideId = tourViewModel.GuideId.Value,
                IsActive = tourViewModel.IsActive,
                Name = tourViewModel.Name,
                TourDate = tourViewModel.TourDate.GetValueOrDefault(),
                TourId = tourViewModel.TourId
            }, tourViewModel.SelectedPlaces);

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }
                tourViewModel.Places = _placeService.GetAll(x => x.IsActive == true);
                tourViewModel.Guides = _guideService.GetAll();
                return PartialView("~/Views/Tours/Partials/Edit.cshtml", tourViewModel);
            }
            return Json(result);
        }


        public IActionResult Delete(int? id)
        {
            var tour = _tourService.GetById(id.Value);
            return (tour != null) ? PartialView("~/Views/Tours/Partials/Delete.cshtml", tour) : NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tour = _tourService.GetById(id);
            _tourService.Delete(tour);
            _notyf.Success("Silme işlemi başarılıdır.");
            return RedirectToAction(nameof(Index));
        }
    }
}
