using ERP.Business.Interfaces.Exemplos;
using ERP.Business.Models;
using ERP.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business.Services
{
    public class ExemploService : BaseService, IExemploService
    {
        private readonly IExemploRepository _exemploRepository;
        public ExemploService(IExemploRepository exemploRepository)
        {
            _exemploRepository = exemploRepository;
        }
        public async Task Add(Exemplo exemplo)
        {
            if (!ExecuteValidation(new ExemploValidation(), exemplo)) return;

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
