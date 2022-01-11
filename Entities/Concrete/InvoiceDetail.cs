using Core.Entities;

namespace Entities.Concrete
{
    public class InvoiceDetail : IEntity
    {
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }

        public int TourId { get; set; }
    }
}
