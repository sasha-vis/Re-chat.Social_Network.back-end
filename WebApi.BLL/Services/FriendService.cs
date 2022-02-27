using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Friend;
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

       
        public List<FriendVM> FriendsByUser(string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);
            List<FriendList> friends = _unitOfWork.Friends.FriendsByUser(userName);

            foreach (var friend in friends)
            {
                if (friend.FriendId == user.Id)
                {
                    friend.Friend = friend.User;
                }
            }

            return _mapper.Map<List<FriendVM>>(friends);
        }


        public List<FriendsGetRequestByUserVM> RequareFriendsByUser(string userName)
        {
            IEnumerable<FriendList> friends =  _unitOfWork.Friends.RequareFriendsByUser(userName);

            return _mapper.Map<List<FriendsGetRequestByUserVM>>(friends);
        }

       

        public void ResponseToRequareFriendsByUser(ResponseToRequareFriends model, string userName)
        {
            var userDB = _unitOfWork.Users.GetItem(userName);

            var response = _mapper.Map<FriendList>(model);
            response.FriendId = userDB.Id;
            _unitOfWork.Friends.ResponseToRequareFriendsByUser(response);
        }

        public void Create(CreateFriendVM model, string userName)
        {
            var userDB = _unitOfWork.Users.GetItem(userName);

            var friend = _mapper.Map<FriendList>(model);
            friend.UserId = userDB.Id;
             _unitOfWork.Friends.Create(friend);
        }

    }
}
