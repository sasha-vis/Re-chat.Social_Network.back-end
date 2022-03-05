using AutoMapper;
using WebApi.BLL.DTO.User;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserGetDTO>();

            CreateMap<UserRegisterDTO, User>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Email));

            CreateMap<UserLoginDTO, User>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Email));
        }
    }
}