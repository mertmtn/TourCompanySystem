using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITourService
    {
        List<Tour> GetAll();

        Tour GetById(int id);

        IResult Add(Tour tour, string[] selectedPlaces);

        IResult Update(Tour tour, string[] selectedPlaces);

        void Delete(Tour tour);
    }
}
