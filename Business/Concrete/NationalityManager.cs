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
    public class NationalityManager : INationalityService
    {
        private readonly INationalityDal _nationalityDal;

        public NationalityManager(INationalityDal nationalityDal)
        {
            _nationalityDal = nationalityDal;
        }

        [SecuredOperation("superadmin,superadmin.editorupdate")]
        [ValidationAspect(typeof(NationalityValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Add(Nationality nationality)
        {
            _nationalityDal.Add(nationality);
            return new SuccessResult(NationalityMessage.NationalityAddedSuccessfully, 200);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate")]
        public void Delete(Nationality nationality)
        {
            _nationalityDal.Delete(nationality);
        }

 
        public List<Nationality> GetAll()
        {
           return _nationalityDal.GetAll();
        }

       
        public Nationality GetById(int id)
        {
            return _nationalityDal.Get(x=>x.NationalityId==id);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate")]
        [ValidationAspect(typeof(NationalityValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Update(Nationality nationality)
        {
            _nationalityDal.Update(nationality);
            return new SuccessResult(NationalityMessage.NationalityUpdatedSuccessfully, 200);
        }
    }
}
