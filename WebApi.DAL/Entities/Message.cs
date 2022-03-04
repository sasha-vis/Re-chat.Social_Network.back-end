using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string? AuthorId { get; set; }
        public User? Author { get; set; }
        public string MessageText { get; set; }

        [ForeignKey("FriendList")]
        public int FriendListId { get; set; }
        public FriendList FriendList { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
