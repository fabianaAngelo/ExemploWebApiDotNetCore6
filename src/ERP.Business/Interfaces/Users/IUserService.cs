using ERP.Business.Models;
using Microsoft.AspNetCore.Identity;

namespace ERP.Business.Interfaces.Users
{
    public interface IUserService
    {
       // Task<IdentityUser> GetByIdWithPerson(Guid id);

        Task<bool> Add(ApplicationUser user, string password);

        Task<bool> AddRole(ApplicationUser user, string role);

        Task<bool> AddRole(ApplicationUser user, Guid roleId);

    }
}
