using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.Message;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class MessageMapperProfile : Profile
    {
        public MessageMapperProfile()
        {

            CreateMap<MessageCreateVM, Message>();

            CreateMap<Message, MessageForFriendVM>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Author.Name))
                .ForMember(c => c.UserSurname, opt => opt.MapFrom(c => c.Author.Surname));
        }
    }
}
