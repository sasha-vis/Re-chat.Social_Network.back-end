using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Post;
using WebApi.DAL.Interfaces;
using WebApi.DAL.Entities;

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

        public IEnumerable<PostGetVM> GetList()
        {
            var posts = _unitOfWork.Posts.GetList();

            var result = _mapper.Map<IEnumerable<PostGetVM>>(posts);

            return result;
        }

        public PostGetVM GetItem(int id)
        {
            var posts = _unitOfWork.Posts.GetItem(id);

            var result = _mapper.Map<PostGetVM>(posts);

            return result;
        }

        public IEnumerable<PostGetVM> GetMyPosts(string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);
            var posts = _unitOfWork.Posts.GetList();

            var myPosts = new List<Post>();

            foreach (var post in posts)
            {
                if (post.UserId == user.Id)
                    myPosts.Add(post);
            }

            var result = _mapper.Map<IEnumerable<PostGetVM>>(myPosts);

            return result;
        }

        public IEnumerable<PostGetVM> GetFavoritesPosts(string userName)
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
            var result = _mapper.Map<IEnumerable<PostGetVM>>(faivoritePosts);

            return result;

        }

        public IEnumerable<PostGetVM> GetBookmarksPosts(string userName)
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
            var result = _mapper.Map<IEnumerable<PostGetVM>>(bookmarksPosts);

            return result;

        }

        public void Create(PostCreateVM model, string userName)
        {
            var post = _mapper.Map<Post>(model);
            _unitOfWork.Posts.Create(post, userName);
        }

        public void Edit(PostEditVM model)
        {
            var post = _unitOfWork.Posts.GetItem(model.Id);

            post.Title = model.Title;
            post.Content = model.Content;

            _unitOfWork.Posts.Edit(post);
        }

        public void Delete(int id)
        {
            _unitOfWork.Posts.Delete(id);
        }
    }
}
