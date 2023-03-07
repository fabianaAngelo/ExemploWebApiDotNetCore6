using ERP.Business.ErrorNotifications;
using ERP.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ERP.Api.Controllers
{
    public class MainController<T> : ControllerBase where T : ControllerBase
    {
        private readonly IErrorNotifier _errorNotifier;
        public readonly IUser AppUser;

        protected Guid UserId { get; set; }
        protected bool IsAuthenticated { get; set; }

        public MainController(IErrorNotifier errorNotifier, IUser appUser)
        {
            _errorNotifier = errorNotifier;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UserId = appUser.GetUserId();
                IsAuthenticated = true;
            }
        }
        protected bool validOperation()
        {
            return !_errorNotifier.HasErrorNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (validOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _errorNotifier.GetErrorNotifications().Select(e => e.Message)
            }) ;
        }
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyErrorModelInvalid(modelState);
            return CustomResponse();
        }

        protected void NotifyErrorModelInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(s => s.Errors);

            foreach (var erro in errors)
            {
                string message = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(message);
            }
        }
        protected void NotifyError(string message)
        {
            _errorNotifier.Handle(new ErrorNotification(message));
        }
    }
}
