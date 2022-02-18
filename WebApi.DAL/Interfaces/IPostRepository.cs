using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL.Interfaces
{
    public interface IPostRepository<T> where T : class
    {
        public IEnumerable<T> GetList();
        public T GetItem(int id);
        public void Create(T item);
        public void Edit(T item);
        public void Delete(int Id);
    }
}
