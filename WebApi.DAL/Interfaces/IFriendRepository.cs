using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Entities;

namespace WebApi.DAL.Interfaces
{
    public interface IFriendRepository<T> where T : class
    {
        List<T> FriendsByUser(string userName);

        T GetItem(string userName, string id2);

        List<T> RequareFriendsByUser(string userName);

        void ResponseToRequareFriendsByUser(T friend);

        public void Create(T friend);


    }
}
