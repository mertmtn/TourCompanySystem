#nullable disable
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Controllers
{
    public class ToursController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IPlaceService _placeService;
        private readonly IGuideService _guideService;
        public ToursController(ITourService tourService, IPlaceService placeService, IGuideService guideService)
        {
            _tourService = tourService;
            _placeService = placeService;
            _guideService = guideService;
        }
        public IActionResult Index()
        {
            return View(_tourService.GetAll());
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            Tour tour = _tourService.GetById(id.Value);

            return (tour != null) ? View(tour) : NotFound();
        }
        public IActionResult Create()
        {
            return View(new TourCreateOrEditViewModel
            {
                Places = _placeService.GetAll(x => x.IsActive == true),
                Guides = _guideService.GetAll()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TourCreateOrEditViewModel tourViewModel)
        {
            Tour tour = new()
            {
                GuideId = tourViewModel.GuideId.GetValueOrDefault(),
                IsActive = tourViewModel.IsActive,
                Name = tourViewModel.Name,
                TourDate = tourViewModel.TourDate.GetValueOrDefault()
            };

            var result = _tourService.Add(tour, tourViewModel.SelectedPlaces);
            if (result.StatusCode == 200) return RedirectToAction(nameof(Index));

            foreach (var message in result.MessageList)
            {
                ModelState.AddModelError(message.Key, message.Value);
            }
            tourViewModel.Places = _placeService.GetAll(x => x.IsActive == true);
                tourViewModel.Guides = _guideService.GetAll();
            return View(tourViewModel);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            Tour tour = _tourService.GetById(id.Value);

            if (tour != null)
            {
                return View(new TourCreateOrEditViewModel()
                {
                    GuideId = tour.GuideId,
                    Guides = _guideService.GetAll(),
                    Places = _placeService.GetAll(),
                    SelectedPlaces = tour.Places.Select(x => x.PlaceId.ToString()).ToArray(),
                    Name = tour.Name,
                    TourDate = tour.TourDate,
                    IsActive = tour.IsActive,
                    TourId = tour.TourId
                });
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TourCreateOrEditViewModel tourViewModel)
        {
            if (id != tourViewModel.TourId) return NotFound();
            Tour tour = new()
            {
                GuideId = tourViewModel.GuideId.Value,
                IsActive = tourViewModel.IsActive,
                Name = tourViewModel.Name,
                TourDate = tourViewModel.TourDate.GetValueOrDefault(),
                TourId = tourViewModel.TourId
            };

            var result = _tourService.Update(tour, tourViewModel.SelectedPlaces);

            if (result.StatusCode == 200) return RedirectToAction(nameof(Index));

            foreach (var message in result.MessageList)
            {
                ModelState.AddModelError(message.Key, message.Value);
            }
            tourViewModel.Places = _placeService.GetAll(x => x.IsActive == true);
            tourViewModel.Guides = _guideService.GetAll();
            return View(tourViewModel);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Tour tour = _tourService.GetById(id.Value);
            return (tour != null) ? View(tour) : NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Tour tour = _tourService.GetById(id);
            _tourService.Delete(tour);
            return RedirectToAction(nameof(Index));
        }                
    }
}
