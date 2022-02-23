using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Like;
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

        public void Create(LikeCreateVM model, string userName)
        {
         var user = _unitOfWork.Users.GetItem(userName);   
            var like = _mapper.Map<Like>(model);
            like.UserId = user.Id;
            _unitOfWork.Likes.Create(like);
        }

    }
}
