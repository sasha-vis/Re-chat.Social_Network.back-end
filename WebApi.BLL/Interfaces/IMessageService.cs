using WebApi.BLL.DTO.Message;

namespace WebApi.BLL.Interfaces
{
    public interface IMessageService
    {
        void Create(MessageCreateDTO model, string userName);
    }
}
