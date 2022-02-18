using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.User;

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
    }
}
