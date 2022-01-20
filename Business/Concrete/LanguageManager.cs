using Business.Abstract;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using DataAccess.Abstract;
using Entities.Concrete;
using TourCompany.Web.Models.Validation;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal placeDal)
        {
            _languageDal = placeDal;
        }

        [ValidationAspect(typeof(LanguageValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Add(Language language)
        {
            _languageDal.Add(language);
            return new SuccessResult(200);
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

        [ValidationAspect(typeof(LanguageValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Update(Language language)
        {
            _languageDal.Update(language);
            return new SuccessResult(200);
        }
    }
}
