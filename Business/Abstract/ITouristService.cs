using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITouristService
    {
        List<Tourist> GetAll();

        Tourist GetById(int id);

        IResult Add(Tourist tourist);

        IResult Update(Tourist tourist);

        void UpdateForAddTours(int touristId, string[] selectedtours);

        void Delete(Tourist tourist);
    }
}
