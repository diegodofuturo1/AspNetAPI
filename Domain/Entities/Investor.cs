using Domain.Validators;
using System.Collections.Generic;

namespace Domain.Entities
{
  public class Investor : Base
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public Investor()
    {

    }

    public Investor(string name, string email, string password)
    {
      Name = name;
      Email = email;
      Password = password;
      _errors = new List<string>();
      Validate();
    }

    public bool Validate() => Validate(new InvestorValidator(), this);

    public void SetName(string name)
    {
      Name = name;
      Validate();
    }

    public void SetPassword(string password)
    {
      Password = password;
      Validate();
    }

    public void SetEmail(string email)
    {
      Email = email;
      Validate();
    }
  }
}
