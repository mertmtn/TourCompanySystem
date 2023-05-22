using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult UpdateClaimForUser(UserOperationClaim userOperationClaim, string[] selectedClaims)
        {
            _userOperationClaimDal.UpdateClaimForUser(userOperationClaim, selectedClaims);
            return new SuccessResult("Kullanıcı rolleri güncellendi.");
        }
    }
}
