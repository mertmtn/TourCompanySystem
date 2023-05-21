using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TourSellingController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ITouristService _touristService;
        public TourSellingController(ITourService tourService, ITouristService touristService)
        {
            _tourService = tourService;
            _touristService = touristService;
        }

        public IActionResult Index(int? id)
        {
            if (id == null) return NotFound();

            Tourist tourist = _touristService.GetById(id.Value);
            if (tourist != null)
            {
                return View(new TourSellingCreateOrEditViewModel
                {
                    TouristId = tourist.TouristId,
                    TouristName = tourist.Name,
                    TouristSurname = tourist.Surname,
                    Tours = _tourService.GetAll(),

                });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Index(int? id, TourSellingCreateOrEditViewModel tourSellingViewModel)
        {
            if (id != tourSellingViewModel.TouristId)
            {
                return NotFound();
            }
           
            try
            {                
                _touristService.UpdateForAddTours(id.Value, tourSellingViewModel.SelectedTours);
                return RedirectToAction(nameof(Index), nameof(Invoice));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TouristExists(tourSellingViewModel.TouristId))
                {
                    return NotFound();
                }
            }
            return View(tourSellingViewModel);
           
        }
        private bool TouristExists(int id)
        {
            return _touristService.GetById(id) != null;
        }
    }
}
