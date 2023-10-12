using Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class SignupViewModel
    {
        [Required(ErrorMessage = "O nome não pode vazio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O login não pode vazio.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha não pode vazio.")]
        public string Password { get; set; }


    public SignupViewModel()
    {

    }
    public SignupViewModel(UserDto domain)
    {
      Login = domain.Email;
      Password = domain.Password;
      Name= domain.Name;
    }

    public UserDto ToDomain()
    {
      return new UserDto {
        Email= this.Login,
        Name = this.Name,
        Password = this.Password };
      }
    }
}
