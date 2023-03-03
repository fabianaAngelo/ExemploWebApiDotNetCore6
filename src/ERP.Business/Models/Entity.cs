using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Business.Models
{
    public abstract class Entity
    {

        public Guid Id { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
