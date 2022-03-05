using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.Comment;
using WebApi.WEB.Filters;

namespace WebApi.WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CommentController : BaseController
    {
        ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [ValidateModel]
        public IActionResult Post(CommentCreateDTO comment)
        {
            _commentService.Create(comment, User.Identity.Name);
            return Ok();
        }
    }
}

