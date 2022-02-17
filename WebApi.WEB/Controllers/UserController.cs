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

        [HttpGet("{id}")]
        public UserGetVM Get(string id)
        {
            var result = _userService.GetItem(id);
            return result;
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
                    expiration = result.ValidTo,
                    user = result.Claims.Select(claim => claim.Value)
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
                    expiration = result.ValidTo,
                    user = result.Claims.Select(claim => claim.Value)
                });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists! or User Create Failed" });
        }
    }
}
