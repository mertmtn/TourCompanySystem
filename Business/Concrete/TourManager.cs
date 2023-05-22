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
    public class TourManager : ITourService
    {
        private readonly ITourDal _tourDal;

        public TourManager(ITourDal tourDal)
        {
            _tourDal = tourDal;
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,salesperson,salesperson.editorupdate")]
        [ValidationAspect(typeof(TourValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Add(Tour tour, string[] selectedPlaces)
        {
            _tourDal.AddManyPlaces(tour, selectedPlaces);
            return new SuccessResult(TourMessage.TourAddedSuccessfully, 200);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,salesperson,salesperson.editorupdate")]
        public void Delete(Tour tour)
        {
            _tourDal.Delete(tour);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,guide.editorupdate,salesperson.editorupdate,guideuser,salesperson")]
        public List<Tour> GetAll()
        {
            return _tourDal.GetAllJoinedTours();
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,guide.editorupdate,salesperson.editorupdate,guideuser,salesperson")]
        public Tour GetById(int id)
        {
            return _tourDal.GetById(id);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,salesperson,salesperson.editorupdate")]
        [ValidationAspect(typeof(TourValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Update(Tour tour, string[] selectedPlaces)
        {
            _tourDal.UpdateManyPlaces(tour, selectedPlaces);
            return new SuccessResult(TourMessage.TourUpdatedSuccessfully, 200);
        }
    }
}
