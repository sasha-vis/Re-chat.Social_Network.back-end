using System.ComponentModel.DataAnnotations;

namespace WebApi.BLL.DTO.User
{
    public class UserRegisterDTO
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
        [Required(ErrorMessage = "Email can't be empty")]
        [RegularExpression(@"^([a - z0 - 9_ -]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Email is not correct")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password can't be empty")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Password of the user must contain 5 symbols at least and be no more than 50 symbols")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$", ErrorMessage = "Password must have at least 1 upercase letter, 1 number and 1 specsymbol '!@#$%_-^&*'")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again!")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
