using WebApi.BLL.DTO.Post;

namespace WebApi.BLL.Interfaces
{
    public interface IPostService
    {
        public IEnumerable<PostGetDTO> GetList();
        public PostGetDTO GetItem(int id);
        public IEnumerable<PostGetDTO> GetMyPosts(string userName);
        public IEnumerable<PostGetDTO> GetFavoritesPosts(string userName);
        public IEnumerable<PostGetDTO> GetBookmarksPosts(string userName);
        public void Create(PostCreateDTO model, string userName);
        public void Edit(PostEditDTO model, string userName);
        public void Delete(int id, string userName);
    }
}
