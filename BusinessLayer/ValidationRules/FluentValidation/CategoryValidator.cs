using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori ismi boş olamaz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori içeriğini boş geçemezsiniz.");
            RuleFor(x => x.CategoryName).MinimumLength(4).WithMessage("Kategori adı minimum 4 karakter olmak zorunda");
        }
    }
}
