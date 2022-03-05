namespace WebApi.BLL.DTO.Bookmark
{
    public class BookmarkForPostDTO
    {
        public int PostId { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
    }
}