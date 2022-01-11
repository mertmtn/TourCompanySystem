using Core.Entities;

namespace Entities.Concrete
{
    public class TourDetail : IEntity
    {
        public int TourDetailId { get; set; }

        public DateTime TourDate { get; set; }

        public int TourId { get; set; }

        public int TouristId { get; set; }

        public int GuideId { get; set; }

        public bool IsActive { get; set; }
    }
}
