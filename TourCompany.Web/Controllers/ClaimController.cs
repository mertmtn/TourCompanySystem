using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
