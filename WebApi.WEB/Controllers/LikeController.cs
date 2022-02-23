using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Like;

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
        public IActionResult Post(LikeCreateVM like)
        {
            if (!ModelState.IsValid)
            {
                return Post(like);
            }
             _likeService.Create(like, User.Identity.Name);
            return Ok();
        }
    }
}
