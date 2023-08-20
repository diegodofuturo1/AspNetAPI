using System;
using System.Collections.Generic;

namespace Domain.Exceptions
{
  public class DomainException: Exception
  {
    public DomainException(string message): base(message)
    {

    }
    
    public DomainException(IReadOnlyCollection<string> messages): base(String.Join("\n", messages))
    {

    }
  }
}
