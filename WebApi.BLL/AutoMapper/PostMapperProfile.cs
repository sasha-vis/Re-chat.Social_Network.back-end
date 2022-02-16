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
            CreateMap<Post, PostGetVM>();

            //CreateMap<UserPostVM, User>()
            //    .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Email));

            //CreateMap<UserEditVM, User>();
        }
    }
}
