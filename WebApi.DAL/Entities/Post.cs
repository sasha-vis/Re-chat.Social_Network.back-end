using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL.Entities
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Bookmark> Bookmarks { get; set; }

        public DateTime PostDate { get; set; }
    }
}