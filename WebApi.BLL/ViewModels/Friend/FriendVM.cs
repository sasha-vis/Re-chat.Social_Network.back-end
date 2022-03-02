using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BLL.ViewModels.Friend
{
    public class FriendVM
    {
        public string Id { get; set; }

        public string FriendId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public string BirthdayDate { get; set; }

        public string RegistrationDate { get; set; }

        public string Email { get; set; }

    }
}
