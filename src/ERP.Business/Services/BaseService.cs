using ERP.Business.Models;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business.Services
{
    public abstract class BaseService
    {
        protected void NotifyError(ValidationResult validationResult)
        {
           foreach(var error in validationResult.Errors)
            {
                NotifyError(error.ErrorMessage);
            }
        }
        protected void NotifyError(string mensage)
        {
            //Propagar esse erro até a camada de apresentacao
        }
        protected bool ExecuteValidation<TV, TE>( TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid)
            {
                return true;
            }

            NotifyError(validator);

            return false;
        }
    }
}
