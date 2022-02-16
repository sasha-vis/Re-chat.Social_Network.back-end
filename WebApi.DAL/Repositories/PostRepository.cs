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
            //.Include(p => p.City);

            return posts;
        }
    }
}
