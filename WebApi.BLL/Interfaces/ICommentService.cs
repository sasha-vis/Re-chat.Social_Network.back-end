using WebApi.BLL.DTO.Comment;

namespace WebApi.BLL.Interfaces
{
    public interface ICommentService
    {
        void Create(CommentCreateDTO model, string userName);
    }
}
