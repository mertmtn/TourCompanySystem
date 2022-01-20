#nullable disable
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Controllers
{
    public class GuideController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly IGuideService _guideService;

        public GuideController(ILanguageService languageService, IGuideService guideService)
        {
            _languageService = languageService;
            _guideService = guideService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_guideService.GetAll());
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            Guide guide = _guideService.GetById(id.Value);
            return (guide != null) ? View(guide) : NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new GuideCreateOrEditViewModel { Languages = _languageService.GetAll() });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GuideCreateOrEditViewModel guideViewModel)
        {
            Guide guide = new()
            {
                IsActive = guideViewModel.IsActive,
                Name = guideViewModel.Name,
                Surname = guideViewModel.Surname,
                PhoneNumber = guideViewModel.PhoneNumber,
                Gender = guideViewModel.Gender
            };

            var result = _guideService.Add(guide, guideViewModel.SelectedLanguages);
            if (result.StatusCode == 200) return RedirectToAction(nameof(Index));

            foreach (var message in result.MessageList)
            {
                ModelState.AddModelError(message.Key, message.Value);
            }
            guideViewModel.Languages = _languageService.GetAll();
            return View(guideViewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            Guide guide = _guideService.GetById(id.Value);

            if (guide != null)
            {
                return View(new GuideCreateOrEditViewModel()
                {
                    Languages = _languageService.GetAll(),
                    SelectedLanguages = guide.Languages.Select(x => x.LanguageId.ToString()).ToArray(),
                    Gender = guide.Gender,
                    PhoneNumber = guide.PhoneNumber,
                    Name = guide.Name,
                    Surname = guide.Surname,
                    IsActive = guide.IsActive,
                    GuideId = guide.GuideId
                });
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, GuideCreateOrEditViewModel guideViewModel)
        {
            if (id != guideViewModel.GuideId) return NotFound();

            Guide guide = new()
            {
                GuideId = guideViewModel.GuideId,
                IsActive = guideViewModel.IsActive,
                Name = guideViewModel.Name,
                Surname = guideViewModel.Surname,
                PhoneNumber = guideViewModel.PhoneNumber,
                Gender = guideViewModel.Gender
            };
            
            var result = _guideService.Update(guide, guideViewModel.SelectedLanguages);
            if (result.StatusCode == 200) return RedirectToAction(nameof(Index));

            foreach (var message in result.MessageList)
            {
                ModelState.AddModelError(message.Key, message.Value);
            }
            guideViewModel.Languages = _languageService.GetAll();
            return View(guideViewModel);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Guide guide = _guideService.GetById(id.Value);

            return (guide != null) ? View(guide) : NotFound();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Guide guide = _guideService.GetById(id);
            _guideService.Delete(guide);
            return RedirectToAction(nameof(Index));
        } 
    }
}