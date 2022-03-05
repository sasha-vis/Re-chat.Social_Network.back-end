using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.DAL.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly ApplicationContext _db;

        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public UserRepository(ApplicationContext context,
            IConfiguration configuration,
            UserManager<User> userManager)
        {
            _db = context;
            _configuration = configuration;
            _userManager = userManager;
        }
        public IEnumerable<User> GetList()
        {
            var users = _db.Users
                .Include(u => u.FriendLists);

            return users;
        }
        public User GetItem(string userName)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == userName);
            var result = _db.Users
                .Where(c => c.Id == user.Id)
                .Include(u => u.Posts)
                .FirstOrDefault();

            return result;
        }
    }
}
