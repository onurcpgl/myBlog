using Application.DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations.Article
{
    public class ArticleValidator : AbstractValidator<ArticleDto>
    {
        public ArticleValidator()
        {
            RuleFor(article => article.Title)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen makale başlığını boş geçmeyiniz.")
                .MaximumLength(100)
                .MinimumLength(5)
                    .WithMessage("Makale başlığını 5 ile 100 karakter arasında giriniz.");

            RuleFor(article => article.Contents)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen makale içeriğini boş geçmeyiniz.")
                .MinimumLength(5)
                    .WithMessage("Makale içeriği 5 karakterden az olamaz.");

            RuleFor(article => article.CategoryId)
               .NotEmpty()
               .NotNull()
                   .WithMessage("Makalenizin hangi katergoriye ait olduğunu lütfen belirtin.");
              
        }
    }
}
