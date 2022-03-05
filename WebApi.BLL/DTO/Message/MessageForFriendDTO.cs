namespace WebApi.BLL.DTO.Message
{
    public class MessageForFriendDTO
    {
        public int Id { get; set; }
        public string? AuthorId { get; set; }
        public string? MessageText { get; set; }
        public int FriendListId { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public DateTime MessageDate { get; set; }
    }
}