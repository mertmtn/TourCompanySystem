using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TourManager : ITourService
    {
        private readonly ITourDal _tourDal;

        public TourManager(ITourDal tourDal)
        {
            _tourDal = tourDal;
        }

        public void Add(Tour tour, string[] selectedPlaces)
        {
            _tourDal.AddManyPlaces(tour, selectedPlaces);
        }

        public void Delete(Tour tour)
        {
            _tourDal.Delete(tour);
        }

        public List<Tour> GetAll()
        {
            return _tourDal.GetAllJoinedTours();
        }

        public Tour GetById(int id)
        {
            return _tourDal.GetById(id);
        }

        public void Update(Tour tour, string[] selectedPlaces)
        {
            _tourDal.UpdateManyPlaces(tour, selectedPlaces);
        }
    }
}
