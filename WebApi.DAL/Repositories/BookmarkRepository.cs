using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.DAL.Repositories
{
    public class BookmarkRepository : IBookmarkRepository<Bookmark>
    {
        private readonly ApplicationContext _db;

        public BookmarkRepository(ApplicationContext context)
        {
            _db = context;
        }
        public List<Bookmark> BookmarksOfUser(string id)
        {
            var bookmarks = _db.Bookmarks
                .Where(b => b.UserId == id)
                .ToList();
            return bookmarks;
        }
        public void Create(Bookmark bookmark)
        {
            var postDb = _db.Posts
                .Where(p => p.Id == bookmark.PostId)
                .FirstOrDefault();

            if (postDb != null)
            {
                var bookmarkDb = _db.Bookmarks
                .Where(b => b.UserId == bookmark.UserId && b.PostId == postDb.Id)
                .FirstOrDefault();
                if (bookmarkDb == null)
                {
                    _db.Bookmarks.Add(bookmark);
                    _db.SaveChanges();
                }
                else
                {
                    _db.Bookmarks.Remove(bookmarkDb);
                    _db.SaveChanges();
                }
            }
        }
    }
}