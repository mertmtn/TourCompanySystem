using Core.Entities;

namespace Entities.Concrete
{
    public class Country : IEntity
    {
        public int CountryId { get; set; }

        public string Name { get; set; }
    }
}
