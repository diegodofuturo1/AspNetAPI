using Newtonsoft.Json;
using Domain.Entities;
using Domain.ViewModels;

namespace Web.Data
{
  public class AuthService
  {
    public async Task<TokenViewModel> Signin(User user)
    {
      var url = "https://localhost:44342/auth/signin";

      var body = new SigninViewModel()
      {
        Login = user.Email,
        Password = user.Password,
      };

      using HttpClient client = new();
      using HttpResponseMessage response = await client.PostAsJsonAsync(url, body);

      if (response.IsSuccessStatusCode)
      {
        string content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ResultViewModel<TokenViewModel>>(content);

        if (result != null)
        {
          return result.Data;
        }
      }

      throw new Exception(response.ReasonPhrase);
    } 
  }
}
