using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TourCompany.Web.Controllers
{
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
