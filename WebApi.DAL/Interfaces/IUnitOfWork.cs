using WebApi.DAL.Entities;

namespace WebApi.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        //public ICategoryRepository<Category> Categories { get; }
        //public IProductRepository<Product> Products { get; }
        public IUserRepository<User> Users { get; }
        //public IOrderRepository<Order> Orders { get; }
    }
}