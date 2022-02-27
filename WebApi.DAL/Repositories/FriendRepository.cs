using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Entities;
using WebApi.DAL.Entities.Enums;
using WebApi.DAL.Interfaces;

namespace WebApi.DAL.Repositories
{
    public class FriendRepository : IFriendRepository<FriendList>
    {
        private readonly ApplicationContext _db;

        public FriendRepository(ApplicationContext context)
        {
            _db = context;
        }


        public FriendList GetItem(string userName, string id2)
        {
            var friend = _db.Friends
                .Where(l => (l.User.Id == id2 && l.Friend.Email == userName) && l.Status == StatusFriendship.Request)
                .FirstOrDefault();
            return friend;
        }

        public List<FriendList> FriendsByUser(string userName)
        {
            var friends = _db.Friends
                .Where(l => (l.User.Email == userName || l.Friend.Email == userName) && l.Status == StatusFriendship.Accepted)
                .ToList();
            return friends;
        }


        public List<FriendList> RequareFriendsByUser(string userName)
        {
            var friends = _db.Friends
                .Where(l => l.Friend.Email == userName && l.Status == StatusFriendship.Request)
                .ToList();
            return friends;
        }


        public void ResponseToRequareFriendsByUser(FriendList friend)
        {
            _db.Update(friend);
            _db.SaveChanges();
        }

        public void Create(FriendList friend)
        {
            friend.Status = StatusFriendship.Request;
            _db.Add(friend);
            _db.SaveChanges();
        }

    }
}
