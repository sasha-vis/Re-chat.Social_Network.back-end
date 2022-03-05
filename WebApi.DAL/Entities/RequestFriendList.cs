using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Entities
{
    public class RequestFriendList
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? FriendId { get; set; }
        public User? User { get; set; }
    }
}
