using FluentValidation;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Models.Validation
{
    public class TourValidator : AbstractValidator<TourCreateOrEditViewModel>
    {
        public TourValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen tur ismi giriniz!").MaximumLength(150).WithMessage("Tur ismi en fazla 150 karakter olabilir!");
            RuleFor(g => g.TourDate).NotNull().WithMessage("Tur tarihini seçiniz!");
            RuleFor(g => g.GuideId).NotNull().WithMessage("Tur rehberini seçiniz!");
            RuleFor(g => g.SelectedPlaces).NotEmpty().WithMessage("Lütfen tur için en az bir bölge seçiniz!");
        }
    }
}
