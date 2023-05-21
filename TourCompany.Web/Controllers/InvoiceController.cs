#nullable disable
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;

namespace TourCompany.Web.Controllers
{
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
