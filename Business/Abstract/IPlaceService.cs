using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IPlaceService
    {
        List<Place> GetAll(Expression<Func<Place, bool>> filter = null);

        Place GetById(int id);

        public void Add(Place place);

        public void Update(Place place);

        public void Delete(Place place);
    }
}
