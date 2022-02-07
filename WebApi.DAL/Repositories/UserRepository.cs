using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.DAL.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly ApplicationContext _db;
        public UserRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<User> GetList()
        {
            var users = _db.Users;
                //.Include(u => u.Phone)
                //.Include(p => p.City);

            return users;
        }
    }
}
