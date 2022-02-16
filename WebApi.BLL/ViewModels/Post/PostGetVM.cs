using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BLL.ViewModels.Post
{
    public class PostGetVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
    }
}
