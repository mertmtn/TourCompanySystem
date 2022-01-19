using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Entities.Concrete;
using TourCompany.Web.Models.Validation;

namespace Business.Abstract
{
    public interface ICountryService
    {
        List<Country> GetAll();

        Country GetById(int id);


        IResult Add(Country country);

        IResult Update(Country country);

        void Delete(Country country);
    }
}
