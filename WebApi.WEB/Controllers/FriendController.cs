using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.Friend;
using WebApi.WEB.Filters;

namespace WebApi.WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class FriendController : BaseController
    {
        IFriendsService _friendsService;
        public FriendController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        [HttpGet]
        [Route("FriendsByUser")]
        public IActionResult GetByUser()
        {
            var result = _friendsService.FriendsByUser(User.Identity.Name);
            return Ok(result);
        }

        [HttpGet]
        [Route("FriendsRequestByUser")]
        public IActionResult GetRequestFriendsByUser()
        {
            var result = _friendsService.RequareFriendsByUser(User.Identity.Name);
            return Ok(result);
        }

        [HttpGet]
        [Route("FriendsToAddByUser")]
        public IActionResult GetFriendsToAddByUser()
        {
            var result = _friendsService.GetFriendsToAddByUser(User.Identity.Name);
            return Ok(result);
        }

        [HttpPost]
        [ValidateModel]
        public IActionResult Post(CreateFriendDTO friend)
        {
            _friendsService.Create(friend, User.Identity.Name);
            return Ok();
        }

        [HttpPut]
        [Route("ResponseToRequestFriend")]
        [ValidateModel]
        public IActionResult ResponseToRequestFriend(ResponseToRequareFriendsDTO model)
        {
            _friendsService.ResponseToRequareFriendsByUser(model, User.Identity.Name);
            return Ok();
        }

        [HttpDelete]
        [ValidateModel]
        public IActionResult Delete(DeleteFriendDTO friend)
        {
            _friendsService.DeleteFriend(friend, User.Identity.Name);
            return Ok();
        }

    }
}
