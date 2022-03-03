using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //public IEnumerable<Post> GetMyPosts(string userName)
        //{
        //    var user = _db.Users
        //        .FirstOrDefault(u => u.UserName == userName);
        //    var posts = _db.Posts
        //           .Where(c => c.UserId == user.Id)
        //         .Include(p => p.User)
        //        .Include(l => l.Likes)
        //        .Include(l => l.Comments)
        //        .Include(l => l.Bookmarks)
        //       .OrderByDescending(x => x.PostDate)
        //       .ToList();


        //    return posts;
        //}

        //public IEnumerable<Post> GetFavoritesPosts(User user)
        //{
        //    var likes = _db.Likes
        //        .Where(l => l.UserId == user.Id)
        //        .ToList();

        //    var posts = _db.Posts
        //         .Include(p => p.Likes)
        //         .ToList();

        //    List<Post> result = new List<Post>();

        //    foreach (var l in likes)
        //    {
        //        foreach (var post in posts)
        //        {
        //            if (post.Id == l.PostId)
        //                result.Add(post);
        //        }
        //    }

        //    return result;

        //}

        public void Create(Post model, string userName)
        {
            //DateTime date = DateTime.Now;
            //string dateString = date.ToString("g");

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

        public void Delete(int id)
        {
            var post = _db.Posts
                  .Where(post => post.Id == id)
                  .FirstOrDefault();

            if (post != null)
            {
                _db.Posts.Remove(post);
                _db.SaveChanges();
            }
        }
    }
}
