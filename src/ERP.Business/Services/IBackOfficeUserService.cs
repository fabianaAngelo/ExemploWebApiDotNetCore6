using ERP.Business.Models;

namespace ERP.Business.Interfaces.Services
{
    public interface IBackOfficeUserService : IDisposable
    {
        Task Add(BackOfficeUser backOfficeUser, string password, Guid roleId);

    }
}