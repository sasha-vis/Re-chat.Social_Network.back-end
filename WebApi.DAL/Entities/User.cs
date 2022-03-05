using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string? Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string? Surname { get; set; }
        public string? Gender { get; set; }
        public string? BirthdayDate { get; set; }
        public string? RegistrationDate { get; set; }
        public bool ExcludeFromSearch { get; set; }
        public List<Post>? Posts { get; set; }
        public List<FriendList>? FriendLists { get; set; }
    }
}
