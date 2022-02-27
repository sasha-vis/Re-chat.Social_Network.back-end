using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BLL.ViewModels.Friend
{
    public class FriendsForUserVM
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; }

    }
}