using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.DTO.Message;
using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.BLL.Services
{
    public class MessageService : IMessageService
    {
        private IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public MessageService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public void Create(MessageCreateDTO model, string userName)
        {
            var userDB = _unitOfWork.Users.GetItem(userName);

            var friendshipsDB = _unitOfWork.Friends.FriendsByUser(userName);

            foreach (var friend in friendshipsDB)
            {
                if (friend.Id == model.FriendListId)
                {
                    var message = _mapper.Map<Message>(model);
                    message.AuthorId = userDB.Id;
                    _unitOfWork.Messages.Create(message);
                }
            }
        }
    }
}