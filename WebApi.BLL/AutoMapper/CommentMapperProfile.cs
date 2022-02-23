using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.Comment;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class CommentMapperProfile : Profile
    {
        public CommentMapperProfile()
        {

            CreateMap<CommentCreateVM, Comment>();

            CreateMap<Comment, CommentForPostVM>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Author.Name))
                .ForMember(c => c.UserSurname, opt => opt.MapFrom(c => c.Author.Surname));
        }
    }
}
