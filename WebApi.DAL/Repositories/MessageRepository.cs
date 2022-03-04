using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public Message GetItem(int id)
        {
            var message = _db.Messages
                .Where(p => p.Id == id)
                .Include(a => a.Author)
                .FirstOrDefault();

            return message;
        }


        public void Create(Message message)
        {
            //DateTime date = DateTime.Now;
            //string dateString = date.ToString("g");

            message.MessageDate = DateTime.Now;
            _db.Messages.Add(message);
            _db.SaveChangesAsync();
        }
    }
}
