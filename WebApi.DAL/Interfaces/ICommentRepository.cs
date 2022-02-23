using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Entities;

namespace WebApi.DAL.Interfaces
{
    public interface ICommentRepository<T> where T : class
    {
        Comment GetItem(int id);

        void Create(Comment comment);

        void Delete(int id);
    }
}
