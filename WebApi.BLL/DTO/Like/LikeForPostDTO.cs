namespace WebApi.BLL.DTO.Like
{
    public class LikeForPostDTO
    {
        public int PostId { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
    }
}
