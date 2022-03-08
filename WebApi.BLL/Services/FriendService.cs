using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.Friend;
using WebApi.DAL.Entities;
using WebApi.DAL.Entities.Enums;
using WebApi.DAL.Interfaces;

namespace WebApi.BLL.Services
{
    public class FriendService : IFriendsService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public FriendService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<FriendDTO> FriendsByUser(string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);
            List<FriendList> friends = _unitOfWork.Friends.FriendsByUser(user.Id);

            foreach (var friend in friends)
            {
                if (friend.FriendId == user.Id)
                {
                    friend.Friend = friend.User;
                    friend.FriendId = friend.UserId;
                }
            }

            var result = _mapper.Map<List<FriendDTO>>(friends);

            result.OrderBy(x => x.Name).ThenBy(x => x.Surname);

            return result;
        }
        public List<FriendsGetRequestByUserDTO> RequareFriendsByUser(string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);
            IEnumerable<FriendList> friends = _unitOfWork.Friends.RequareFriendsByUser(user.Id);

            var result = _mapper.Map<List<FriendsGetRequestByUserDTO>>(friends);

            result.OrderBy(x => x.Name).ThenBy(x => x.Surname);

            return result;
        }
        public List<FriendsToAddGetByUserDTO> GetFriendsToAddByUser(string userName)
        {
            var users = _unitOfWork.Users.GetList();

            var mappedUsers = _mapper.Map<List<FriendsToAddGetByUserDTO>>(users);

            var friendsByUser = _unitOfWork.Friends.GetAllFriendsByUser(userName);

            var result = new List<FriendsToAddGetByUserDTO>();

            foreach (var user in mappedUsers)
            {
                if (user.Email != userName)
                {
                    if (friendsByUser.Count != 0)
                    {
                        foreach (var friend in friendsByUser)
                        {
                            if (friend.FriendId == user.UserId && friend.Status == StatusFriendship.Request)
                            {
                                user.isFriend = 1;
                                result.Add(user);
                                break;
                            }
                            else if (friend.UserId == user.UserId && friend.Status == StatusFriendship.Request)
                            {
                                user.isFriend = 2;
                                result.Add(user);
                                break;
                            }
                            else if (friend.FriendId == user.UserId && friend.Status == StatusFriendship.Accepted)
                            {
                                user.isFriend = 3;
                                break;
                            }
                            else if (friend.UserId == user.UserId && friend.Status == StatusFriendship.Accepted)
                            {
                                user.isFriend = 3;
                                break;
                            }
                        }
                        if ((!result.Contains(user) && user.isFriend != 3) && user.ExcludeFromSearch == false) { result.Add(user); }
                    }
                    else
                    {
                        if (user.ExcludeFromSearch == false)
                        {
                            user.isFriend = 0;
                            result.Add(user);
                        }
                    }
                }
            }

            result.OrderBy(x => x.Name).ThenBy(x => x.Surname);

            return result;
        }
        public void ResponseToRequareFriendsByUser(ResponseToRequareFriendsDTO model, string userName)
        {
            var userDB = _unitOfWork.Users.GetItem(userName);

            var response = _mapper.Map<FriendList>(model);
            response.FriendId = userDB.Id;
            _unitOfWork.Friends.ResponseToRequareFriendsByUser(response);
        }
        public void DeleteFriend(DeleteFriendDTO model, string userName)
        {
            var userDB = _unitOfWork.Users.GetItem(userName);

            var response = _mapper.Map<FriendList>(model);
            response.UserId = userDB.Id;
            _unitOfWork.Friends.DeleteFriend(response);
        }
        public void Create(CreateFriendDTO model, string userName)
        {
            var userDB = _unitOfWork.Users.GetItem(userName);

            var friend = _mapper.Map<FriendList>(model);
            friend.UserId = userDB.Id;
            _unitOfWork.Friends.Create(friend);
        }
    }
}
