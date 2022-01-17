using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal placeDal)
        {
            _languageDal = placeDal;
        }

        public void Add(Language language)
        {
            _languageDal.Add(language);
        }

        public void Delete(Language language)
        {
            _languageDal.Delete(language);
        }

        public List<Language> GetAll()
        {
            return _languageDal.GetAll();
        }

        public Language GetById(int id)
        {
            return _languageDal.Get(p => p.LanguageId == id);
        }

        public void Update(Language language)
        {
            _languageDal.Update(language);
        }
    }
}
