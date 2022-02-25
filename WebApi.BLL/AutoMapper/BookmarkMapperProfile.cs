using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.Bookmark;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class BookmarkMapperProfile : Profile
    {
        public BookmarkMapperProfile()
        {
            CreateMap<Bookmark, BookmarkForPostVM>()
               .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.Name))
               .ForMember(c => c.UserSurname, opt => opt.MapFrom(c => c.User.Surname));

            CreateMap<BookmarkCreateVM, Bookmark>();
        }
    }
}