using AutoMapper;
using WebApi.BLL.DTO.Comment;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class CommentMapperProfile : Profile
    {
        public CommentMapperProfile()
        {
            CreateMap<CommentCreateDTO, Comment>();

            CreateMap<Comment, CommentForPostDTO>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Author.Name))
                .ForMember(c => c.UserSurname, opt => opt.MapFrom(c => c.Author.Surname));
        }
    }
}
