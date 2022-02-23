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
    public class CommentRepository : ICommentRepository<Comment>
    {
        private readonly ApplicationContext _db;

        public CommentRepository(ApplicationContext context)
        {
            _db = context;
        }


        public Comment GetItem(int id)
        {
            var comment = _db.Comments
                .Where(p => p.Id == id)
                .Include(a => a.Author)
                .FirstOrDefault();

            return comment;
        }


        public void Create(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var comment = _db.Comments.FirstOrDefault(p => p.Id == id);
            if (comment != null)
            {
                _db.Comments.Remove(comment);
                _db.SaveChangesAsync();
            }
        }
    }
}
