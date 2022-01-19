using Entities.Concrete;
using FluentValidation; 

namespace TourCompany.Web.Models.Validation
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen ülke ismi giriniz!").MaximumLength(20).WithMessage("Ülke ismi en fazla 20 karakter olabilir!");
        }
    }

}
