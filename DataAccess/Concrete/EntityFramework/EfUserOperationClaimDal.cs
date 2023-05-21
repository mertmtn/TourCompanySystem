using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Runtime.Intrinsics.Arm;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, TourCompanyDbContext>, IUserOperationClaimDal
    {
        public void UpdateClaimForUser(UserOperationClaim userOperationClaim, string[] selectedClaims)
        {
            using var context = new TourCompanyDbContext();            

            if (selectedClaims != null)
            {
                var userClaims = context.UserOperationClaims.Where(x => x.UserId == userOperationClaim.UserId);
                context.UserOperationClaims.RemoveRange(userClaims);
                context.SaveChanges();

                foreach (var claim in selectedClaims.ToList())
                {
                    context.UserOperationClaims.Add(new UserOperationClaim
                    {
                        UserId = userOperationClaim.UserId,
                        OperationClaimId = Convert.ToInt32(claim)
                    });
                }
                context.SaveChanges();
            } 
        }
    }
}
