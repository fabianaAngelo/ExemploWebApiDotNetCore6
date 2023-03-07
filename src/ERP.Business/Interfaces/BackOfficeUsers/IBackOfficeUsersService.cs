using ERP.Business.Models;

namespace ERP.Business.Interfaces.BackOfficeUsers
{
    public interface IBackOfficeUsersService : IDisposable
    {
        Task Add(BackOfficeUser exemplo);
        Task<IEnumerable<BackOfficeUser>> GetAll();
        Task<BackOfficeUser> GetById(Guid id);
        Task Update(BackOfficeUser exemplo);
        Task Remove(Guid id);
    }
}
