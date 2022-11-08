using Application.DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations.Category
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen kategori adını giriniz.")
                .MinimumLength(5)
                .MaximumLength(50)
                    .WithMessage("Kategori adı 5 ile 50 karakter arasında olmalıdır.");

            RuleFor(category => category.Description)
               .NotEmpty()
               .NotNull()
                   .WithMessage("Lütfen kategori açıklamasını boş bırakmayınız.")
               .MinimumLength(5)
               .MaximumLength(250)
                   .WithMessage("Kategori açıklaması 5 ile 250 karakter arasında olmalıdır.");

            RuleFor(category => category.Level)
               .NotEmpty()
               .NotNull()
                   .WithMessage("Lütfen kategorinin seviyesini giriniz.");            
        }
    }
}
