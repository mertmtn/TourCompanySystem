using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPlaceService
    {
        List<Place> GetAll();

        Place GetById(int id);

        public void Add(Place place);

        public void Update(Place place);

        public void Delete(Place place);
    }
}
