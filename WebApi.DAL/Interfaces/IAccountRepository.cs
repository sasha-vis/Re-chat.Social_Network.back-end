using System.IdentityModel.Tokens.Jwt;

namespace WebApi.DAL.Interfaces
{
    public interface IAccountRepository<T> where T : class
    {
        public Task<JwtSecurityToken> Register(T item, string password);
        public JwtSecurityToken Login(T item, string password);
        public void ExcludeFromSearch(T item);
        public void ChangeGeneral(T item);
        public void ChangePassword(T user, string oldPassword, string newPassword);
    }
}
