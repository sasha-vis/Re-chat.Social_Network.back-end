using WebApi.DAL.Entities;

namespace WebApi.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        //public ICategoryRepository<Category> Categories { get; }
        //public IProductRepository<Product> Products { get; }
        public IUserRepository<User> Users { get; }
        public IPostRepository<Post> Posts { get; }

        public ILikeRepository<Like> Likes { get; }

        public ICommentRepository<Comment> Comments { get; }

        //public IOrderRepository<Order> Orders { get; }
    }
}