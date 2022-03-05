using WebApi.DAL.Entities;

namespace WebApi.DAL.Interfaces
{
    public interface ICommentRepository<T> where T : class
    {
        void Create(Comment comment);
    }
}
