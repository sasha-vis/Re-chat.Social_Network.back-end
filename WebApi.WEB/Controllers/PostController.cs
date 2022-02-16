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
    }
}
