using System.ComponentModel.DataAnnotations;

namespace WebApi.BLL.DTO.Comment
{
    public class CommentCreateDTO
    {
        [Required(ErrorMessage = "Comment can't be empty")]
        [MinLength(1, ErrorMessage = "Comment must contain 1 symbol at least")]
        public string? CommentText { get; set; }
        public int PostId { get; set; }
    }
}
