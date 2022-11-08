using Application.DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations.Login
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        
        public LoginValidator()
        {
            RuleFor(loginUser => loginUser.password)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen şifrenizi giriniz.")
                .MaximumLength(35)
                .MinimumLength(5)
                    .WithMessage("Lütfen geçerli bir şifre giriniz.");

            RuleFor(loginUser => loginUser.emailAdress)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Email adresini boş geçmeyiniz.")
                .EmailAddress()
                    .WithMessage("Lütfen geçerli bir email adresi giriniz.");

        }
    }
}
