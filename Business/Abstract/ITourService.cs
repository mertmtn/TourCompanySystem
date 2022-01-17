using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITourService
    {
        List<Tour> GetAll();

        Tour GetById(int id);

        public void Add(Tour tour, string[] selectedPlaces);

        public void Update(Tour tour, string[] selectedPlaces);

        public void Delete(Tour tour);
    }
}
