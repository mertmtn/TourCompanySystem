using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class NationalityManager : INationalityService
    {
        private readonly INationalityDal _nationalityDal;

        public NationalityManager(INationalityDal nationalityDal)
        {
            _nationalityDal = nationalityDal;
        }

        public void Add(Nationality nationality)
        {
            _nationalityDal.Add(nationality);
        }

        public void Delete(Nationality nationality)
        {
            _nationalityDal.Delete(nationality);
        }

        public List<Nationality> GetAll()
        {
           return _nationalityDal.GetAll();
        }

        public Nationality GetById(int id)
        {
            return _nationalityDal.Get(x=>x.NationalityId==id);
        }

        public void Update(Nationality nationality)
        {
            _nationalityDal.Update(nationality);
        }
    }
}
