using Core.Entities;

namespace Entities.Concrete
{
    public class Country : IEntity
    {
        public Country()
        {
            Tourists = new HashSet<Tourist>();
        }

        public int CountryId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Tourist> Tourists { get; set; }
    }
}
