using ERP.Business.Models.Validations;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Business.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public bool Disabled { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public PhysicalPerson PhysicalPerson { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        //EF
        public ApplicationUser() { }

        public ApplicationUser(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }

        public bool IsValid()
        {
            ValidationResult = new ApplicationUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
