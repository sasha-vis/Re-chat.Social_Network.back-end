using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.Friend;

namespace WebApi.BLL.Interfaces
{
    public interface IFriendsService
    {
        List<FriendVM> FriendsByUser(string userName);

        List<FriendVM> RequareFriendsByUser(string userName);

        void ResponseToRequareFriendsByUser(ResponseToRequareFriends model, string userName);

        void Create(CreateFriendVM model, string userName);
    }
}
