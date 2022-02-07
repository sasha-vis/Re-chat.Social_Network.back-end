using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PostContent { get; set; }

        public User User { get; set; }
        public List<Like> Likes { get; set;}
        public List<Comment> Comments { get; set;}
    }
}