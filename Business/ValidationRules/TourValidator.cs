using FluentValidation;
using Entities.Concrete;
namespace TourCompany.Web.Models.Validation
{
    public class TourValidator : AbstractValidator<Tour>
    {
        public TourValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen tur ismi giriniz!").MaximumLength(150).WithMessage("Tur ismi en fazla 150 karakter olabilir!");
            RuleFor(g => g.TourDate).NotEmpty().WithMessage("Tur tarihini seçiniz!");
            RuleFor(g => g.GuideId).GreaterThan(0).WithMessage("Tur rehberini seçiniz!"); 
        }
    }
}
