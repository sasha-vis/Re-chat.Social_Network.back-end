using WebApi.BLL.DTO.Friend;

namespace WebApi.BLL.Interfaces
{
    public interface IFriendsService
    {
        List<FriendDTO> FriendsByUser(string userName);
        List<FriendsGetRequestByUserDTO> RequareFriendsByUser(string userName);
        List<FriendsToAddGetByUserDTO> GetFriendsToAddByUser(string userName);
        void ResponseToRequareFriendsByUser(ResponseToRequareFriendsDTO model, string userName);
        void DeleteFriend(DeleteFriendDTO model, string userName);
        void Create(CreateFriendDTO model, string userName);
    }
}
