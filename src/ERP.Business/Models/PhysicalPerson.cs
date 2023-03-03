using ERP.Business.Models.Validations;
using ERP.Business.Utils;
using FluentValidation.Results;

namespace ERP.Business.Models
{
    public class PhysicalPerson : Entity
    {
        public string CPF { get; set; }

        public string Name { get; set; }

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }

        public PhysicalPerson() { }

        public PhysicalPerson(string cpf, string name)
        {
            CPF = UsefulFunctions.RemoveNonNumeric(cpf);
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new PhysicalPersonValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

