using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.DAL.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? AuthorId { get; set; }
        public User? Author { get; set; }
        [Required]
        [MinLength(1)]
        public string? CommentText { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public DateTime CommentDate { get; set; }
    }
}

