using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  static public class BaseExtension
  {
    static public T SetId<T>(this T obj, long id) where T : Base
    {
      obj.Id = id;
      return obj;
    }

  }
}
