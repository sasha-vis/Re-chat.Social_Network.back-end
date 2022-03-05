using AutoMapper;
using WebApi.BLL.DTO.Like;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class LikeMapperProfile : Profile
    {
        public LikeMapperProfile()
        {
            CreateMap<Like, LikeForPostDTO>()
               .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.Name))
               .ForMember(c => c.UserSurname, opt => opt.MapFrom(c => c.User.Surname));

            CreateMap<LikeCreateDTO, Like>();
        }
    }
}
