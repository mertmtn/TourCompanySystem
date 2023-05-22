#nullable disable
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace TourCompany.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GuideController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly IGuideService _guideService;
        private readonly INotyfService _notyf;

        public GuideController(ILanguageService languageService, IGuideService guideService, INotyfService notyf)
        {
            _languageService = languageService;
            _guideService = guideService;
            _notyf = notyf;
        }

        [HttpGet] 
        public IActionResult Index()
        {
            return View(_guideService.GetAll());
        }

        public IActionResult Detail(int? id)
        {
            var guide = _guideService.GetById(id.Value);
            return (guide != null) ? PartialView("~/Views/Guide/Partials/Detail.cshtml", guide) : NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("~/Views/Guide/Partials/Create.cshtml", new GuideCreateOrEditViewModel { Languages = _languageService.GetAll() });
        } 


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GuideCreateOrEditViewModel guideViewModel)
        {

            var result = _guideService.Add(new()
            {
                IsActive = guideViewModel.IsActive,
                Name = guideViewModel.Name,
                Surname = guideViewModel.Surname,
                PhoneNumber = guideViewModel.PhoneNumber,
                Gender = guideViewModel.Gender
            }, guideViewModel.SelectedLanguages);

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }

                guideViewModel.Languages = _languageService.GetAll();
                return PartialView("~/Views/Guide/Partials/Create.cshtml", guideViewModel);
            }

            return Json(result);
        }

        public IActionResult Edit(int? id)
        {
            var guide = _guideService.GetById(id.Value);

            return (guide != null) ?
              PartialView("~/Views/Guide/Partials/Edit.cshtml",new GuideCreateOrEditViewModel()
              {
                  Languages = _languageService.GetAll(),
                  SelectedLanguages = guide.Languages.Select(x => x.LanguageId.ToString()).ToArray(),
                  Gender = guide.Gender,
                  PhoneNumber = guide.PhoneNumber,
                  Name = guide.Name,
                  Surname = guide.Surname,
                  IsActive = guide.IsActive,
                  GuideId = guide.GuideId
              }) :
              NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, GuideCreateOrEditViewModel guideViewModel)
        {
            var result = _guideService.Update(new()
            {
                GuideId = guideViewModel.GuideId,
                IsActive = guideViewModel.IsActive,
                Name = guideViewModel.Name,
                Surname = guideViewModel.Surname,
                PhoneNumber = guideViewModel.PhoneNumber,
                Gender = guideViewModel.Gender
            }, guideViewModel.SelectedLanguages);

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }

                guideViewModel.Languages = _languageService.GetAll();
                return PartialView("~/Views/Guide/Partials/Edit.cshtml", guideViewModel);
            }

            return Json(result);
        }


        public IActionResult Delete(int? id)
        {
            var guide = _guideService.GetById(id.Value);
            return (guide != null) ? PartialView("~/Views/Guide/Partials/Delete.cshtml", guide) : NotFound();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var guide = _guideService.GetById(id);
            _guideService.Delete(guide);
            _notyf.Success("Silme işlemi başarılıdır.");
            return RedirectToAction(nameof(Index));
        }
    }
}