using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Friend;

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
        public IActionResult Post(CreateFriendVM friend)
        {
            _friendsService.Create(friend, User.Identity.Name);
            return Ok();
        }

        [HttpPut]
        [Route("ResponseToRequestFriend")]
        public IActionResult ResponseToRequestFriend(ResponseToRequareFriends model)
        {
            if (!ModelState.IsValid)
            {
                return ResponseToRequestFriend(model);
            }
            _friendsService.ResponseToRequareFriendsByUser(model, User.Identity.Name);
            return Ok(_friendsService.RequareFriendsByUser(User.Identity.Name));
        }

        [HttpDelete]
        public IActionResult Delete(DeleteFriendVM model)
        {
            if (!ModelState.IsValid)
            {
                return Delete(model);
            }
            _friendsService.DeleteFriend(model, User.Identity.Name);
            return Ok(_friendsService.FriendsByUser(User.Identity.Name));
        }

    }
}
