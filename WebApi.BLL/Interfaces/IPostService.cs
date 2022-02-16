using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.Post;

namespace WebApi.BLL.Interfaces
{
    public interface IPostService
    {
        public IEnumerable<PostGetVM> GetList();
    }
}
