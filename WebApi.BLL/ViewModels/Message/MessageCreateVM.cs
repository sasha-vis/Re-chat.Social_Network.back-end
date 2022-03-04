using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BLL.ViewModels.Message
{
    public class MessageCreateVM
    {
        public string MessageText { get; set; }

        public int FriendListId { get; set; }
    }
}
