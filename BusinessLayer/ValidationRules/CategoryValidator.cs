using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori içerik boş geçilemez");        
            RuleFor(x => x.CategoryDescription).MaximumLength(150).WithMessage("150 Krakterden az başlık giriniz");
            RuleFor(x => x.CategoryDescription).MinimumLength(4).WithMessage("4 en az krakterden başlık giriniz");
        }
    }
}
