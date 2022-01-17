using Core.Entities;

namespace Entities.Concrete
{
    public class Tour : IEntity
    {
        public Tour()       
        {
            Tourists = new HashSet<Tourist>();
            Places = new HashSet<Place>();
        }

        public int TourId { get; set; }
        public int GuideId { get; set; }
        public string Name { get; set; }  
        public DateTime TourDate { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Tourist> Tourists { get; set; }
        public ICollection<Place> Places { get; set; }
        public InvoiceDetail InvoiceDetail { get; set; }
        public Guide Guide { get; set; }
    }
}
