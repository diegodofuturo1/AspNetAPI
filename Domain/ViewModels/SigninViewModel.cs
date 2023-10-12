using Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class SigninViewModel
    {

        [Required(ErrorMessage = "O login não pode vazio.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha não pode vazio.")]
        public string Password { get; set; }


    public SigninViewModel()
    {

    }
    public SigninViewModel(UserDto domain)
    {
      Login = domain.Email;
      Password = domain.Password;
    }

    public UserDto ToDomain()
    {
      return new UserDto {
        Email= this.Login,
        Password = this.Password };
      }
    }
}
