using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Message;
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

        public void Create(MessageCreateVM model, string userName)
        {
            var userDB = _unitOfWork.Users.GetItem(userName);
            var message = _mapper.Map<Message>(model);
            message.AuthorId = userDB.Id;
            _unitOfWork.Messages.Create(message);
        }
    }
}