using Business.Abstract;
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
    public class GuideManager : IGuideService
    {
        private IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        [ValidationAspect(typeof(GuideValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Add(Guide guide, string[] selectedLanguages)
        {
            _guideDal.AddManyLanguages(guide, selectedLanguages);
            return new SuccessResult(GuideMessage.GuideAddedSuccessfully, 200);
        }

        public void Delete(Guide guide)
        {
            _guideDal.DeleteManyLanguages(guide);
        }

        public List<Guide> GetAll()
        {
            return _guideDal.GetAll();
        }

        public Guide GetById(int id)
        {
            return _guideDal.GetById(id);
        }

        [ValidationAspect(typeof(GuideValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Update(Guide guide, string[] selectedLanguages)
        {
            _guideDal.UpdateManyLanguages(guide, selectedLanguages);
            return new SuccessResult(GuideMessage.GuideUpdatedSuccessfully, 200);
        }
    }
}
