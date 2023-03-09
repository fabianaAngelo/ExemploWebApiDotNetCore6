using ERP.Api.Configuration;
using ERP.Api.Extensions;
using ERP.Business.Interfaces;
using ERP.Business.Interfaces.BackOfficeUsers;
using ERP.Business.Interfaces.PhysicalPersons;
using ERP.Business.Interfaces.Users;
using ERP.Business.Services;
using ERP.Data.Context;
using ERP.Data.Repository;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ERP.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddLocalization(options => options.ResourcesPath = "IdentityTranslatedMessages");
            //services.AddDistributedMemoryCache();
            services.AddControllers();

            
            services.AddScoped<IBackOfficeUsersService, BackOfficeUserService>();
            services.AddScoped<IBackOfficeUsersRepository, BackOfficeUserRepository>();

            services.AddScoped<IPhysicalPersonRepository, PhysicalPersonRepository>();
            services.AddScoped<IPhysicalPersonService, PhysicalPersonService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUser, AspNetUser>();

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ERP.API", Version = "v1" });
            });

            services.AddDbContext<DataContext>(
                context => context.UseMySql(Configuration.GetConnectionString("DataContext"), ServerVersion.AutoDetect(Configuration.GetConnectionString("DataContext")))
            );

            services.AddIdentityConfiguration(Configuration);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.ResolveDependencies();

            services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(Path.GetTempPath()));

            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ERP.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
