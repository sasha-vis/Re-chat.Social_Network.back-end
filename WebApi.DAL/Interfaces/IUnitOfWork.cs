using WebApi.DAL.Entities;

namespace WebApi.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository<User> Users { get; }
        public IAccountRepository<User> Accounts { get; }
        public IPostRepository<Post> Posts { get; }
        public ILikeRepository<Like> Likes { get; }
        public IFriendRepository<FriendList> Friends { get; }
        public ICommentRepository<Comment> Comments { get; }
        public IBookmarkRepository<Bookmark> Bookmarks { get; }
        public IMessageRepository<Message> Messages { get; }
    }
}