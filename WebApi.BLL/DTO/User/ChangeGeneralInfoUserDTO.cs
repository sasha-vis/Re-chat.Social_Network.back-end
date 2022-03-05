using System.ComponentModel.DataAnnotations;

namespace WebApi.BLL.DTO.User
{
    public class ChangeGeneralInfoUserDTO
    {
        [Required(ErrorMessage = "Name of the user can't be empty")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name of the user must contain only latin letters")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name of the user must contain 2 letters at least and be no more than 20 letters")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Surname of the user can't be empty")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Surname of the user must contain only latin letters")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname of the user must contain 2 letters at least and be no more than 50 letters")]
        public string? Surname { get; set; }
        public string? BirthdayDate { get; set; }
        public string? Gender { get; set; }
    }
}
