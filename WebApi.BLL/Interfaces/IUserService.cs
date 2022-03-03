using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.User;

namespace WebApi.BLL.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserGetVM> GetList(string UserName);

        public UserGetVM GetItem(string userName);

        public void ExcludeFromSearch(string userName);

        public void ChangeGeneral(ChangeGeneralInfoUserVM model, string userName);

        public JwtSecurityToken Register(UserRegisterVM model);

        public JwtSecurityToken Login(UserLoginVM model);
    }
}
