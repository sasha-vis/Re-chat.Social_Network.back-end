using AutoMapper;
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

        public IEnumerable<UserGetVM> GetList()
        {
            var users = _unitOfWork.Users.GetList();

            var result = _mapper.Map<IEnumerable<UserGetVM>>(users);

            return result;
        }
        public UserGetVM GetItem(string id)
        {
            var users = _unitOfWork.Users.GetItem(id);

            var result = _mapper.Map<UserGetVM>(users);

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
