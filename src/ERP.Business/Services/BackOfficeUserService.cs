using ERP.Business.Interfaces;
using ERP.Business.Interfaces.BackOfficeUsers;
using ERP.Business.Models;
using ERP.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business.Services
{
    public class BackOfficeUserService : BaseService, IBackOfficeUsersService
    {
        private readonly IBackOfficeUsersRepository _exemploRepository;
        public BackOfficeUserService(IBackOfficeUsersRepository exemploRepository, IErrorNotifier errorNotifier) : base(errorNotifier)
        {
            _exemploRepository = exemploRepository;
        }
        public async Task Add(BackOfficeUser backOffice)
        {
            if (!ExecuteValidation(new BackOfficeUserValidation(), backOffice)) return;

            //if (_exemploRepository.Search(f => f.CpfCnpj == exemplo.CpfCnpj).Result.Any())
            //{
            //    NotifyError("CPF informado já existe.");
            //    return;
            //}

            await _exemploRepository.Add(backOffice);
        }
        public async Task<IEnumerable<BackOfficeUser>> GetAll()
        {
            return await _exemploRepository.GetAll();
        }
        public async Task<BackOfficeUser> GetById(Guid id)
        {
            return await _exemploRepository.GetById(id);
        }
        public async Task Update(BackOfficeUser exemplo)
        {
            if (!ExecuteValidation(new BackOfficeUserValidation(), exemplo)) return;

            //if (_exemploRepository.Search(f => f.CpfCnpj == exemplo.CpfCnpj && f.Id != exemplo.Id).Result.Any())
            //{
            //    NotifyError("CNPJ informado já existe.");
            //    return;
            //}

            await _exemploRepository.Update(exemplo);
        }

        public async Task Remove(Guid id)
        {
            await _exemploRepository.Remove(id);
        }
        public void Dispose()
        {
            _exemploRepository?.Dispose();
        }
    }
}
