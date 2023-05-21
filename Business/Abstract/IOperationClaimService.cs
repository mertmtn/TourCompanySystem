
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IDataResult<OperationClaim> GetById(int claimId);
        IDataResult<List<OperationClaim>> GetAll();
        IResult Add(OperationClaim claim);
        IResult Update(OperationClaim claim); 
    }
}
