using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.Post;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.BLL.Services
{
    public class PostService : IPostService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<PostGetDTO> GetList()
        {
            var posts = _unitOfWork.Posts.GetList();

            var result = _mapper.Map<IEnumerable<PostGetDTO>>(posts);

            return result;
        }
        public PostGetDTO GetItem(int id)
        {
            var posts = _unitOfWork.Posts.GetItem(id);

            var result = _mapper.Map<PostGetDTO>(posts);

            return result;
        }
        public IEnumerable<PostGetDTO> GetMyPosts(string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);
            var posts = _unitOfWork.Posts.GetList();

            var myPosts = new List<Post>();

            foreach (var post in posts)
            {
                if (post.UserId == user.Id)
                    myPosts.Add(post);
            }

            var result = _mapper.Map<IEnumerable<PostGetDTO>>(myPosts);

            return result;
        }
        public IEnumerable<PostGetDTO> GetFavoritesPosts(string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);
            var posts = _unitOfWork.Posts.GetList();
            var likes = _unitOfWork.Likes.LikesOfUser(user.Id);

            var faivoritePosts = new List<Post>();

            foreach (var l in likes)
            {
                foreach (var post in posts)
                {
                    if (post.Id == l.PostId)
                        faivoritePosts.Add(post);
                }
            }
            var result = _mapper.Map<IEnumerable<PostGetDTO>>(faivoritePosts);

            return result;

        }
        public IEnumerable<PostGetDTO> GetBookmarksPosts(string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);
            var posts = _unitOfWork.Posts.GetList();
            var bookmarks = _unitOfWork.Bookmarks.BookmarksOfUser(user.Id);

            var bookmarksPosts = new List<Post>();

            foreach (var l in bookmarks)
            {
                foreach (var post in posts)
                {
                    if (post.Id == l.PostId)
                        bookmarksPosts.Add(post);
                }
            }
            var result = _mapper.Map<IEnumerable<PostGetDTO>>(bookmarksPosts);

            return result;
        }
        public void Create(PostCreateDTO model, string userName)
        {
            var post = _mapper.Map<Post>(model);
            _unitOfWork.Posts.Create(post, userName);
        }
        public void Edit(PostEditDTO model, string userName)
        {
            var post = _unitOfWork.Posts.GetItem(model.Id);

            var user = _unitOfWork.Users.GetItem(userName);

            if (post != null && user.Id == post.UserId)
            {
                post.Title = model.Title;
                post.Content = model.Content;

                _unitOfWork.Posts.Edit(post);
            }
        }
        public void Delete(int id, string userName)
        {
            var post = _unitOfWork.Posts.GetItem(id);
            var user = _unitOfWork.Users.GetItem(userName);

            if (post != null && user.Id == post.UserId)
            {
                _unitOfWork.Posts.Delete(post);
            }
        }
    }
}
