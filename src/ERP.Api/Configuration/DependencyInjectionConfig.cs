using ERP.Api.Extensions;
using ERP.Business.ErrorNotifications;
using ERP.Business.Interfaces;
using ERP.Business.Interfaces.BackOfficeUsers;
using ERP.Business.Interfaces.PhysicalPersons;
using ERP.Business.Interfaces.Users;
using ERP.Business.Services;
using ERP.Data.Repository;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ERP.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IErrorNotifier, ErrorNotifier>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<IBackOfficeUserRepository, BackOfficeUserRepository>();
            services.AddScoped<IBackOfficeUserService, BackOfficeUserService>();
            services.AddScoped<IPhysicalPersonRepository, PhysicalPersonRepository>();
            services.AddScoped<IPhysicalPersonService, PhysicalPersonService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
