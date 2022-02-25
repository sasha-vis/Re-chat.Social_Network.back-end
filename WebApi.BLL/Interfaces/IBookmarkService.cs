using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.Bookmark;
using WebApi.BLL.ViewModels.Like;

namespace WebApi.BLL.Interfaces
{
    public interface IBookmarkService
    {
        public void Create(BookmarkCreateVM model, string userName);
    }
}
