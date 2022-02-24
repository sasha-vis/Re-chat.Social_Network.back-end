using WebApi.BLL.ViewModels.Like;
using WebApi.BLL.ViewModels.Post;

namespace WebApi.BLL.ViewModels.User
{
    public class UserGetVM
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public string BirthdayDate { get; set; }

        public string RegistrationDate { get; set; }

        public string Email { get; set; }

        public int CountLikes { get; set; } 

        public List<PostGetVM> Posts { get; set; }
    }
}
