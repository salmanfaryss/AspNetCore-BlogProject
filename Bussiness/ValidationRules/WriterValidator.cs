using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı-Soyadı boş geçemezsin!");
            //RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("Yazar Mail adresi boş geçemezsin!");
            //RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar Şifre boş geçemezsin!");

            

        }
    }
}
