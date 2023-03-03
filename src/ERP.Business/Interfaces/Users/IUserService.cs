using ERP.Business.Models;

namespace ERP.Business.Interfaces.Users
{
    public interface IUserService
    {
        Task<bool> Add(ApplicationUser user, string password);

        Task<bool> AddRole(ApplicationUser user, string role);

        Task<bool> AddRole(ApplicationUser user, Guid roleId);

    }
}
