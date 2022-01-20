#nullable disable
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Controllers
{
    public class NationalityController : Controller
    {
        private readonly INationalityService _nationalityService;

        public NationalityController(INationalityService nationalityService)
        {
            _nationalityService = nationalityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_nationalityService.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            Nationality nationality = _nationalityService.GetById(id.Value);

            return (nationality != null) ? PartialView("~/Views/Nationality/Partials/Detail.cshtml", nationality) : NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NationalityCreateOrEditViewModel nationalityViewModel)
        {
            var result = _nationalityService.Add(new Nationality()
            {
                Name = nationalityViewModel.Name,
                IsActive = nationalityViewModel.IsActive
            });
            if (result.StatusCode == 200) return RedirectToAction(nameof(Index));

            foreach (var message in result.MessageList)
            {
                ModelState.AddModelError(message.Key, message.Value);
            }

            return View(nationalityViewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            Nationality nationality = _nationalityService.GetById(id.Value);

            if (nationality != null)
            {
                return View(new NationalityCreateOrEditViewModel()
                {
                    Name = nationality.Name,
                    IsActive = nationality.IsActive,
                    NationalityId = nationality.NationalityId
                });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, NationalityCreateOrEditViewModel nationalityViewModel)
        {
            if (id != nationalityViewModel.NationalityId) return NotFound();

            var result = _nationalityService.Update(new Nationality()
            {
                Name = nationalityViewModel.Name,
                NationalityId = nationalityViewModel.NationalityId,
                IsActive = nationalityViewModel.IsActive
            });
            
            if (result.StatusCode == 200) return RedirectToAction(nameof(Index));

            foreach (var message in result.MessageList)
            {
                ModelState.AddModelError(message.Key, message.Value);
            }
            return View(nationalityViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Nationality nationality = _nationalityService.GetById(id.Value);

            return (nationality != null) ? PartialView("~/Views/Nationality/Partials/Delete.cshtml", nationality) : NotFound();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Nationality nationality = _nationalityService.GetById(id);
            _nationalityService.Delete(nationality);
            return RedirectToAction(nameof(Index));
        }
    }
}
