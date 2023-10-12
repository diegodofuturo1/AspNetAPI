using System;

namespace Domain.ViewModels
{
  public class TokenViewModel
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string  Token { get; set; }
    public DateTime TokenExpires { get; set; }
  }
}
