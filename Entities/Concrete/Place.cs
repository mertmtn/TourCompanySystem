using Core.Entities;

namespace Entities.Concrete
{
    public class Place : IEntity
    {
        public Place()
        {
            Tours = new HashSet<Tour>();

        }
        public int PlaceId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; } //Min 20 TL

        public bool IsActive { get; set; }

        public ICollection<Tour> Tours { get; set; }
    }
}
