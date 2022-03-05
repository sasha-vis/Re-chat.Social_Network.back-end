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
            return Ok(_friendsService.FriendsByUser(User.Identity.Name));
        }

        [HttpGet]
        [Route("FriendsRequestByUser")]
        public IActionResult GetRequestFriendsByUser()
        {
            return Ok(_friendsService.RequareFriendsByUser(User.Identity.Name));
        }

        [HttpGet]
        [Route("FriendsToAddByUser")]
        public IActionResult GetFriendsToAddByUser()
        {
            return Ok(_friendsService.GetFriendsToAddByUser(User.Identity.Name));
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
            return Ok(_friendsService.RequareFriendsByUser(User.Identity.Name));
        }

        [HttpDelete]
        [ValidateModel]
        public IActionResult Delete(DeleteFriendDTO friend)
        {
            _friendsService.DeleteFriend(friend, User.Identity.Name);
            return Ok(_friendsService.FriendsByUser(User.Identity.Name));
        }

    }
}
