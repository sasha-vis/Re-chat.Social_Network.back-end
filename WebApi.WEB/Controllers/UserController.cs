using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Response;
using WebApi.BLL.ViewModels.User;

namespace WebApi.WEB.Controllers
{ 
    public class UserController : BaseController
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserGetVM> Get()
        {
            var result = _userService.GetList();
            return result;
        }

        [HttpPost]
        public IActionResult Post(UserPostVM model)
        {
            var result = _userService.Post(model);
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
    }
}
