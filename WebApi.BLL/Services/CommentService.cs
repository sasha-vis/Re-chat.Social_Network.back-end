using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.Comment;
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
        public void Create(CommentCreateDTO model, string userName)
        {
            var userDB = _unitOfWork.Users.GetItem(userName);
            var comment = _mapper.Map<Comment>(model);
            comment.AuthorId = userDB.Id;
            _unitOfWork.Comments.Create(comment);
        }
    }
}
