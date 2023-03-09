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
            services.AddIdentity<ApplicationUser, ApplicationRole>
                (options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = false;
                })
                //.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddErrorDescriber<IdentityTranslatedMessages>()
                .AddDefaultTokenProviders();

            //JWT
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                //é importante exigir o HTTPS
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    //permitindo todos os dominios
                    ValidateAudience = false,
                    //ValidAudience = appSettings.ValidIn,
                    ValidIssuer = appSettings.Emitter
                };
            });

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
