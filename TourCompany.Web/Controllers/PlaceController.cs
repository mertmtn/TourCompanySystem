#nullable disable
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Controllers
{
    public class PlaceController : Controller
    {

        private readonly IPlaceService _placeService;
        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_placeService.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            Place place = _placeService.GetById(id.Value);

            return (place != null) ? View(place) : NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PlaceCreateOrEditViewModel placeViewModel)
        {
            Place guide = new()
            {
                IsActive = placeViewModel.IsActive,
                Name = placeViewModel.Name,
                Price = placeViewModel.Price.GetValueOrDefault()
            };

            var result = _placeService.Add(guide);
            if (result.StatusCode == 200) return RedirectToAction(nameof(Index));

            foreach (var message in result.MessageList)
            {
                ModelState.AddModelError(message.Key, message.Value);
            }

            return View(placeViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            Place place = _placeService.GetById(id.Value);

            if (place != null)
            {
                return View(new PlaceCreateOrEditViewModel()
                {
                    PlaceId = place.PlaceId,
                    IsActive = place.IsActive,
                    Name = place.Name,
                    Price = place.Price
                });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PlaceCreateOrEditViewModel placeViewModel)
        {
            if (id != placeViewModel.PlaceId) return NotFound();

            Place place = new()
            {
                PlaceId = placeViewModel.PlaceId,
                IsActive = placeViewModel.IsActive,
                Name = placeViewModel.Name,
                Price = placeViewModel.Price.GetValueOrDefault()
            };

            var result = _placeService.Update(place);

            if (result.StatusCode == 200) return RedirectToAction(nameof(Index));

            foreach (var message in result.MessageList)
            {
                ModelState.AddModelError(message.Key, message.Value);
            }
            return View(placeViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Place place = _placeService.GetById(id.Value);

            return (place != null) ? View(place) : NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Place place = _placeService.GetById(id);
            _placeService.Delete(place);
            return RedirectToAction(nameof(Index));
        }

    }
}
