using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BLL.ViewModels.Comment
{
    public class CommentCreateVM
    {
        public string CommentText { get; set; }

        public int PostId { get; set; }
    }
}
