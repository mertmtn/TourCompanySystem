using FluentValidation;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Models.Validation
{
    public class PlaceValidator : AbstractValidator<PlaceCreateOrEditViewModel>
    {
        public PlaceValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen bölge ismi giriniz!").MaximumLength(30).WithMessage("Bölge ismi en fazla 30 karakter olabilir!");
            RuleFor(g => g.Price).NotNull().WithMessage("Lütfen bölge ücretini giriniz!").GreaterThanOrEqualTo(20).WithMessage("Bölge ücreti en az 20 TL olmalıdır!"); 
        }
    }
}
