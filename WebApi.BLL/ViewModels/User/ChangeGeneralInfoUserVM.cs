using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BLL.ViewModels.User
{
    public class ChangeGeneralInfoUserVM
    {
        [Required(ErrorMessage = "Name of the user can't be empty")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name of the user must contain only latin letters")]
        [MinLength(3, ErrorMessage = "Name of the user must contain 3 letters at least")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname of the user can't be empty")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Surname of the user must contain only latin letters")]
        [MinLength(3, ErrorMessage = "Surname of the user must contain 3 letters at least")]
        [MaxLength(50)]
        public string Surname { get; set; }

        public string BirthdayDate { get; set; }
        public string Gender { get; set; }
    }
}
