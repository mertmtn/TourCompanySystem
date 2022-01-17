using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGuideService
    {
        List<Guide> GetAll();

        Guide GetById(int id);

        public void Add(Guide guide, string[] selectedLanguages);

        public void Update(Guide guide, string[] selectedLanguages);

        public void Delete(Guide guide);
    }
}
