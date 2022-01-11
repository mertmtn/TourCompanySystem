using Core.Entities;

namespace Entities.Concrete
{
    public class Invoice:IEntity
    {
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal Price { get; set; }

        public int TouristId { get; set; }
    }
}
