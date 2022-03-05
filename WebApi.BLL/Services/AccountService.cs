using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.User;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.BLL.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public JwtSecurityToken Register(UserRegisterDTO model)
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

            return _unitOfWork.Accounts.Register(user, model.Password).Result;
        }
        public JwtSecurityToken Login(UserLoginDTO model)
        {
            var user = _mapper.Map<User>(model);

            return _unitOfWork.Accounts.Login(user, model.Password);
        }
        public void ExcludeFromSearch(string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);
            _unitOfWork.Accounts.ExcludeFromSearch(user);
        }
        public void ChangeGeneral(ChangeGeneralInfoUserDTO model, string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Gender = model.Gender;
            user.BirthdayDate = model.BirthdayDate;

            _unitOfWork.Accounts.ChangeGeneral(user);
        }
        public void ChangePassword(UserChangePasswordDTO model, string userName)
        {

            var userDb = _unitOfWork.Users.GetItem(userName);

            userDb.SecurityStamp = Guid.NewGuid().ToString();
            _unitOfWork.Accounts.ChangePassword(userDb, model.OldPassword, model.NewPassword);
        }
    }
}
