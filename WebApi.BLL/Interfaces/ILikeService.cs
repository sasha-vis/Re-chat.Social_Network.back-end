using WebApi.BLL.DTO.Like;

namespace WebApi.BLL.Interfaces
{
    public interface ILikeService
    {
        public void Create(LikeCreateDTO model, string userName);
    }
}
