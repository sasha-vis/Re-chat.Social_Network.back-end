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
        public void Create(Comment comment)
        {
            var postDB = _db.Posts
                .Where(p => p.Id == comment.PostId)
                .FirstOrDefault();

            if (postDB != null)
            {
                comment.CommentDate = DateTime.Now;
                _db.Comments.Add(comment);
                _db.SaveChanges();
            }
        }
    }
}
