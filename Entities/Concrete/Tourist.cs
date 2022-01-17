using Core.Entities;

namespace Entities.Concrete
{
    public class Tourist:IEntity
    {
        public Tourist()
        {
            Tours = new HashSet<Tour>();            
        }

        public int TouristId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public char Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public int CountryId { get; set; }

        public int NationalityId { get; set; }

        public Country Country { get; set; }

        public Nationality Nationality { get; set; }

        public ICollection<Tour> Tours { get; set; }

        public Invoice Invoice { get; set; }
    }
}
