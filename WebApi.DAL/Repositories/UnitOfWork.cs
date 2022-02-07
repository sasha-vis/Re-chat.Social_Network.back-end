using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        //private ICategoryRepository<Category> _categoryRepository;
        //private IProductRepository<Product> _productRepository;
        private IUserRepository<User> _userRepository;
        //private IOrderRepository<Order> _orderRepository;

        public UnitOfWork(ApplicationContext context)
        {
            db = context;
        }

        //public ICategoryRepository<Category> Categories
        //{
        //    get
        //    {
        //        if (_categoryRepository == null)
        //            _categoryRepository = new CategoryRepository(db);
        //        return _categoryRepository;
        //    }
        //}

        //public IProductRepository<Product> Products
        //{
        //    get
        //    {
        //        if (_productRepository == null)
        //            _productRepository = new ProductRepository(db);
        //        return _productRepository;
        //    }
        //}

        public IUserRepository<User> Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(db);
                return _userRepository;
            }
        }

        //public IOrderRepository<Order> Orders
        //{
        //    get
        //    {
        //        if (_orderRepository == null)
        //            _orderRepository = new OrderRepository(db);
        //        return _orderRepository;
        //    }
        //}
    }
}
