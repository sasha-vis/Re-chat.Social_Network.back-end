using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.Bookmark;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.BLL.Services
{
    public class BookmarkService : IBookmarkService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public BookmarkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Create(BookmarkCreateDTO model, string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);
            var bookmark = _mapper.Map<Bookmark>(model);
            bookmark.UserId = user.Id;
            _unitOfWork.Bookmarks.Create(bookmark);
        }
    }
}