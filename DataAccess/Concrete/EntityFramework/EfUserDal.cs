using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, TourCompanyDbContext>, IUserDal
    {
        public void UpdateUserInfo(User user)
        {
            using (var context = new TourCompanyDbContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.Entry(user).Property(x => x.PasswordHash).IsModified = false;
                context.Entry(user).Property(x => x.PasswordSalt).IsModified = false;
                context.SaveChanges();
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new TourCompanyDbContext())
            {
                var result = from operationClaim in context.OperationClaim
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
