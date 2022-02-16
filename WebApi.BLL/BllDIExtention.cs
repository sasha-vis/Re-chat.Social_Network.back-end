using Microsoft.Extensions.DependencyInjection;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Services;
using WebApi.DAL;

namespace WebApi.BLL
{
    public static class BllDIExtention
    {
        public static void RegisterBllDependencies(this IServiceCollection services)
        {
            services.RegisterDalDependencies();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddTransient<ICategoryService, CategoryService>();
            //services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPostService, PostService>();
            //services.AddTransient<IOrderService, OrderService>();
        }
    }
}

