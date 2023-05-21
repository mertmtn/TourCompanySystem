using Business.Abstract;
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

        [ValidationAspect(typeof(TourValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Add(Tour tour, string[] selectedPlaces)
        {
            _tourDal.AddManyPlaces(tour, selectedPlaces);
            return new SuccessResult(200);
        }

        public void Delete(Tour tour)
        {
            _tourDal.Delete(tour);
        }

        public List<Tour> GetAll()
        {
            return _tourDal.GetAllJoinedTours();
        }

        public Tour GetById(int id)
        {
            return _tourDal.GetById(id);
        }

        [ValidationAspect(typeof(TourValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Update(Tour tour, string[] selectedPlaces)
        {
            _tourDal.UpdateManyPlaces(tour, selectedPlaces);
            return new SuccessResult(200);
        }
    }
}
