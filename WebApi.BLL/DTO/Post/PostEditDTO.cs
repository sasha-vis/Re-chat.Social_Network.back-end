using System.ComponentModel.DataAnnotations;

namespace WebApi.BLL.DTO.Post
{
    public class PostEditDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title can't be empty")]
        [MinLength(1, ErrorMessage = "Title must contain 1 symbol at least")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Content field can't be empty")]
        [MinLength(1, ErrorMessage = "Content field must contain 1 symbol at least")]
        public string? Content { get; set; }
    }
}
