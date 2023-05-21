using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Exception;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        [SecuredOperation("superadmin")]
        [ExceptionAspect(typeof(Result))]
        public IResult Add(OperationClaim claim)
        {
            _operationClaimDal.Add(claim);
            return new SuccessResult("Ekleme başarılıdır.",200);
        }

        [SecuredOperation("superadmin")]
        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }

        [SecuredOperation("superadmin")]
        public IDataResult<OperationClaim> GetById(int claimId)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(c => c.Id == claimId));
        } 
    }
}
