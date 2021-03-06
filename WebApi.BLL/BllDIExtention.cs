using Microsoft.Extensions.DependencyInjection;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Services;
using WebApi.DAL;

namespace WebApi.BLL
{
    public static class BllDIExtention
    {
        public static void RegisterBllDependencies(this IServiceCollection services)
        {
            services.RegisterDalDependencies();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ILikeService, LikeService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IBookmarkService, BookmarkService>();
            services.AddTransient<IFriendsService, FriendService>();
            services.AddTransient<IMessageService, MessageService>();
        }
    }
}

