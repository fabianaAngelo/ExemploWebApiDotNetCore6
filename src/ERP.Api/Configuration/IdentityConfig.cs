using ERP.Api.Extensions;
using ERP.Business.Models;
using ERP.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ERP.Api.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddIdentity<IdentityUser, IdentityRole>
                (options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = false;
                })
                //.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            return services;
        }
        public static IApplicationBuilder UseIdentityConfiguration(this IApplicationBuilder app)
        {
            using (var serviceScoped = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScoped.ServiceProvider.GetRequiredService<DataContext>();

                context.Database.Migrate();
            }

            return app;
        }
    }
}
