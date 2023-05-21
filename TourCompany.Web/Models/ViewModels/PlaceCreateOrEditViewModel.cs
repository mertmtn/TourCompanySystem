namespace TourCompany.Web.Models.ViewModels
{
    public class PlaceCreateOrEditViewModel
    {
        public int PlaceId { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }  

        public bool IsActive { get; set; } 
    }
}