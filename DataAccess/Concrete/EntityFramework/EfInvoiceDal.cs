using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfInvoiceDal : EfEntityRepositoryBase<Invoice, TourCompanyDbContext>, IInvoiceDal
    {
        public List<Invoice> GetAllInvoice()
        {
            using (var context = new TourCompanyDbContext())
            {
                return context.Invoices.Include(i => i.Tourist).ToList();
            }
        }

        public Invoice GetAllInvoiceDetails(string invoiceNo)
        {
            using (var context = new TourCompanyDbContext())
            {
                return context.Invoices.Include(i => i.InvoiceDetails).ThenInclude(i => i.Tour).ThenInclude(p => p.Places).Include(x => x.Tourist)
                .FirstOrDefault(m => m.InvoiceNo == invoiceNo);
            }
        }
    }
}
