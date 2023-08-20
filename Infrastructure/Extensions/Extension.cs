using System;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Extensions
{
  static public class Extension
  {
    static public string ToWhereParameters(this object _object)
    {
      var properties = _object
        .GetType()
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Select(p => $"{p.Name} = @{p.Name}")
        ;

      return String.Join( ", ", properties);
    }
  }
}
