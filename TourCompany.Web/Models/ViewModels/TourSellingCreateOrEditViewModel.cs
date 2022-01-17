using Entities.Concrete;

namespace TourCompany.Web.Models.ViewModels
{
    public class TourSellingCreateOrEditViewModel
    {
        public TourSellingCreateOrEditViewModel() => Tours = new List<Tour>();
        public int TouristId { get; set; }

        public string TouristName { get; set; }

        public string TouristSurname { get; set; }

        public string[] SelectedTours { get; set; } 

        public ICollection<Tour> Tours { get; set; }
    }
}