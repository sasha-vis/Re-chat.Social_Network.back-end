using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
            _db=context;
            _configuration = configuration;
            _userManager = userManager;
        }

        public IEnumerable<User> GetList()
        {
            var users = _db.Users;
                //.Include(u => u.Phone)
                //.Include(p => p.City);

            return users;
        }

        public User GetItem(string Id)
        {

            var user = _db.Users
                .Where(c => c.Id == Id)
                .FirstOrDefault();

            return user;
        }

        public JwtSecurityToken Login(User model, string password)
        {
            var user =  _userManager.FindByNameAsync(model.Email).Result;
            if (user != null &&  _userManager.CheckPasswordAsync(user, password).Result)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Id", user.Id)
                };

                var token = GetToken(authClaims);

                return (token);
            }
            return null;
        }


        public async Task<JwtSecurityToken> Register(User model, string password)
        {
            var userExists = _userManager.FindByNameAsync(model.Email).Result;
            if (userExists == null)
            {
                await _userManager.CreateAsync(model, password);
                return Login(model, password);
            }
            return null;
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JWT:Expires"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
