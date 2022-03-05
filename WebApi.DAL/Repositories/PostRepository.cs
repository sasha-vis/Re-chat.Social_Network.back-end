using Microsoft.EntityFrameworkCore;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.DAL.Repositories
{
    public class PostRepository : IPostRepository<Post>
    {
        private readonly ApplicationContext _db;
        public PostRepository(ApplicationContext context)
        {
            _db = context;
        }
        public IEnumerable<Post> GetList()
        {
            var posts = _db.Posts
                 .Include(p => p.User)
                .Include(l => l.Likes)
                .Include(l => l.Comments)
                .Include(l => l.Bookmarks)
                .OrderByDescending(x => x.PostDate)
                .ToList();

            return posts;
        }
        public Post GetItem(int Id)
        {
            var post = _db.Posts
                .Where(c => c.Id == Id)
                .Include(p => p.User)
                .Include(l => l.Likes)
                .Include(l => l.Comments)
                .Include(l => l.Bookmarks)
                .FirstOrDefault();

            return post;
        }
        public void Create(Post model, string userName)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == userName);
            model.UserId = user.Id;
            model.PostDate = DateTime.Now;
            _db.Posts.Add(model);
            _db.SaveChanges();
        }
        public void Edit(Post post)
        {
            _db.Posts.Update(post);
            _db.SaveChanges();
        }
        public void Delete(Post post)
        {
            _db.Posts.Remove(post);
            _db.SaveChanges();
        }
    }
}
