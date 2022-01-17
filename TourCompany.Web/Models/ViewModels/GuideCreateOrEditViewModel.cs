using Entities.Concrete;

namespace TourCompany.Web.Models.ViewModels
{
    public class GuideCreateOrEditViewModel
    {
        public GuideCreateOrEditViewModel() => Languages = new List<Language>();

        public int GuideId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public char Gender { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public string[] SelectedLanguages { get; set; }

        public ICollection<Language> Languages { get; set; }
        
    }
}
