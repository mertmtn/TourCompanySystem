using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        public ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal placeDal)
        {
            _languageDal = placeDal;
        }

        [SecuredOperation("superadmin,superadmin.editorupdate")]
        [ValidationAspect(typeof(LanguageValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Add(Language language)
        {
            _languageDal.Add(language);
            return new SuccessResult(LanguageMessage.LanguageAddedSuccessfully, 200);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate")]
        public void Delete(Language language)
        {
            _languageDal.Delete(language);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,guide.editorupdate,salesperson.editorupdate,guideuser,salesperson")]
        public List<Language> GetAll()
        {
            return _languageDal.GetAll();
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,guide.editorupdate,salesperson.editorupdate,guideuser,salesperson")]
        public Language GetById(int id)
        {
            return _languageDal.Get(p => p.LanguageId == id);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate")]
        [ValidationAspect(typeof(LanguageValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Update(Language language)
        {
            _languageDal.Update(language);
            return new SuccessResult(LanguageMessage.LanguageUpdatedSuccessfully, 200);
        }
    }
}
