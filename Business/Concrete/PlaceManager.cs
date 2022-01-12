using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PlaceManager : IPlaceService
    {
        private IPlaceDal _placeDal;

        public PlaceManager(IPlaceDal placeDal)
        {
            _placeDal = placeDal;
        }

        public void Add(Place place)
        {
            _placeDal.Add(place);
        }

        public void Delete(Place place)
        {
            _placeDal.Delete(place);
        }

        public List<Place> GetAll()
        {
            return _placeDal.GetAll();
        }

        public Place GetById(int id)
        {
            return _placeDal.Get(p => p.PlaceId == id);
        }

        public void Update(Place place)
        {
            _placeDal.Update(place);
        }
    }
}
