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

        public IActionResult Index()
        {
            return View(_invoiceService.GetAllInvoice());
        }


        public IActionResult Details(string id)
        {
            if (id == null) return NotFound();            

            Invoice invoice = _invoiceService.GetAllInvoiceDetails(id);

            return (invoice != null) ? View(invoice) : NotFound(); 
        }
    }
}
