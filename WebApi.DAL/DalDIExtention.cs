using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;
using WebApi.DAL.Repositories;

namespace WebApi.DAL
{
    public static class DalDIExtention
    {
        public static void RegisterDalDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddIdentity<User, IdentityRole>(opts => {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
             .AddEntityFrameworkStores<ApplicationContext>()
             .AddDefaultTokenProviders();
        }
    }
}
