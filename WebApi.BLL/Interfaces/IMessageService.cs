using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.Message;

namespace WebApi.BLL.Interfaces
{
    public interface IMessageService
    {
        void Create(MessageCreateVM model, string userName);
    }
}
