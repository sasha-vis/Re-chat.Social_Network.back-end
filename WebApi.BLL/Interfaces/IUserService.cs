using WebApi.BLL.DTO.User;

namespace WebApi.BLL.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserGetDTO> GetList(string UserName);

        public UserGetDTO GetItem(string userName);
    }
}
