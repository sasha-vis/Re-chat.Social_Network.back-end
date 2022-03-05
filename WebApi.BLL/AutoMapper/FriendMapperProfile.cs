using AutoMapper;
using WebApi.BLL.DTO.Friend;
using WebApi.DAL.Entities;

namespace WebApi.BLL.AutoMapper
{
    public class FriendMapperProfile : Profile
    {
        public FriendMapperProfile()
        {
            CreateMap<CreateFriendDTO, FriendList>();

            CreateMap<FriendList, FriendDTO>()
                 .ForMember(c => c.FriendId, opt => opt.MapFrom(c => c.FriendId))
                 .ForMember(c => c.Email, opt => opt.MapFrom(c => c.Friend.Email))
                 .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Friend.Name))
                 .ForMember(c => c.Surname, opt => opt.MapFrom(c => c.Friend.Surname))
                 .ForMember(c => c.BirthdayDate, opt => opt.MapFrom(c => c.Friend.BirthdayDate))
                 .ForMember(c => c.Gender, opt => opt.MapFrom(c => c.Friend.Gender));

            CreateMap<FriendList, FriendsGetRequestByUserDTO>()
                 .ForMember(c => c.Email, opt => opt.MapFrom(c => c.User.Email))
                 .ForMember(c => c.Name, opt => opt.MapFrom(c => c.User.Name))
                 .ForMember(c => c.Surname, opt => opt.MapFrom(c => c.User.Surname))
                 .ForMember(c => c.BirthdayDate, opt => opt.MapFrom(c => c.User.BirthdayDate))
                 .ForMember(c => c.Gender, opt => opt.MapFrom(c => c.User.Gender));

            CreateMap<User, FriendsToAddGetByUserDTO>()
                 .ForMember(c => c.UserId, opt => opt.MapFrom(c => c.Id))
                 .ForMember(c => c.Email, opt => opt.MapFrom(c => c.Email))
                 .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Name))
                 .ForMember(c => c.Surname, opt => opt.MapFrom(c => c.Surname))
                 .ForMember(c => c.BirthdayDate, opt => opt.MapFrom(c => c.BirthdayDate))
                 .ForMember(c => c.Gender, opt => opt.MapFrom(c => c.Gender))
                 .ForMember(c => c.ExcludeFromSearch, opt => opt.MapFrom(c => c.ExcludeFromSearch));


            CreateMap<ResponseToRequareFriendsDTO, FriendList>();

            CreateMap<FriendList, FriendsForUserDTO>();

            CreateMap<DeleteFriendDTO, FriendList>();

        }
    }
}
