using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BLL.ViewModels.User
{
    public class UserLoginVM
    {
        [Required(ErrorMessage = "Email can't be empty")]
        [MinLength(5, ErrorMessage = "Email must contain 5 symbols at least")]
        [MaxLength(50)]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
