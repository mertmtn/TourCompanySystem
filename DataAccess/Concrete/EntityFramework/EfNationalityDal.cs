using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNationalityDal : EfEntityRepositoryBase<Nationality, TourCompanyDbContext>, INationalityDal
    {
    }
}
