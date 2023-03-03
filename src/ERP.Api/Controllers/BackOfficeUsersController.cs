using ERP.Api.ViewModels.BackOfficeUserCreateViewModel;
using ERP.Business.Interfaces;
using ERP.Business.Interfaces.BackOfficeUsers;
using ERP.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/backoffice")]
    public class BackOfficeUsersController : MainController<BackOfficeUsersController>
    {
        private readonly IBackOfficeUserService _backOfficeUserService;
        public BackOfficeUsersController(IErrorNotifier errorNotifier, IBackOfficeUserService backOfficeUserService): base(errorNotifier)
        {
            _backOfficeUserService = backOfficeUserService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(BackOfficeUserCreateViewModel userViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var backOfficeUser = new BackOfficeUser(userViewModel.Name, userViewModel.CPF, userViewModel.Email);

            await _backOfficeUserService.Add(backOfficeUser, userViewModel.Password, userViewModel.RoleId);
            return CustomResponse(userViewModel);
        }
    }
}
