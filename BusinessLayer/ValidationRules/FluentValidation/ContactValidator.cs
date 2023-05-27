using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez.");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("Kullanıcı adı alanı minimum 2 karakterden oluşmalıdır.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz.");
            RuleFor(x => x.Message).MinimumLength(3).MaximumLength(150).WithMessage("Mesaj 3-150 karakterden oluşmalıdır.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmını boş geçemezsiniz.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu kısmın maximum 50 karakterden oluşmalıdır.");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail kısmını boş geçemezsiniz.");
        }
    }
}
