
using Core.DataAccess.Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICountryDal : IEntityRepository<Country>
    {
    }
}
