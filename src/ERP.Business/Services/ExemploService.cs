using ERP.Business.Interfaces;
using ERP.Business.Interfaces.Exemplos;
using ERP.Business.Models;
using ERP.Business.Models.Validations;

namespace ERP.Business.Services
{
    public class ExemploService : BaseService, IExemploService
    {
        private readonly IExemploRepository _exemploRepository;
        public ExemploService(IExemploRepository exemploRepository, IErrorNotifier errorNotifier) : base(errorNotifier)
        {
            _exemploRepository = exemploRepository;
        }
        public async Task Add(Exemplo exemplo)
        {
            if (!ExecuteValidation(new ExemploValidation(), exemplo)) return;

            if(_exemploRepository.Search(f => f.CpfCnpj == exemplo.CpfCnpj).Result.Any())
            {
                NotifyError("CNPJ informado já existe.");
                return;
            }
            
            await _exemploRepository.Add(exemplo);
        }
        public async Task<IEnumerable<Exemplo>> GetAll()
        {
            return await _exemploRepository.GetAll();
        }
        public async Task<Exemplo> GetById(Guid id)
        {
            return await _exemploRepository.GetById(id);
        }
        public async Task Update(Exemplo exemplo)
        {
            if (!ExecuteValidation(new ExemploValidation(), exemplo)) return;

            if (_exemploRepository.Search(f => f.CpfCnpj == exemplo.CpfCnpj && f.Id != exemplo.Id).Result.Any())
            {
                NotifyError("CNPJ informado já existe.");
                return;
            }

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
