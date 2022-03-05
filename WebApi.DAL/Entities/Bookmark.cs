using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Entities
{
    public class Bookmark
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}