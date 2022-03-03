using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Post;
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
        public IEnumerable<PostGetVM> Get()
        {
            var result = _postService.GetList();
            return result;
        }

        [HttpGet("{id}")]
        public PostGetVM Get(int id)
        {
            var result = _postService.GetItem(id);
            return result;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("MyPosts")]
        public IEnumerable<PostGetVM> GetMyPosts()
        {
            return _postService.GetMyPosts(User.Identity.Name);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("Favorites")]
        public IEnumerable<PostGetVM> GetFavoritesPosts()
        {
            return _postService.GetFavoritesPosts(User.Identity.Name);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("Bookmarks")]
        public IEnumerable<PostGetVM> GetBookmarksPosts()
        {
            return _postService.GetBookmarksPosts(User.Identity.Name);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [ValidateModel]
        public IActionResult Post(PostCreateVM model)
        {
            _postService.Create(model, User.Identity.Name);

            return Ok(_postService.GetMyPosts(User.Identity.Name));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("Create")]
        [ValidateModel]
        public IEnumerable<PostGetVM> PostFromMain(PostCreateVM model)
        {
            _postService.Create(model, User.Identity.Name);

            var result = _postService.GetList();
            return result;
        }


        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public IActionResult Put(PostEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _postService.Edit(model);
            return Ok(_postService.GetList());
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _postService.Delete(id);
            return Ok(_postService.GetMyPosts(User.Identity.Name));
        }
    }
}
