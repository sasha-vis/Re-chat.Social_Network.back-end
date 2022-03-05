using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private readonly IConfiguration _configuration;

        private readonly UserManager<User> _userManager;

        private IUserRepository<User> _userRepository;
        private IAccountRepository<User> _accountRepository;
        private IPostRepository<Post> _postRepository;
        private ILikeRepository<Like> _likeRepository;
        private IBookmarkRepository<Bookmark> _bookmarkRepository;
        private ICommentRepository<Comment> _commentRepository;
        private IFriendRepository<FriendList> _friendRepository;
        private IMessageRepository<Message> _messageRepository;
        public UnitOfWork(ApplicationContext context,
          IConfiguration configuration,
          UserManager<User> userManager)
        {
            this.db = context;
            _configuration = configuration;
            _userManager = userManager;
        }
        public IUserRepository<User> Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(db, _configuration, _userManager);
                return _userRepository;
            }
        }
        public IAccountRepository<User> Accounts
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository(db, _configuration, _userManager);
                return _accountRepository;
            }
        }
        public IFriendRepository<FriendList> Friends
        {
            get
            {
                if (_friendRepository == null)
                    _friendRepository = new FriendRepository(db);
                return _friendRepository;
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
        public IBookmarkRepository<Bookmark> Bookmarks
        {
            get
            {
                if (_bookmarkRepository == null)
                    _bookmarkRepository = new BookmarkRepository(db);
                return _bookmarkRepository;
            }
        }
        public IMessageRepository<Message> Messages
        {
            get
            {
                if (_messageRepository == null)
                    _messageRepository = new MessageRepository(db);
                return _messageRepository;
            }
        }
    }
}
