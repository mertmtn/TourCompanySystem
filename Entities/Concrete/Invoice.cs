using Core.Entities;

namespace Entities.Concrete
{
    public class Invoice : IEntity
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int TouristId { get; set; }

        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public Tourist Tourist { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set;}

    }

    public class InvoiceDetail : IEntity
    {
        public int TourId { get; set; }

        public string InvoiceNo { get; set; }

        public double Discount { get; set; }

        public decimal Price { get; set; }

        public Invoice Invoice { get; set; }
        public Tour Tour { get; set; }

    }
}
