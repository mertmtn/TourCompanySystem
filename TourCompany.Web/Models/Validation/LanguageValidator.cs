using FluentValidation;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Models.Validation
{
    public class LanguageValidator : AbstractValidator<LanguageCreateOrEditViewModel>
    {
        public LanguageValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen dil ismi giriniz!").MaximumLength(20).WithMessage("Dil ismi en fazla 20 karakter olabilir!");
        }
    }
}
