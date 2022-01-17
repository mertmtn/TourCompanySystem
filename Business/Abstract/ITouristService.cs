using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITouristService
    {
        List<Tourist> GetAll();

        Tourist GetById(int id);

        public void Add(Tourist tourist);

        public void Update(Tourist tourist);

        public void UpdateForAddTours(int touristId, string[] selectedtours);

        public void Delete(Tourist tourist);
    }
}
