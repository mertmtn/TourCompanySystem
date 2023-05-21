using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        public void UpdateClaimForUser(UserOperationClaim userOperationClaim, string[] selectedClaims);
    }
}