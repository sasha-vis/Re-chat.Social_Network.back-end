﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        private readonly UserManager<User> _userManager;

        private IPostRepository<Post> _postRepository;
        private ILikeRepository<Like> _likeRepository;
        private ICommentRepository<Comment> _commentRepository;

        //private IOrderRepository<Order> _orderRepository;


        public UnitOfWork(ApplicationContext context,
          IConfiguration configuration,
          UserManager<User> userManager)
        {
            this.db = context;
            _configuration = configuration;
            _userManager = userManager;
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
                    _userRepository = new UserRepository(db, _configuration, _userManager);
                return _userRepository;
            }
        }

        public IPostRepository<Post> Posts
        {
            get
            {
                if (_postRepository == null)
                    _postRepository = new PostRepository(db);
                return _postRepository;
            }
        }

        public ILikeRepository<Like> Likes
        {
            get
            {
                if (_likeRepository == null)
                    _likeRepository = new LikeRepository(db);
                return _likeRepository;
            }
        }

        public ICommentRepository<Comment> Comments
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(db);
                return _commentRepository;
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
