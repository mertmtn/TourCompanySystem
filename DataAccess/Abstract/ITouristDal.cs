
using Core.DataAccess.Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ITouristDal : IEntityRepository<Tourist>
    {
        public void UpdateForAddTours(int touristId, string[] selectedtours);

        public List<Tourist> GetAllTouristDetail();
        public Tourist GetAllTouristDetailById(int touristId);
    }
}
