using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.User;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<UserGetDTO> GetList(string userName)
        {
            IEnumerable<User> usersDb = _unitOfWork.Users.GetList();
            var users = _mapper.Map<IEnumerable<UserGetDTO>>(usersDb);

            users.OrderBy(x => x.Name).ThenBy(x => x.Surname);


            return users;
        }
        public UserGetDTO GetItem(string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);

            var result = _mapper.Map<UserGetDTO>(user);
            result.CountLikes = _unitOfWork.Likes.LikesOfUser(user.Id).Count;
            result.CountBookmarks = _unitOfWork.Bookmarks.BookmarksOfUser(user.Id).Count;
            result.CountFriends = _unitOfWork.Friends.FriendsByUser(user.Id).Count;

            return result;
        }
    }
}
