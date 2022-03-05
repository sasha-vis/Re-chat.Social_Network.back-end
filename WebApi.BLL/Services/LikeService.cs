using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.Like;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.BLL.Services
{
    public class LikeService : ILikeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public LikeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Create(LikeCreateDTO model, string userName)
        {
            var user = _unitOfWork.Users.GetItem(userName);
            var like = _mapper.Map<Like>(model);
            like.UserId = user.Id;
            _unitOfWork.Likes.Create(like);
        }

    }
}
