using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL.Interfaces
{
    public interface ILikeRepository<T> where T : class
    {

        public void Create(T item);

    }
}
