using AutoMapper;
using WebApi.BLL.ViewModels.User;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserGetVM>();

            //CreateMap<UserCreateVM, User>();

            //CreateMap<UserEditVM, User>();
        }
    }
}