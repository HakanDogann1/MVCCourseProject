using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        private bool IsAboutValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[a,A])");
                return regex.IsMatch(arg);
            }
            catch (Exception)
            {

                return false;
            }
        }
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı boş geçilmez");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı boş geçilmez");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adını maximum 50 karakter olmalı");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazarın Hakkında kısmı boş geçilemez");
            RuleFor(x => x.WriterAbout).Must(IsAboutValid).WithMessage("Hakkında kısmında en az bir defa a harfi kullanılmalıdır");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmı boş geçilemez");
        }
    }
}
