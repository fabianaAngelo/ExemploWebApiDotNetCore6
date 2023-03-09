using FluentValidation;
using ERP.Business.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Business.Models.Validations
{
    public class ApplicationUserValidation : AbstractValidator<ApplicationUser>
    {
        //public static string EmailNotEmptyMsg => "O campo Email precisa ser fornecido";
        public static string EmailMaxLengthMsg => "O campo Email só pode ter no máximo 256 caracteres";
        public static string EmailInvalidMsg => "O Email fornecido é inválido.";

        public ApplicationUserValidation()
        {
            RuleFor(f => f.Email)
                //.NotEmpty().WithMessage(EmailNotEmptyMsg)
                .MaximumLength(256)
                .WithMessage(EmailMaxLengthMsg);
            RuleFor(f => UsefulFunctions.IsValidEmail(f.Email)).Equal(true)
                .WithMessage(EmailInvalidMsg);
        }
    }
}
