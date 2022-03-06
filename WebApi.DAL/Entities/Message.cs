using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string? AuthorId { get; set; }
        public User? Author { get; set; }
        public string? MessageText { get; set; }
        [ForeignKey("FriendListId")]
        public int FriendListId { get; set; }
        public FriendList? FriendList { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
