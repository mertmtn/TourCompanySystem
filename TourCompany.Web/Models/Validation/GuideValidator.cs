using FluentValidation;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Models.Validation
{
    public class GuideValidator : AbstractValidator<GuideCreateOrEditViewModel>
    {
        public GuideValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen isim giriniz!").MaximumLength(20).WithMessage("İsim en fazla 20 karakter olabilir!");
            RuleFor(g => g.Surname).NotEmpty().WithMessage("Lütfen soyadı giriniz!").MaximumLength(40).WithMessage("Soyadı en fazla 20 karakter olabilir!");
            RuleFor(g => g.Gender).NotEmpty().WithMessage("Lütfen cinsiyet seçiniz");
            RuleFor(g => g.PhoneNumber).NotEmpty().WithMessage("Lütfen telefon numarası giriniz!").MaximumLength(20).WithMessage("Telefon en fazla 20 karakter olabilir!");
        }
    }

}
