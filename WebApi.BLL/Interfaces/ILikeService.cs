using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.Like;

namespace WebApi.BLL.Interfaces
{
    public interface ILikeService
    {
        public void Create(LikeCreateVM model, string userName);
    }
}
