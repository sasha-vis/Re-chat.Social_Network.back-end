using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.DTO.Like;
using WebApi.BLL.Interfaces;
using WebApi.WEB.Filters;

namespace WebApi.WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class LikeController : BaseController
    {
        ILikeService _likeService;
        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        [ValidateModel]
        public IActionResult Post(LikeCreateDTO like)
        {
            _likeService.Create(like, User.Identity.Name);
            return Ok();
        }
    }
}
