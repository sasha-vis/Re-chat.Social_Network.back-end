using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.User;

namespace WebApi.WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : BaseController
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserGetDTO> Get()
        {
            var result = _userService.GetList(User.Identity.Name);
            return result;
        }

        [HttpGet]
        [Route("Profile")]
        public UserGetDTO GetProfile()
        {
            return _userService.GetItem(User.Identity.Name);
        }
    }
}
