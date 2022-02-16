using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Post;
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

        public IEnumerable<PostGetVM> GetList()
        {
            var posts = _unitOfWork.Posts.GetList();

            var result = _mapper.Map<IEnumerable<PostGetVM>>(posts);

            return result;
        }
    }
}
