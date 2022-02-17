using System.ComponentModel.DataAnnotations;

namespace WebApi.BLL.ViewModels.User
{
    public class UserRegisterVM
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

        public string? BirthdayDate { get; set; }
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        [MinLength(5, ErrorMessage = "Email must contain 5 symbols at least")]
        [MaxLength(50)]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Password can't be empty")]
        //[RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Password must contain only latin letters or numbers")]
        //[MinLength(5, ErrorMessage = "Password must contain 5 symbols at least")]
        //[MaxLength(50)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
