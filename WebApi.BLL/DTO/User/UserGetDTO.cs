using WebApi.BLL.DTO.Post;

namespace WebApi.BLL.DTO.User
{
    public class UserGetDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Gender { get; set; }
        public string? BirthdayDate { get; set; }
        public string? RegistrationDate { get; set; }
        public string? Email { get; set; }
        public bool IsFriend { get; set; }
        public int CountLikes { get; set; }
        public int CountBookmarks { get; set; }
        public int CountFriends { get; set; }
        public bool ExcludeFromSearch { get; set; }
        public List<PostGetDTO>? Posts { get; set; }
    }
}
