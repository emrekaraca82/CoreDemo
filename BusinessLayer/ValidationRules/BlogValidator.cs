using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik boş geçilemez");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Resim boş geçilemez");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("150 Krakterden az başlık giriniz");
            RuleFor(x => x.BlogTitle).MinimumLength(4).WithMessage("4 en az krakterden başlık giriniz");
        }
    }
}
