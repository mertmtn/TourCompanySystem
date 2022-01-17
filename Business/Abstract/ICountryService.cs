using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICountryService
    {
        List<Country> GetAll();

        Country GetById(int id);

        public void Add(Country country);

        public void Update(Country country);

        public void Delete(Country country);
    }
}
