using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Response;
using WebApi.BLL.ViewModels.User;

namespace WebApi.WEB.Controllers
{
    public class AccountController : BaseController
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Registration")]
        public IActionResult Regiter(UserRegisterVM model)
        {
            var result = _userService.Register(model);
            if (result != null)
            {
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(result),
                    expiration = result.ValidTo
                });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists! or User Create Failed" });
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserLoginVM model)
        {
            var result = _userService.Login(model);
            if (result != null)
            {
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(result),
                    expiration = result.ValidTo
                });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists! or User Create Failed" });
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [Route("ChangePassword")]
        public IActionResult Put(UserChangePasswordVM user)
        {
             _userService.ChangePassword(user, User.Identity.Name);
            return Ok();
        }

    }
}
