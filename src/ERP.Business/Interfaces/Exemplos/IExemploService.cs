using ERP.Business.Models;

namespace ERP.Business.Interfaces.Exemplos
{
    public interface IExemploService : IDisposable
    {
        Task Add(Exemplo exemplo);
        Task<IEnumerable<Exemplo>> GetAll();
        Task<Exemplo> GetById(Guid id);
        Task Update(Exemplo exemplo);
        Task Remove(Guid id);
    }
}
