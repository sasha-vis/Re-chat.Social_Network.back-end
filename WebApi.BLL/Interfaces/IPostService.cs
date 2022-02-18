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
        public PostGetVM GetItem(int id);
        public void Create(PostCreateVM model);
        public void Edit(PostEditVM model);
        public void Delete(int id);
    }
}
