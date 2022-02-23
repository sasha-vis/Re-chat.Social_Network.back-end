using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BLL.ViewModels.Like
{
    public class LikeForPostVM
    {
        public int PostId { get; set; }

        public string? UserId { get; set; }

        public string UserName { get; set; }
        public string UserSurname { get; set; }
    }
}
