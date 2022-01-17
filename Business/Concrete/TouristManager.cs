using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TouristManager : ITouristService
    {
        private readonly ITouristDal _touristDal;

        public TouristManager(ITouristDal touristDal)
        {
            _touristDal = touristDal;
        }

        public void Add(Tourist country)
        {
            _touristDal.Add(country);
        }

        public void Delete(Tourist country)
        {
            _touristDal.Delete(country);
        }

        public List<Tourist> GetAll()
        {
            return _touristDal.GetAllTouristDetail();
        }

        public Tourist GetById(int id)
        {
            return _touristDal.GetAllTouristDetailById(id);
        }

        public void Update(Tourist tourist)
        {
            _touristDal.Update(tourist);
        }

        public void UpdateForAddTours(int touristId, string[] selectedtours)
        {
            _touristDal.UpdateForAddTours(touristId, selectedtours);
        }
    }
}
