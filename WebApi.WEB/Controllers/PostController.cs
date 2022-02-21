using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Post;

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
        [HttpPost]
        public IActionResult Post(PostCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _postService.Create(model, User.Identity.Name);

            return Ok(_postService.GetMyPosts(User.Identity.Name));
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
