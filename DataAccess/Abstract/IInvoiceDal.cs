
using Core.DataAccess.Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IInvoiceDal : IEntityRepository<Invoice>
    {
        public List<Invoice> GetAllInvoice();
        public Invoice GetAllInvoiceDetails(string invoiceNo);
    }
}
