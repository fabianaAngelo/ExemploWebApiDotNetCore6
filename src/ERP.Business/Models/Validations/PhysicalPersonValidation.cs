using ERP.Business.Utils;
using FluentValidation;

namespace ERP.Business.Models.Validations
{
    public class PhysicalPersonValidation : AbstractValidator<PhysicalPerson>
    {
        public static string NameNotEmptyMsg => "O campo Nome precisa ser fornecido";
        public static string NameMaxLengthMsg => "O campo Nome só pode ter no máximo 256 caracteres";
        public static string CPFInvalidMsg => "O CPF fornecido é inválido.";

        public PhysicalPersonValidation()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage(NameNotEmptyMsg)
                .MaximumLength(256)
                .WithMessage(NameMaxLengthMsg);

            RuleFor(f => UsefulFunctions.ValidateCpf(f.CPF)).Equal(true)
                .WithMessage(CPFInvalidMsg);
        }
    }
}
