namespace WebApi.BLL.DTO.Friend
{
    public class FriendsGetRequestByUserDTO
    {
        public string? UserId { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Gender { get; set; }
        public string? BirthdayDate { get; set; }
    }
}
