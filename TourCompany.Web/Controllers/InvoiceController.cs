#nullable disable
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace TourCompany.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public ActionResult Index()
        {
            var invoiceList = _invoiceService.GetAllInvoice();
            return View(invoiceList);
        }


        public IActionResult Detail(string id)
        {
            if (id == null) return NotFound();            

            Invoice invoice = _invoiceService.GetAllInvoiceDetails(id);

            return (invoice != null) ? View(invoice) : NotFound(); 
        }
    }
}
