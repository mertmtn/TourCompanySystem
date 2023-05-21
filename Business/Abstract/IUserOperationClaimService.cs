
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{

    public interface IUserOperationClaimService
    {
        IResult AddClaimForUser(UserOperationClaim userOperationClaim);
        IResult RemoveClaimForUser(UserOperationClaim userOperationClaim);
    }
}
