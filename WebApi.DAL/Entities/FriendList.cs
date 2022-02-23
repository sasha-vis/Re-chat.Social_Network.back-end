using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL.Entities
{
    public class FriendList
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string FriendId { get; set; }

        public User User { get; set; }
    }
}
