﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.User;
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

        public IEnumerable<UserGetVM> GetList(string userName)
        {
            var friends = _unitOfWork.Friends.FriendsByUser(userName);
            IEnumerable<User> usersDb =  _unitOfWork.Users.GetList();
            var users = _mapper.Map<IEnumerable<UserGetVM>>(usersDb);

            foreach (var user in users)
            {
                foreach (var friend in friends)
                {
                    if (user.Id == friend.UserId || user.Id == friend.FriendId)
                    {
                        user.IsFriend = true;
                    }
                }
            }

            IEnumerable<UserGetVM> sortedResult = users.OrderBy(x => x.Name).ThenBy(x => x.Surname);


            return sortedResult;
        }

        public UserGetVM GetItem(string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);

            var result = _mapper.Map<UserGetVM>(user);
            result.CountLikes = _unitOfWork.Likes.LikesOfUser(user.Id).Count;
            result.CountBookmarks = _unitOfWork.Bookmarks.BookmarksOfUser(user.Id).Count;

            return result;
        }

        public JwtSecurityToken Register(UserRegisterVM model)
        {
            var user = _mapper.Map<User>(model);

            user.SecurityStamp = Guid.NewGuid().ToString();

            if (user.BirthdayDate == "string")
            {
                user.BirthdayDate = null;
            }
            if (user.Gender == "string")
            {
                user.Gender = null;
            }

            return _unitOfWork.Users.Register(user, model.Password).Result;
        }

        public JwtSecurityToken Login(UserLoginVM model)
        {
            var user = _mapper.Map<User>(model);

            return _unitOfWork.Users.Login(user, model.Password);
        }
    }
}
