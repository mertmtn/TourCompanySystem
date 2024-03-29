﻿using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class GuideValidator : AbstractValidator<Guide>
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
