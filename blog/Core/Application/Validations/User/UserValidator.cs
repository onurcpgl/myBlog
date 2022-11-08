using Application.DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations.User
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.userName)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Kullanıcı adı boş olamaz.")
                .MaximumLength(35)
                .MinimumLength(5)
                    .WithMessage("Kullanıcı adı 5 ile 35 karakter arasında olmaldır.");

            RuleFor(user => user.lastName)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Kullanıcı soyadı boş olamaz.")
                .MaximumLength(35)
                .MinimumLength(5)
                    .WithMessage("Kullanıcı soyadı 5 ile 35 karakter arasında olmaldır.");

            RuleFor(user => user.firstName)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Kullanıcı ismi boş olamaz.")
                .MaximumLength(35)
                .MinimumLength(5)
                    .WithMessage("Kullanıcı ismi 5 ile 35 karakter arasında olmaldır.");

            RuleFor(user => user.password)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Şifre boş olamamlı.")
                .MaximumLength(35)
                .MinimumLength(5)
                    .WithMessage("Kullanıcı şifresi 5 ile 35 karakter arasında olmaldır.");



            RuleFor(user => user.emailAdress)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Email adresini boş geçmeyiniz.")
                .EmailAddress()
                    .WithMessage("Lütfen geçerli bir email adresi giriniz.");

        }
    }
}
