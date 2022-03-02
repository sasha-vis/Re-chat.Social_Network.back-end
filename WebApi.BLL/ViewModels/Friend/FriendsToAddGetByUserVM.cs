using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BLL.ViewModels.Friend
{
    public class FriendsToAddGetByUserVM
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public string BirthdayDate { get; set; }
        public int isFriend { get; set; }
        public bool ExcludeFromSearch { get; set; }
    }
}
