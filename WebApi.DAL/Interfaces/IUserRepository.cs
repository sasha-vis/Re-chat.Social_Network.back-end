using System.IdentityModel.Tokens.Jwt;

namespace WebApi.DAL.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        public IEnumerable<T> GetList();
        //public T GetItem(int id);
        public Task<JwtSecurityToken> Create(T item, string password);
        //public void Edit(T item);
        //public void Delete(int Id);
    }
}