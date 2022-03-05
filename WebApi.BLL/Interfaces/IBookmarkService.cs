using WebApi.BLL.DTO.Bookmark;

namespace WebApi.BLL.Interfaces
{
    public interface IBookmarkService
    {
        public void Create(BookmarkCreateDTO model, string userName);
    }
}
