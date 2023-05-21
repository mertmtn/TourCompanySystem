using Entities.DTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("Adı giriniz");
            RuleFor(x => x.LastName).NotNull().WithMessage("Soyadı giriniz");
            RuleFor(x => x.Password).NotNull().WithMessage("Parolayı giriniz").
                Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{1,8}$").WithMessage(@"Parola en fazla 8 karakterli, en az bir harf, rakam ve özel karakter içerebilir.");
            RuleFor(x => x.Email).NotNull().WithMessage("E-Posta giriniz").
                Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage(@"Geçerli bir mail adresi giriniz.");
        }
    }
}
