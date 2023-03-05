using ERP.Business.ErrorNotifications;
using ERP.Business.Interfaces;

namespace ERP.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IErrorNotifier, ErrorNotifier>();


            return services;
        }
    }
}
