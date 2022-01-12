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

        public List<Guide> GetAll()
        {
            return _guideDal.GetAll();
        }

        public Guide GetById(int id)
        {
            return _guideDal.Get(g=>g.GuideId==id);
        }
    }
}
