using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.DAL.Repositories
{
    public class AccountRepository : IAccountRepository<User>
    {
        private readonly ApplicationContext _db;

        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public AccountRepository(ApplicationContext context,
            IConfiguration configuration,
            UserManager<User> userManager)
        {
            _db = context;
            _configuration = configuration;
            _userManager = userManager;
        }
        public JwtSecurityToken Login(User model, string password)
        {
            var user = _userManager.FindByNameAsync(model.Email).Result;
            if (user != null && _userManager.CheckPasswordAsync(user, password).Result)
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
        public void ExcludeFromSearch(User user)
        {
            if (user.ExcludeFromSearch == true)
            {
                user.ExcludeFromSearch = false;
            }
            else
            {
                user.ExcludeFromSearch = true;
            }
            _db.SaveChanges();
        }
        public void ChangeGeneral(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }
        public void ChangePassword(User user, string currentPassword, string newPassword)
        {
            _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            _db.SaveChanges();
        }
    }
}
