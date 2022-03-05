using System.ComponentModel.DataAnnotations;

namespace WebApi.BLL.DTO.User
{
    public class UserChangePasswordDTO
    {
        [Required(ErrorMessage = "OldPassword can't be empty")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "OldPassword of the user must contain 5 symbols at least and be no more than 50 symbols")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$", ErrorMessage = "OldPassword must have at least 1 upercase letter, 1 number and 1 specsymbol '!@#$%_-^&*'")]
        [DataType(DataType.Password)]
        public string? OldPassword { get; set; }
        [Required(ErrorMessage = "NewPassword can't be empty")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "NewPassword of the user must contain 5 symbols at least and be no more than 50 symbols")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$", ErrorMessage = "NewPassword must have at least 1 upercase letter, 1 number and 1 specsymbol '!@#$%_-^&*'")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }
    }
}
