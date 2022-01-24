using FluentValidation;
using Entities.Concrete;

namespace TourCompany.Web.Models.Validation
{
    public class PlaceValidator : AbstractValidator<Place>
    {
        public PlaceValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen bölge ismi giriniz!").MaximumLength(30).WithMessage("Bölge ismi en fazla 30 karakter olabilir!");
            RuleFor(g => g.Price).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Lütfen bölge ücretini giriniz!").GreaterThanOrEqualTo(20).WithMessage("Bölge ücreti en az 20 TL olmalıdır!"); 
        }
    }
}
