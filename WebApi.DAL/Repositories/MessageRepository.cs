using WebApi.DAL.Entities;
using WebApi.DAL.Interfaces;

namespace WebApi.DAL.Repositories
{
    public class MessageRepository : IMessageRepository<Message>
    {
        private readonly ApplicationContext _db;

        public MessageRepository(ApplicationContext context)
        {
            _db = context;
        }
        public void Create(Message message)
        {
            message.MessageDate = DateTime.Now;
            _db.Messages.Add(message);
            _db.SaveChangesAsync();
        }
    }
}
