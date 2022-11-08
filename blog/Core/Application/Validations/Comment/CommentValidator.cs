using Application.DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations.Comment
{
    public class CommentValidator : AbstractValidator<CommentDto>
    {
        public CommentValidator()
        {
            RuleFor(comment => comment.Text)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen yorum içeriğini giriniz.")
                .MinimumLength(5)
                .MaximumLength(150)
                    .WithMessage("Yorum içeriği 5 ile 150 karakter arasında olmalıdır.");

        }
    }
}
