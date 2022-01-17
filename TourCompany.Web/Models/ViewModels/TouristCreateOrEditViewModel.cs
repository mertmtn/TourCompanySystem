using Entities.Concrete;

namespace TourCompany.Web.Models.ViewModels
{
    public class TouristCreateOrEditViewModel
    {
        public TouristCreateOrEditViewModel()
        {
            Countries=new List<Country>();
            Nationalities=new List<Nationality>();
        }

        public int TouristId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public char Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public ICollection<Country> Countries { get; set; }
        public ICollection<Nationality> Nationalities { get; set; }

        public int? CountryId { get; set; }

        public int? NationalityId { get; set; }
    }
}
