#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using Business.Abstract;
using TourCompany.Web.Models.ViewModels;
using TourCompany.Web.Models.Validation;

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

            var result = new GuideValidator().Validate(guideViewModel);
            if (result.IsValid)
            {
                Guide guide = new()
                {
                    IsActive = guideViewModel.IsActive,
                    Name = guideViewModel.Name,
                    Surname = guideViewModel.Surname,
                    PhoneNumber = guideViewModel.PhoneNumber,
                    Gender = guideViewModel.Gender
                };

                _guideService.Add(guide, guideViewModel.SelectedLanguages);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }               
            }
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
            if (id != guideViewModel.GuideId)
            {
                return NotFound();
            }

            var result = new GuideValidator().Validate(guideViewModel);
            if (result.IsValid)
            {
                try
                {
                    Guide guide = new()
                    {
                        GuideId = guideViewModel.GuideId,
                        IsActive = guideViewModel.IsActive,
                        Name = guideViewModel.Name,
                        Surname = guideViewModel.Surname,
                        PhoneNumber = guideViewModel.PhoneNumber,
                        Gender = guideViewModel.Gender
                    };
                    _guideService.Update(guide, guideViewModel.SelectedLanguages);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuideExists(guideViewModel.GuideId))
                    {
                        return NotFound();
                    } 
                }
                return View(guideViewModel);                
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(guideViewModel);
            }           
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

        private bool GuideExists(int id)
        {
            return _guideService.GetById(id) != null;
        }
    }
}