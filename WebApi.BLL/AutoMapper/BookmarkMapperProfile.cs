using AutoMapper;
using WebApi.BLL.DTO.Bookmark;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class BookmarkMapperProfile : Profile
    {
        public BookmarkMapperProfile()
        {
            CreateMap<Bookmark, BookmarkForPostDTO>()
               .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.Name))
               .ForMember(c => c.UserSurname, opt => opt.MapFrom(c => c.User.Surname));

            CreateMap<BookmarkCreateDTO, Bookmark>();
        }
    }
}