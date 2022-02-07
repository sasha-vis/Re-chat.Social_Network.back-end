using Microsoft.Extensions.DependencyInjection;
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
        }
    }
}
