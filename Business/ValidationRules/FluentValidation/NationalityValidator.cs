using FluentValidation;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class NationalityValidator : AbstractValidator<Nationality>
    {
        public NationalityValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen uyruk ismi giriniz!").MaximumLength(20).WithMessage("Uyruk ismi en fazla 20 karakter olabilir!");
        }
    }
}
