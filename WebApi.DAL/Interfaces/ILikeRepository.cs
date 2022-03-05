using WebApi.DAL.Entities;

namespace WebApi.DAL.Interfaces
{
    public interface ILikeRepository<T> where T : class
    {
        List<Like> LikesOfUser(string id);
        public void Create(T item);

    }
}
