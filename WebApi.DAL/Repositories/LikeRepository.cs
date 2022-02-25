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
    public class LikeRepository : ILikeRepository<Like>
    {
        private readonly ApplicationContext _db;

        public LikeRepository(ApplicationContext context)
        {
            _db = context;
        }

        public List<Like> LikesOfUser(string id)
        {
            var likes = _db.Likes
                .Where(l => l.UserId == id)
                .ToList();
            return likes;
        }

        public void Create(Like like)
        {
            var likeDb = _db.Likes
                .Where(l => l.UserId == like.UserId && l.PostId == like.PostId)
                .FirstOrDefault();
            if (likeDb == null)
            {
                _db.Likes.Add(like);
                _db.SaveChanges();
            }
            else
            {
                _db.Likes.Remove(likeDb);
                _db.SaveChanges();
            }

        }
    }
}
