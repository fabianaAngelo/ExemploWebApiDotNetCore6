using ERP.Business.Utils;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business.Models.Validations
{
    public class BackOfficeUserValidation : AbstractValidator<BackOfficeUser>
    {
        public BackOfficeUserValidation()
        {
            //RuleFor(f => f.Nome)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            //    .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

                //RuleFor(f => f.CpfCnpj.Length).Equal(11)
                //    .WithMessage("O campo CPF precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                //RuleFor(f => UsefulFunctions.ValidateCpf(f.CpfCnpj)).Equal(true)
                //    .WithMessage("CPF fornecido é inválido.");

                //RuleFor(f => f.CpfCnpj.Length).Equal(14)
                //    .WithMessage("O campo CNPJ precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                //RuleFor(f => UsefulFunctions.ValidateCNPJ(f.CpfCnpj)).Equal(true)
                //    .WithMessage("CNPJ fornecido é inválido.");
           
        }
    }
}
