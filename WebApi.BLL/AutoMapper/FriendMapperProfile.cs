using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.Friend;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class FriendMapperProfile : Profile
    {
        public FriendMapperProfile()
        {
            CreateMap<CreateFriendVM, FriendList>();

            CreateMap<FriendList, FriendVM>()
                 .ForMember(c => c.Email, opt => opt.MapFrom(c => c.Friend.Email))
                 .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Friend.Name))
                 .ForMember(c => c.Surname, opt => opt.MapFrom(c => c.Friend.Surname))
                 .ForMember(c => c.BirthdayDate, opt => opt.MapFrom(c => c.Friend.BirthdayDate))
                 .ForMember(c => c.Gender, opt => opt.MapFrom(c => c.Friend.Gender));

            CreateMap<FriendList, FriendVM>()
                 .ForMember(c => c.Email, opt => opt.MapFrom(c => c.Friend.Email))
                 .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Friend.Name))
                 .ForMember(c => c.Surname, opt => opt.MapFrom(c => c.Friend.Surname))
                 .ForMember(c => c.BirthdayDate, opt => opt.MapFrom(c => c.Friend.BirthdayDate))
                 .ForMember(c => c.Gender, opt => opt.MapFrom(c => c.Friend.Gender));

            CreateMap<ResponseToRequareFriends, FriendList>();

        }
    }
}
