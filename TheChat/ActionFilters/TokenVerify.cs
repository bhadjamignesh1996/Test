using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TheChat.BalLayer.AuthToken;

namespace TheChat.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class TokenVerify : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var vHeaders = filterContext.HttpContext.Request.Headers;

            if (!String.IsNullOrEmpty(Convert.ToString(vHeaders["TOKEN_NO"])))
            {
                if (AuthToken.ValidateToken(Convert.ToString(vHeaders["TOKEN_NO"])) == null)
                { filterContext.Result = new UnauthorizedResult(); return; }
            }
            else
            {
                filterContext.Result = new UnauthorizedResult(); return;
            }
        }
    }
}
