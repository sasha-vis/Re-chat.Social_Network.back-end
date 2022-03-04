using Microsoft.EntityFrameworkCore;
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
                .Include(u => u.User)
                .Include(l => l.Messages)
                .Include(u => u.Friend)
                .ToList();
            return friends;
        }


        public List<FriendList> RequareFriendsByUser(string userName)
        {
            var friends = _db.Friends
                .Where(l => l.Friend.Email == userName && l.Status == StatusFriendship.Request)
                .Include(u => u.User)
                .Include(u => u.Friend)
                .ToList();
            return friends;
        }

        public List<FriendList> GetAllFriendsByUser(string userName)
        {
            var friends = _db.Friends
                .Where(l => l.User.Email == userName || l.Friend.Email == userName)
                .Include(u => u.User)
                .Include(u => u.Friend)
                .ToList();

            return friends;
        }


        public void ResponseToRequareFriendsByUser(FriendList friend)
        {
            var friendDB = _db.Friends
                .Where(p => (p.UserId == friend.UserId && p.Status == StatusFriendship.Request))
                .FirstOrDefault();
            if (friendDB != null)
            {
                friendDB.Status = StatusFriendship.Accepted;
                _db.Friends.Update(friendDB);
                _db.SaveChanges();
            }
        }

        public void DeleteFriend(FriendList friend)
        {
            var friendDB = _db.Friends
                .Where(p => (p.UserId == friend.UserId && p.FriendId == friend.FriendId) || (p.FriendId == friend.UserId && p.UserId == friend.FriendId))
                .FirstOrDefault();
            if (friendDB != null)
            {
                _db.Friends.Remove(friendDB);
                _db.SaveChanges();
            }
        }

        public void Create(FriendList friend)
        {
            var friendDB = _db.Friends
                .Where(p => (p.UserId == friend.UserId && p.FriendId == friend.FriendId) || 
                (p.FriendId == friend.UserId && p.UserId == friend.FriendId))
                .FirstOrDefault();
            if (friendDB == null)
            {
                friend.Status = StatusFriendship.Request;
                _db.Add(friend);
                _db.SaveChanges();
            }
        }

        //public async Task Delete(int id)
        //{
        //    var friend = db.Friends.FirstOrDefault(p => p.Id == id);
        //    if (friend != null)
        //    {
        //        db.Friends.Remove(friend);
        //        await db.SaveChangesAsync();
        //    }
        //}

    }
}
