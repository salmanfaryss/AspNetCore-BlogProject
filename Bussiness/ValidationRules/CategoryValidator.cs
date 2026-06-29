using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator() {

            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adi Boş geçemezsin!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açiklama kism boş geçemezsin");
            
        
        }
    }
}
