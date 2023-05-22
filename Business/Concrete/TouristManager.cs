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
    public class TouristManager : ITouristService
    {
        private readonly ITouristDal _touristDal;

        public TouristManager(ITouristDal touristDal)
        {
            _touristDal = touristDal;
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,salesperson,salesperson.editorupdate")]
        [ValidationAspect(typeof(TouristValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Add(Tourist country)
        {
            _touristDal.Add(country);
            return new SuccessResult(TouristMessage.TouristAddedSuccessfully, 200);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,salesperson,salesperson.editorupdate")]
        public void Delete(Tourist country)
        {
            _touristDal.Delete(country);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,guide.editorupdate,salesperson.editorupdate,guideuser,salesperson")]
        public List<Tourist> GetAll()
        {
            return _touristDal.GetAllTouristDetail();
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,guide.editorupdate,salesperson.editorupdate,guideuser,salesperson")]
        public Tourist GetById(int id)
        {
            return _touristDal.GetAllTouristDetailById(id);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,salesperson,salesperson.editorupdate")]
        [ValidationAspect(typeof(TouristValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Update(Tourist tourist)
        {
            _touristDal.Update(tourist);
            return new SuccessResult(TouristMessage.TouristUpdatedSuccessfully, 200);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,salesperson,salesperson.editorupdate")]
        public void UpdateForAddTours(int touristId, string[] selectedtours)
        {
            _touristDal.UpdateForAddTours(touristId, selectedtours);
        }
    }
}
