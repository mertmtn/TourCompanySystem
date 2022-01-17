using FluentValidation;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Models.Validation
{
    public class NationalityValidator : AbstractValidator<NationalityCreateOrEditViewModel>
    {
        public NationalityValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen uyruk ismi giriniz!").MaximumLength(20).WithMessage("Uyruk ismi en fazla 20 karakter olabilir!");
        }
    }
}
