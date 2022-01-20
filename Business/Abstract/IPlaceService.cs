using Core.Utilities.Results;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IPlaceService
    {
        List<Place> GetAll(Expression<Func<Place, bool>> filter = null);

        Place GetById(int id);

        IResult Add(Place place);
        
        IResult Update(Place place);

        void Delete(Place place);
    }
}
