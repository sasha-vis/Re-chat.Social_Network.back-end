using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Entities;

namespace WebApi.DAL.Interfaces
{
    public interface IMessageRepository<T> where T : class
    {
        Message GetItem(int id);

        void Create(Message message);
    }
}
