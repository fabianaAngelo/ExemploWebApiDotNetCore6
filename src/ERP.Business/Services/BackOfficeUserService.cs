using ERP.Business.Interfaces;
using ERP.Business.Interfaces.BackOfficeUsers;
using ERP.Business.Interfaces.Users;
using ERP.Business.Models;
using ERP.Business.Models.Validations;
using System.Transactions;

namespace ERP.Business.Services
{
    public class BackOfficeUserService : BaseService, IBackOfficeUsersService
    {
        private readonly IBackOfficeUsersRepository _backOfficeUserRepository;
        private readonly IUserService _userService;
        public BackOfficeUserService(IBackOfficeUsersRepository exemploRepository, IErrorNotifier errorNotifier,
            IUserService userService) : base(errorNotifier)
        {
            _backOfficeUserRepository = exemploRepository;
            _userService = userService;
        }
        public async Task Add(BackOfficeUser backOfficeUser, string password, Guid roleId)
        {
            if (!ExecuteValidation(new BackOfficeUserValidation(), backOfficeUser)) return;

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
        //public async Task<IEnumerable<BackOfficeUser>> GetAll()
        //{
        //    return await _backOfficeUserRepository.GetAll();
        //}
        //public async Task<BackOfficeUser> GetById(Guid id)
        //{
        //    return await _backOfficeUserRepository.GetById(id);
        //}
        //public async Task Update(BackOfficeUser backOffice)
        //{
        //    if (!ExecuteValidation(new BackOfficeUserValidation(), backOffice)) return;

        //    if (_backOfficeUserRepository.Search(f => f.PhysicalPerson.CPF == backOffice.PhysicalPerson.CPF && f.Id != backOffice.Id).Result.Any())
        //    {
        //        NotifyError("CNPJ informado já existe.");
        //        return;
        //    }

        //    await _backOfficeUserRepository.Update(backOffice);
        //}

        //public async Task Remove(Guid id)
        //{
        //    await _backOfficeUserRepository.Remove(id);
        //}
        public void Dispose()
        {
            _backOfficeUserRepository?.Dispose();
        }
    }
}
