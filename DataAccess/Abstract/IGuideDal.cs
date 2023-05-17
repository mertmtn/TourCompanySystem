

using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IGuideDal : IEntityRepository<Guide>
    {
        public void AddManyLanguages(Guide guide, string[] selectedLanguages);
        public void UpdateManyLanguages(Guide guide, string[] selectedLanguages);
        Guide GetById(int id);

        public void DeleteManyLanguages(Guide guide);
    }
}
