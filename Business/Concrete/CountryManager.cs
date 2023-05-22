using Business.Abstract;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using Business.ValidationRules.FluentValidation;
using Business.Constants.Messages;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }


        [SecuredOperation("superadmin,superadmin.editorupdate")]
        [ValidationAspect(typeof(CountryValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Add(Country country)
        {
            _countryDal.Add(country);
            return new SuccessResult(CountryMessage.CountryAddedSuccessfully, 200);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate")]
        public void Delete(Country country)
        {
            _countryDal.Delete(country);
        }

    
        public List<Country> GetAll()
        {
            return _countryDal.GetAll();
        }

  
        public Country GetById(int id)
        {
            return _countryDal.Get(p => p.CountryId == id);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate")]
        [ValidationAspect(typeof(CountryValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult(CountryMessage.CountryUpdatedSuccessfully, 200);
        }
    }
}
