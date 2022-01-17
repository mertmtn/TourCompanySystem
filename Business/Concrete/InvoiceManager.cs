using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceDal _invoiceDal;

        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }

        public List<Invoice> GetAllInvoice()
        {
            return _invoiceDal.GetAllInvoice();
        }

        public Invoice GetAllInvoiceDetails(string invoiceNo)
        {
            return _invoiceDal.GetAllInvoiceDetails(invoiceNo);
        }
    }
}
