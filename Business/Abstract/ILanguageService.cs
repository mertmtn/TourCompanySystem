using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        List<Language> GetAll();

        Language GetById(int id);

        IResult Add(Language language);

        IResult Update(Language language);

        void Delete(Language language);
    }
}
