using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class GuideManager : IGuideService
    {
        private IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void Add(Guide guide, string[] selectedLanguages)
        {
            _guideDal.AddManyLanguages(guide, selectedLanguages);
        }

        public void Delete(Guide guide)
        {
            _guideDal.DeleteManyLanguages(guide);
        }

        public List<Guide> GetAll()
        {
            return _guideDal.GetAll();
        }

        public Guide GetById(int id)
        {
            return _guideDal.GetById(id);
        }

        public void Update(Guide guide, string[] selectedLanguages)
        {
            _guideDal.UpdateManyLanguages(guide, selectedLanguages);
        }
    }
}
