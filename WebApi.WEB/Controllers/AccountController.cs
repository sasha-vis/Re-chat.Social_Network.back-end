using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Response;
using WebApi.BLL.DTO.User;
using WebApi.WEB.Filters;

namespace WebApi.WEB.Controllers
{
    public class AccountController : BaseController
    {
        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("Registration")]
        [ValidateModel]
        public IActionResult Regiter(UserRegisterDTO model)
        {
            var result = _accountService.Register(model);
            if (result != null)
            {
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(result),
                    expiration = result.ValidTo
                });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists or registration was failed" });
        }

        [HttpPost]
        [Route("Login")]
        [ValidateModel]
        public IActionResult Login(UserLoginDTO model)
        {
            var result = _accountService.Login(model);
            if (result != null)
            {
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(result),
                    expiration = result.ValidTo
                });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Invalid login or password! Try again" });
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [Route("ChangePassword")]
        [ValidateModel]
        public IActionResult Put(UserChangePasswordDTO user)
        {
            _accountService.ChangePassword(user, User.Identity.Name);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [Route("ExcludeFromSearch")]
        public IActionResult ExcludeFromSearch()
        {
            _accountService.ExcludeFromSearch(User.Identity.Name);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [Route("ChangeGeneral")]
        [ValidateModel]
        public IActionResult ChangeGeneral(ChangeGeneralInfoUserDTO model)
        {
            _accountService.ChangeGeneral(model, User.Identity.Name);
            return Ok();
        }

    }
}
