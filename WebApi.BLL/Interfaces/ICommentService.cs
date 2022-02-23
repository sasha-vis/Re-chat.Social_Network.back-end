using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.Comment;

namespace WebApi.BLL.Interfaces
{
    public interface ICommentService
    {
        void Create(CommentCreateVM model, string userName);

        void Delete(int id, string userName);
    }
}
