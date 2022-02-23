using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Comment;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.BLL.Services
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CommentService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void Create(CommentCreateVM model, string userName)
        {
            var userDB = _unitOfWork.Users.GetItem(userName);
            var comment = _mapper.Map<Comment>(model);
            comment.AuthorId = userDB.Id;
             _unitOfWork.Comments.Create(comment);
        }


        public void Delete(int id, string userName)
        {
            var userDB = _unitOfWork.Users.GetItem(userName);
            var comment = _unitOfWork.Comments.GetItem(id)
;
            if (userDB.Id == comment.AuthorId)
            {
                 _unitOfWork.Comments.Delete(id)
;
            }
        }
    }
}
