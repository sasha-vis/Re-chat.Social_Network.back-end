using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.Post;
using WebApi.WEB.Filters;

namespace WebApi.WEB.Controllers
{
    public class PostController : BaseController
    {
        private IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IEnumerable<PostGetDTO> Get()
        {
            var result = _postService.GetList();
            return result;
        }

        [HttpGet("{id}")]
        [ValidateModel]
        public PostGetDTO Get(int id)
        {
            var result = _postService.GetItem(id);
            return result;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("MyPosts")]
        public IEnumerable<PostGetDTO> GetMyPosts()
        {
            var result = _postService.GetMyPosts(User.Identity.Name);
            return result;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("Favorites")]
        public IEnumerable<PostGetDTO> GetFavoritesPosts()
        {
            var result = _postService.GetFavoritesPosts(User.Identity.Name);
            return result;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("Bookmarks")]
        public IEnumerable<PostGetDTO> GetBookmarksPosts()
        {
            var result = _postService.GetBookmarksPosts(User.Identity.Name);
            return result;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [ValidateModel]
        public IActionResult Post(PostCreateDTO model)
        {
            _postService.Create(model, User.Identity.Name);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [ValidateModel]
        public IActionResult Put(PostEditDTO model)
        {
            _postService.Edit(model, User.Identity.Name);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{id}")]
        [ValidateModel]
        public IActionResult Delete(int id)
        {
            _postService.Delete(id, User.Identity.Name);
            return Ok();
        }
    }
}
