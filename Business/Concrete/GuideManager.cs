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
    public class GuideManager : IGuideService
    {
        private IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,guide.editorupdate")]
        [ValidationAspect(typeof(GuideValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Add(Guide guide, string[] selectedLanguages)
        {
            _guideDal.AddManyLanguages(guide, selectedLanguages);
            return new SuccessResult(GuideMessage.GuideAddedSuccessfully, 200);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,guide.editorupdate")]
        public void Delete(Guide guide)
        {
            _guideDal.DeleteManyLanguages(guide);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,guide.editorupdate,salesperson.editorupdate,guideuser,salesperson")]
        public List<Guide> GetAll()
        {
            return _guideDal.GetAll();
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,guide.editorupdate,salesperson.editorupdate,guideuser,salesperson")]
        public Guide GetById(int id)
        {
            return _guideDal.GetById(id);
        }

        [SecuredOperation("superadmin,superadmin.editorupdate,guideuser,guide.editorupdate")]
        [ValidationAspect(typeof(GuideValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Update(Guide guide, string[] selectedLanguages)
        {
            _guideDal.UpdateManyLanguages(guide, selectedLanguages);
            return new SuccessResult(GuideMessage.GuideUpdatedSuccessfully, 200);
        }
    }
}
