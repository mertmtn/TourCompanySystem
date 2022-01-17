﻿using FluentValidation;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Models.Validation
{
    public class TouristValidator : AbstractValidator<TouristCreateOrEditViewModel>
    {
        public TouristValidator()
        {            
            RuleFor(g => g.BirthDate).NotNull().WithMessage("Doğum tarihini seçiniz!");
            RuleFor(g => g.Name).NotEmpty().WithMessage("Lütfen isim giriniz!").MaximumLength(20).WithMessage("İsim en fazla 20 karakter olabilir!");
            RuleFor(g => g.Surname).NotEmpty().WithMessage("Lütfen soyadı giriniz!").MaximumLength(40).WithMessage("Soyadı en fazla 20 karakter olabilir!");
            RuleFor(g => g.Gender).NotEmpty().WithMessage("Lütfen cinsiyet seçiniz");
            RuleFor(g => g.CountryId).NotNull().WithMessage("Lütfen ülke seçiniz");
            RuleFor(g => g.NationalityId).NotNull().WithMessage("Lütfen uyruk seçiniz");
        }
    }
}
