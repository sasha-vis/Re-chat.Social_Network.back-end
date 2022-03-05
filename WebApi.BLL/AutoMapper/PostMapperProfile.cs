using AutoMapper;
using WebApi.BLL.DTO.Post;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class PostMapperProfile : Profile
    {
        public PostMapperProfile()
        {
            CreateMap<Post, PostGetDTO>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.Name))
                .ForMember(c => c.UserSurname, opt => opt.MapFrom(c => c.User.Surname));

            CreateMap<PostCreateDTO, Post>();

            CreateMap<PostEditDTO, Post>();
        }
    }
}
