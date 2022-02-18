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
                .Include(p => p.User);

            return posts;
        }

        public Post GetItem(int Id)
        {

            var post = _db.Posts
                .Where(c => c.Id == Id)
                .Include(p => p.User)
                .FirstOrDefault();

            return post;
        }

        public void Create(Post model)
        {
            _db.Posts.Add(model);
            _db.SaveChanges();
        }

        public void Edit(Post model)
        {
            var post = _db.Posts
                  .Where(post => post.Id == model.Id)
                  .FirstOrDefault();

            if (post != null)
            {
                post.Title = model.Title;
                post.Content = model.Content;
                _db.Posts.Update(post);
                _db.SaveChanges();
            }

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
