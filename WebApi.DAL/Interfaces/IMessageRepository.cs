using WebApi.DAL.Entities;

namespace WebApi.DAL.Interfaces
{
    public interface IMessageRepository<T> where T : class
    {
        void Create(Message message);
    }
}
