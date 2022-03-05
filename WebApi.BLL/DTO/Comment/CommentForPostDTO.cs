using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BLL.DTO.Comment
{
    public class CommentForPostDTO
    {
        public int Id { get; set; }

        public string? AuthorId { get; set; }

        public string? CommentText { get; set; }

        public int PostId { get; set; }

        public string? UserName { get; set; }
        public string? UserSurname { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
