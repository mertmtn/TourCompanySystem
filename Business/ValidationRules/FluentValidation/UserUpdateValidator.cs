using Entities.DTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserUpdateValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserUpdateValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("Adı giriniz");
            RuleFor(x => x.LastName).NotNull().WithMessage("Soyadı giriniz");            
            RuleFor(x => x.Email).NotNull().WithMessage("E-Posta giriniz").
                Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage(@"Geçerli bir mail adresi giriniz.");
        }
    }
}
