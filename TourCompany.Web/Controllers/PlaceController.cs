#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using Business.Abstract;

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
        public IActionResult Create([Bind("PlaceId,Name,Price,IsActive")] Place place)
        {
            if (ModelState.IsValid)
            {
                _placeService.Add(place);
                return RedirectToAction(nameof(Index));
            }
            return View(place);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            Place place = _placeService.GetById(id.Value);

            return (place != null) ? View(place) : NotFound();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PlaceId,Name,Price,IsActive")] Place place)
        {
            if (id != place.PlaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _placeService.Update(place);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceExists(place.PlaceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(place);
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

        private bool PlaceExists(int id)
        {
            return _placeService.GetById(id) != null;
        }
    }
}
