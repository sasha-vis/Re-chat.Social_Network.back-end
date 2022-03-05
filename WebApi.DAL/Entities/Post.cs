using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string? Title { get; set; }
        [Required]
        [MinLength(1)]
        public string? Content { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public List<Like>? Likes { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Bookmark>? Bookmarks { get; set; }
        public DateTime PostDate { get; set; }
    }
}