using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Security.Claims;

namespace Application.Attributes
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
  public class CurrentUserIdAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      var user = context.HttpContext.User;

      if (user.Identity.IsAuthenticated)
      {
        string value = user.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;

        if (long.TryParse(value, out long userId))        
          context.ActionArguments["userId"] = userId;
      }

      base.OnActionExecuting(context);
    }
  }
}

