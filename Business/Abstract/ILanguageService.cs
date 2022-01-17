using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        List<Language> GetAll();

        Language GetById(int id);

        public void Add(Language language);

        public void Update(Language language);

        public void Delete(Language language);
    }
}
