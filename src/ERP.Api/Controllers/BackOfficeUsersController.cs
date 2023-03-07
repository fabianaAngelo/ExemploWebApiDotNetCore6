using AutoMapper;
using ERP.Api.ViewModels.BackOfficeUsers;
using ERP.Business.Interfaces;
using ERP.Business.Interfaces.BackOfficeUsers;
using ERP.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{   
    [Authorize(Roles ="Admin")]
    [Route("api/backofficeusers")]
    public class BackOfficeUsersController : MainController<BackOfficeUsersController>
    {

        private readonly IBackOfficeUsersService _backOfficeUsersService;
        private readonly IMapper _mapper;
        public BackOfficeUsersController(IBackOfficeUsersService backOfficeUsersService,
            IMapper mapper,
            IErrorNotifier erroNotifier) : base(erroNotifier)
        {
            _backOfficeUsersService = backOfficeUsersService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<ActionResult<BackOfficeUserCreateViewModel>> Add(BackOfficeUserCreateViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var exemplo = new BackOfficeUser(viewModel.Nome/*, viewModel.CpfCnpj*/);

            await _backOfficeUsersService.Add(exemplo);
            return CustomResponse(viewModel);
        }

    }
}
