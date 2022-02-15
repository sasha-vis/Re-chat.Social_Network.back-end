using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        public string Gender { get; set; }
        public string BirthdayDate { get; set; }
        public string RegistrationDate { get; set; }


        public List<Post> Posts { get; set; }
        //public List<Comment> Comments { get; set; }
        //public List<Like> Likes { get; set; }

        //public List<FriendList> FriendLists { get; set; }
        //public List<RequestFriendList> RequestFriendLists { get; set; }
    }
}
