using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Bookmark;

namespace WebApi.WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class BookmarkController : BaseController
    {
        IBookmarkService _bookmarkService;
        public BookmarkController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        [HttpPost]
        public IActionResult Post(BookmarkCreateVM bookmark)
        {
            if (!ModelState.IsValid)
            {
                return Post(bookmark);
            }
            _bookmarkService.Create(bookmark, User.Identity.Name);
            return Ok();
        }
    }
}
