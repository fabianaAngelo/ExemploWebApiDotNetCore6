using ERP.Business.Interfaces;
using ERP.Business.Interfaces.Users;
using ERP.Business.Models;
using Microsoft.AspNetCore.Identity;

namespace ERP.Business.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserRepository _userRepository;
        private readonly IUser _appUser;

        public UserService(IErrorNotifier errorNotifier,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, 
            IUserRepository userRepository, IUser appUser) : base(errorNotifier)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepository = userRepository;
            _appUser = appUser;
        }

        public async Task<bool> Add(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return true;
            }

            foreach (var erro in result.Errors)
            {
                NotifyError(erro.Description);
            }

            return false;
        }

        public async Task<bool> AddRole(ApplicationUser user, string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);

            if (result.Succeeded)
            {
                return true;
            }

            foreach (var erro in result.Errors)
            {
                NotifyError(erro.Description);
            }

            return false;
        }

        public async Task<bool> AddRole(ApplicationUser user, Guid roleId)
        {
            var roleName = _roleManager.Roles.Where(c => c.Id == roleId).FirstOrDefault().Name;

            return await AddRole(user, roleName);
        }

    }
}
