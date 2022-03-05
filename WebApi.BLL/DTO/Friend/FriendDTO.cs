using WebApi.BLL.DTO.Message;

namespace WebApi.BLL.DTO.Friend
{
    public class FriendDTO
    {
        public string? Id { get; set; }
        public string? FriendId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Gender { get; set; }
        public string? BirthdayDate { get; set; }
        public string? RegistrationDate { get; set; }
        public string? Email { get; set; }
        public List<MessageForFriendDTO>? Messages { get; set; }

    }
}
