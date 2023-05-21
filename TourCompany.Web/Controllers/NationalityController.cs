#nullable disable
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace TourCompany.Web.Controllers
{
    public class NationalityController : Controller
    {
        private readonly INationalityService _nationalityService;
        private readonly INotyfService _notyf;

        public NationalityController(INationalityService nationalityService, INotyfService notyf)
        {
            _nationalityService = nationalityService;
            _notyf = notyf;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_nationalityService.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var nationality = _nationalityService.GetById(id.Value);
            return (nationality != null) ? PartialView("~/Views/Nationality/Partials/Detail.cshtml", nationality) : NotFound();
        }

        public IActionResult Create()
        {
            return PartialView("~/Views/Nationality/Partials/Create.cshtml");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(NationalityCreateOrEditViewModel nationalityViewModel)
        {
            var result = _nationalityService.Add(new Nationality()
            {
                Name = nationalityViewModel.Name,
                IsActive = nationalityViewModel.IsActive
            });

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }

                return PartialView("~/Views/Place/Partials/Create.cshtml", nationalityViewModel);
            }

            return Json(result);
        }

        public IActionResult Edit(int? id)
        {
            var nationality = _nationalityService.GetById(id.Value);
            return (nationality != null) ? PartialView("~/Views/Place/Partials/Edit.cshtml", new NationalityCreateOrEditViewModel()
            {
                Name = nationality.Name,
                IsActive = nationality.IsActive,
                NationalityId = nationality.NationalityId
            }) : NotFound();

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, NationalityCreateOrEditViewModel nationalityViewModel)
        {
            var result = _nationalityService.Update(new Nationality()
            {
                Name = nationalityViewModel.Name,
                NationalityId = nationalityViewModel.NationalityId,
                IsActive = nationalityViewModel.IsActive
            });

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }

                return PartialView("~/Views/Nationality/Partials/Create.cshtml", nationalityViewModel);
            }

            return Json(result);
        }

        public IActionResult Delete(int? id)
        {
            var nationality = _nationalityService.GetById(id.Value);
            return (nationality != null) ? PartialView("~/Views/Nationality/Partials/Delete.cshtml", nationality) : NotFound();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var nationality = _nationalityService.GetById(id);
            _nationalityService.Delete(nationality);
            _notyf.Success("Silme işlemi başarılıdır.");
            return RedirectToAction(nameof(Index));
        }
    }
}
