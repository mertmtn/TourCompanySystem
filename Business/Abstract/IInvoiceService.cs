using Entities.Concrete;

namespace Business.Abstract
{
    public interface IInvoiceService
    {
        List<Invoice> GetAllInvoice();

        public Invoice GetAllInvoiceDetails(string invoiceNo);
    }
}
