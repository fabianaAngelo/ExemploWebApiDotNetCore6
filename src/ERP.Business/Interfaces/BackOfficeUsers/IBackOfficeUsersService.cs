using ERP.Business.Models;

namespace ERP.Business.Interfaces.BackOfficeUsers
{
    public interface IBackOfficeUsersService : IDisposable
    {
        Task Add(BackOfficeUser backOfficeUser, string password, Guid roleId);
        //Task<IEnumerable<BackOfficeUser>> GetAll();
        //Task<BackOfficeUser> GetById(Guid id);
        //Task Update(BackOfficeUser exemplo);
        //Task Remove(Guid id);
    }
}
