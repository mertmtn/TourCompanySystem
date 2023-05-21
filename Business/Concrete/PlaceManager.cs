using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class PlaceManager : IPlaceService
    {
        private IPlaceDal _placeDal;

        public PlaceManager(IPlaceDal placeDal)
        {
            _placeDal = placeDal;
        }


        [ValidationAspect(typeof(PlaceValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Add(Place place)
        {
            _placeDal.Add(place);
            return new SuccessResult("Bölge başarıyla eklendi.", 200);
        }

        public void Delete(Place place)
        {
            _placeDal.Delete(place);
        } 
        
        public List<Place> GetAll(Expression<Func<Place, bool>> filter = null)
        {
            return _placeDal.GetAll(filter);
        }

        public Place GetById(int id)
        {
            return _placeDal.Get(p => p.PlaceId == id);
        }


        [ValidationAspect(typeof(PlaceValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Update(Place place)
        {
            _placeDal.Update(place);
            return new SuccessResult("Bölge başarıyla güncellendi.", 200);
        }
    }
}
