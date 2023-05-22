using FluentValidation;
using Core.Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class ClaimValidator : AbstractValidator<OperationClaim>
    {
        public ClaimValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen rol ismi giriniz!");
        }         
    }
}
