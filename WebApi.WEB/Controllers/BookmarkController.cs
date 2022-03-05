using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.Bookmark;
using WebApi.WEB.Filters;

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
        [ValidateModel]
        public IActionResult Post(BookmarkCreateDTO bookmark)
        {
            _bookmarkService.Create(bookmark, User.Identity.Name);
            return Ok();
        }
    }
}
