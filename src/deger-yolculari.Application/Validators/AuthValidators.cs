using deger_yolculari.Application.DTOs.Auth;
using FluentValidation;

namespace deger_yolculari.Application.Validators;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Ad soyad zorunludur.")
            .MinimumLength(3).WithMessage("Ad soyad en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Ad soyad en fazla 100 karakter olabilir.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta zorunludur.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
            .MaximumLength(256);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre zorunludur.")
            .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
            .Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
            .Matches(@"[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
            .Matches(@"[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
            .Matches(@"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]")
            .WithMessage("Şifre en az bir özel karakter içermelidir.");


        RuleFor(x => x.PhoneNumber)
            .Must(phone => phone == null || System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[5]\d{9}$"))
            .WithMessage("Geçerli bir telefon numarası giriniz. Örnek: 5551234567")
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber));
    }
}

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta zorunludur.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre zorunludur.");
    }
}

public class ChangePasswordValidator : AbstractValidator<ChangePasswordDto>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.CurrentPassword)
            .NotEmpty().WithMessage("Mevcut şifre zorunludur.");

        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("Yeni şifre zorunludur.")
            .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
            .Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
            .Matches(@"[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
            .NotEqual(x => x.CurrentPassword)
            .WithMessage("Yeni şifre mevcut şifreden farklı olmalıdır.");
    }
}

public class UserProfileValidator : AbstractValidator<UserProfileDto>
{
    public UserProfileValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .Matches(@"^05\d{2} \d{3} \d{2} \d{2}$")
            .WithMessage("Telefon Numarası (05xx xxx xx xx) şeklinde olmalıdır.")
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber));
    }
}