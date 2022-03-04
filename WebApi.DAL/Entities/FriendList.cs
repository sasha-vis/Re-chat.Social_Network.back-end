using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Entities.Enums;

namespace WebApi.DAL.Entities
{
    public class FriendList
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string FriendId { get; set; }

        public User Friend { get; set; }

        public List<Message> Messages { get; set; }
        public StatusFriendship Status { get; set; }

    }
}
