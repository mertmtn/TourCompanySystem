using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGuideService
    {
        List<Guide> GetAll();

        Guide GetById(int id);

        IResult Add(Guide guide, string[] selectedLanguages);

        IResult Update(Guide guide, string[] selectedLanguages);

        public void Delete(Guide guide);
    }
}
