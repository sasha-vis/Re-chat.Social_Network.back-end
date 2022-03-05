using AutoMapper;
using WebApi.BLL.DTO.Message;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class MessageMapperProfile : Profile
    {
        public MessageMapperProfile()
        {

            CreateMap<MessageCreateDTO, Message>();

            CreateMap<Message, MessageForFriendDTO>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Author.Name))
                .ForMember(c => c.UserSurname, opt => opt.MapFrom(c => c.Author.Surname));
        }
    }
}
