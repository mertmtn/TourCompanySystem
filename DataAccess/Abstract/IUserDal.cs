using Core.DataAccess;
using Core.Entities.Concrete;

namespace Data.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);

        List<OperationClaim> GetClaimsByUserId(int userId);
        void UpdateUserInfo(User user);
    }
}
