using Core.Entities;

namespace Entities.Concrete
{
    public class Tourist:IEntity
    {
        public int TouristId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public char Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public int CountryId { get; set; }

        public int NationalityId { get; set; }
    }
}
