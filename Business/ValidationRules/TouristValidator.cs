using FluentValidation;
using Entities.Concrete;

namespace TourCompany.Web.Models.Validation
{
    public class TouristValidator : AbstractValidator<Tourist>
    {
        public TouristValidator()
        {            
            RuleFor(g => g.BirthDate).NotEmpty().WithMessage("Doğum tarihini seçiniz!");
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen isim giriniz!").MaximumLength(20).WithMessage("İsim en fazla 20 karakter olabilir!");
            RuleFor(g => g.Surname).NotEmpty().WithMessage("Lütfen soyadı giriniz!").MaximumLength(40).WithMessage("Soyadı en fazla 20 karakter olabilir!");
            RuleFor(g => g.Gender).NotEmpty().WithMessage("Lütfen cinsiyet seçiniz");
            RuleFor(g => g.CountryId).GreaterThan(0).WithMessage("Lütfen ülke seçiniz");
            RuleFor(g => g.NationalityId).GreaterThan(0).WithMessage("Lütfen uyruk seçiniz");
        }
    }
}
