using WebApi.BLL.DTO.Bookmark;
using WebApi.BLL.DTO.Comment;
using WebApi.BLL.DTO.Like;

namespace WebApi.BLL.DTO.Post
{
    public class PostGetDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public DateTime PostDate { get; set; }
        public List<LikeForPostDTO>? Likes { get; set; }
        public List<CommentForPostDTO>? Comments { get; set; }
        public List<BookmarkForPostDTO>? Bookmarks { get; set; }
    }
}
