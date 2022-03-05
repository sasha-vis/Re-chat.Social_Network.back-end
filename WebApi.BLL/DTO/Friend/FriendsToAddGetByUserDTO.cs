namespace WebApi.BLL.DTO.Friend
{
    public class FriendsToAddGetByUserDTO
    {
        public string? UserId { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Gender { get; set; }
        public string? BirthdayDate { get; set; }
        public int isFriend { get; set; }
        public bool ExcludeFromSearch { get; set; }
    }
}
