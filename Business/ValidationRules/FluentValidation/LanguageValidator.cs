using FluentValidation;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen dil ismi giriniz!").MaximumLength(20).WithMessage("Dil ismi en fazla 20 karakter olabilir!");
        }
    }
}
