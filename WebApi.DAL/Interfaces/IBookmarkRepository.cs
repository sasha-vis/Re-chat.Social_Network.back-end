using WebApi.DAL.Entities;

namespace WebApi.DAL.Interfaces
{
    public interface IBookmarkRepository<T> where T : class
    {
        List<Bookmark> BookmarksOfUser(string id);
        public void Create(T item);

    }
}
