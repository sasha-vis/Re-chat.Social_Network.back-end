using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.User;

namespace WebApi.BLL.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserGetVM> GetList();
    }
}
