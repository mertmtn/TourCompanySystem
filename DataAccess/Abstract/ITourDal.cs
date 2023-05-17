
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ITourDal : IEntityRepository<Tour>
    {
        void AddManyPlaces(Tour tour, string[] selectedPlaces);
        void UpdateManyPlaces(Tour tour, string[] selectedPlaces);

        Tour GetById(int id);
        public List<Tour> GetAllJoinedTours();
        public void DeleteManyPlaces(Tour tour);
    }
}
