using Entities.Concrete;

namespace TourCompany.Web.Models.ViewModels
{
    public class TourCreateOrEditViewModel
    {
        public TourCreateOrEditViewModel()
        {
            Places = new List<Place>();
            Guides = new List<Guide>();
        }
        public int TourId { get; set; }
        public int? GuideId { get; set; }
        public string GuideName { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string[] SelectedPlaces { get; set; }

        public DateTime? TourDate { get; set; }

        public ICollection<Place> Places { get; set; }

        public ICollection<Guide> Guides { get; set; }
    }
}