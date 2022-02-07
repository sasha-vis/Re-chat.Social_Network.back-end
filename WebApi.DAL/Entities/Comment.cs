using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public string CommentContent { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }
    }
}
