using System.IdentityModel.Tokens.Jwt;
using WebApi.BLL.DTO.User;

namespace WebApi.BLL.Interfaces
{
    public interface IAccountService
    {
        public void ExcludeFromSearch(string userName);
        public void ChangeGeneral(ChangeGeneralInfoUserDTO model, string userName);
        public JwtSecurityToken Register(UserRegisterDTO model);
        public JwtSecurityToken Login(UserLoginDTO model);
        public void ChangePassword(UserChangePasswordDTO model, string userName);
    }
}
