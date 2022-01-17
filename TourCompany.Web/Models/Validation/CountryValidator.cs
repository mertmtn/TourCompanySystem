using FluentValidation;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Models.Validation
{
    public class CountryValidator : AbstractValidator<CountryCreateOrEditViewModel>
    {
        public CountryValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen ülke ismi giriniz!").MaximumLength(20).WithMessage("Ülke ismi en fazla 20 karakter olabilir!");
        }
    }

}
