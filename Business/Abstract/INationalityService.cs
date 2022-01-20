using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface INationalityService
    {
        List<Nationality> GetAll();

        Nationality GetById(int id);

        IResult Add(Nationality nationality);

        IResult Update(Nationality nationality);

        void Delete(Nationality nationality);
    }
}
