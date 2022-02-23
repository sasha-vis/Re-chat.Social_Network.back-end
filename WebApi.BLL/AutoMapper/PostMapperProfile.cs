using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.Post;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class PostMapperProfile : Profile
    {
        public PostMapperProfile()
        {
            CreateMap<Post, PostGetVM>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.Name))
                .ForMember(c => c.UserSurname, opt => opt.MapFrom(c => c.User.Surname));

            CreateMap<PostCreateVM, Post>();

            CreateMap<PostEditVM, Post>();

            //CreateMap<UserPostVM, User>()
            //    .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Email));

            //CreateMap<UserEditVM, User>();
        }
    }
}
