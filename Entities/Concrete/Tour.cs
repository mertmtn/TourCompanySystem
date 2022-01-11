using Core.Entities;

namespace Entities.Concrete
{
    public class Tour : IEntity
    {
        public int TourId { get; set; }

        public string Name { get; set; } //En fazla 150 karakter

        public bool IsActive { get; set; }
    }
}
