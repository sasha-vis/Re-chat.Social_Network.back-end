using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BLL.ViewModels.Message
{
    public class MessageForFriendVM
    {
        public int Id { get; set; }

        public string? AuthorId { get; set; }

        public string MessageText { get; set; }

        public int FriendListId { get; set; }

        public string UserName { get; set; }
        public string UserSurname { get; set; }

        public DateTime MessageDate { get; set; }
    }
}