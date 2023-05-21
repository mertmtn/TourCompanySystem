
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{

    public interface IUserOperationClaimService
    {
        IResult UpdateClaimForUser(UserOperationClaim userOperationClaim, string[] selectedClaims); 
    }
}
