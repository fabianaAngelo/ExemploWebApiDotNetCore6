using ERP.Business.ErrorNotifications;
using ERP.Business.Interfaces;
using ERP.Business.Models;
using FluentValidation;
using FluentValidation.Results;

namespace ERP.Business.Services
{
    public abstract class BaseService
    {
        private readonly IErrorNotifier _errorNotifier;
        public BaseService(IErrorNotifier errorNotifier)
        {
            _errorNotifier = errorNotifier;
        }
        protected void NotifyError(ValidationResult validationResult)
        {
           foreach(var error in validationResult.Errors)
            {
                NotifyError(error.ErrorMessage);
            }
        }
        protected void NotifyError(string mensage)
        {
            _errorNotifier.Handle(new ErrorNotification(mensage));
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
        protected bool ExecuteValidation<TE>(TE entity) where TE : Entity
        {
            if (entity.IsValid())
            {
                return true;
            }

            NotifyError(entity.ValidationResult);

            return false;
        }
    }
}
