namespace WebApi.BLL.ViewModels.User
{
    public class UserGetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string BirthdayDate { get; set; }
        public string RegistrationDate { get; set; }
    }
}
