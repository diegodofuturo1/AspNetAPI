using Domain.Validators;
using System.Collections.Generic;

namespace Domain.Entities
{
  public class Investor : Base
  {
    public long IdUser { get; set; }
    public string Cpf { get; set; }

    public Investor()
    {

    }

    public Investor(long idUser, string cpf)
    {
      IdUser = idUser;
      Cpf = cpf;
      _errors = new List<string>();
      Validate();
    }

    public bool Validate() => Validate(new InvestorValidator(), this);
  }
}
