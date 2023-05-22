#nullable disable
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace TourCompany.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PlaceController : Controller
    {
        private readonly IPlaceService _placeService;
        private readonly INotyfService _notyf;

        public PlaceController(IPlaceService placeService, INotyfService notyf)
        {
            _placeService = placeService;
            _notyf = notyf;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_placeService.GetAll());
        }

        [HttpGet]
        public IActionResult Detail(int? id)
        {
            var place = _placeService.GetById(id.Value);
            return (place != null) ? PartialView("~/Views/Place/Partials/Detail.cshtml", place) : NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("~/Views/Place/Partials/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PlaceCreateOrEditViewModel placeViewModel)
        {  
            var result = _placeService.Add(new()
            {
                IsActive = placeViewModel.IsActive,
                Name = placeViewModel.Name,
                Price = placeViewModel.Price.GetValueOrDefault()
            });

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }

                return PartialView("~/Views/Place/Partials/Create.cshtml", placeViewModel);
            }

            return Json(result); 
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var place = _placeService.GetById(id.Value);

            return (place != null) ? PartialView("~/Views/Place/Partials/Edit.cshtml", new PlaceCreateOrEditViewModel()
            {
                PlaceId = place.PlaceId,
                IsActive = place.IsActive,
                Name = place.Name,
                Price = place.Price
            }) : NotFound(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PlaceCreateOrEditViewModel placeViewModel)
        { 
            var result = _placeService.Update(new()
            {
                PlaceId = placeViewModel.PlaceId,
                IsActive = placeViewModel.IsActive,
                Name = placeViewModel.Name,
                Price = placeViewModel.Price.GetValueOrDefault()
            });

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }

                return PartialView("~/Views/Place/Partials/Edit.cshtml", placeViewModel);
            }

            return Json(result);
        } 

        public IActionResult Delete(int? id)
        { 
            var place = _placeService.GetById(id.Value);
            return (place != null) ? PartialView("~/Views/Place/Partials/Delete.cshtml", place) : NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var place = _placeService.GetById(id);
            _placeService.Delete(place);
            _notyf.Success("Silme işlemi başarılıdır.");
            return RedirectToAction(nameof(Index));
        } 
    }
}
