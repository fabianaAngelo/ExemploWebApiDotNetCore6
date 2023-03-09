using AutoMapper;
using ERP.Api.ViewModels.BackOfficeUsers;
using ERP.Business.Interfaces;
using ERP.Business.Interfaces.BackOfficeUsers;
using ERP.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/backofficeusers")]
    public class BackOfficeUsersController : MainController<BackOfficeUsersController>
    {

        private readonly IBackOfficeUsersService _backOfficeUsersService;
        private readonly IMapper _mapper;
        private readonly IUser _appUser;
        public BackOfficeUsersController(IBackOfficeUsersService backOfficeUsersService,
            IMapper mapper,
            IErrorNotifier erroNotifier,
            IUser user) : base(erroNotifier, user)
        {
            _backOfficeUsersService = backOfficeUsersService;
            _mapper = mapper;
            _appUser = user;
        }

        [HttpPost]
        public async Task<ActionResult<BackOfficeUserCreateViewModel>> Add([FromBody]BackOfficeUserCreateViewModel userViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            var backOfficeUser = new BackOfficeUser(userViewModel.Name, userViewModel.CPF, userViewModel.Email);

            await _backOfficeUsersService.Add(backOfficeUser, userViewModel.Password, userViewModel.RoleId);
            return CustomResponse(userViewModel);
        }

    }
}
