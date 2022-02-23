using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Comment;

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
        public IActionResult Post(CommentCreateVM comment)
        {
            if (!ModelState.IsValid)
            {
                return Post(comment);
            }
            _commentService.Create(comment, User.Identity.Name);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                 _commentService.Delete(id.Value, User.Identity.Name);
                return Ok();
            }
            return NotFound();
        }
    }
}

