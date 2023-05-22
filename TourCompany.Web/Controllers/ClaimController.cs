using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
   
    public class ClaimController : Controller
    {
        private readonly IOperationClaimService _operationClaimService;

        public ClaimController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        public IActionResult Index()
        {
            return View(_operationClaimService.GetAll().Data );
        }

        public IActionResult Create()
        {
            return PartialView("~/Views/Claim/Partials/Create.cshtml");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(ClaimCreateViewModel claimViewModel)
        {
            var result = _operationClaimService.Add(new ()
            {
                Name = claimViewModel.Name
            });

            if (result.StatusCode == 400)
            {
                foreach (var message in result.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }

                return PartialView("~/Views/Claim/Partials/Create.cshtml", claimViewModel);
            }

            return Json(result);
        }
    }
}
