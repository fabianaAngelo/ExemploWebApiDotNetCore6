using ERP.Business.Interfaces;
using ERP.Business.Interfaces.BackOfficeUsers;
using ERP.Business.Interfaces.Users;
using ERP.Business.Models;
using System.Transactions;

namespace ERP.Business.Services
{
    public class BackOfficeUserService : BaseService, IBackOfficeUserService
    {
        private readonly IBackOfficeUserRepository _backOfficeUserRepository;
        private readonly IUserService _userService;

        public BackOfficeUserService(IErrorNotifier errorNotifier,
           IBackOfficeUserRepository backOfficeUserRepository,
           IUserService userService) : base(errorNotifier)
        {
            _backOfficeUserRepository = backOfficeUserRepository;
            _userService = userService;
        }
        public async Task Add(BackOfficeUser backOfficeUser, string password, Guid roleId)
        {
            if (!ExecuteValidation(backOfficeUser)) return;

            using (TransactionScope tr = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var succeeded = await _userService.Add(backOfficeUser.User, password);
                if (succeeded)
                {
                    var roleSucceeded = await _userService.AddRole(backOfficeUser.User, roleId);
                    if (roleSucceeded)
                    {
                        await _backOfficeUserRepository.Add(backOfficeUser);
                        tr.Complete();
                    }
                }
            }
        }
        public void Dispose()
        {
            _backOfficeUserRepository?.Dispose();
        }
    }

}
