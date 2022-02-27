using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BLL.ViewModels.Post
{
    public class PostCreateVM
    {
        [StringLength(10, MinimumLength = 4,
      ErrorMessage = "Title of post must be at least 4 characters long and no more than 10.")]
        public string Title { get; set; }


        [StringLength(3000, MinimumLength = 4,
          ErrorMessage = "Name must be at least 4 characters long and no more than 3000.")]
        public string Content { get; set; }
    }
}
