using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using service.Models;


namespace service.Security
{
    public class CustomAuthorizeAttribut : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Username))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "LogIn", action = "viewLogIn" }));
            }else
            {
                Account am = new Account();
                CustomPrincipal mp = new CustomPrincipal(Account.getAccount(SessionPersister.Username));
                if (!mp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AccessDenied", action = "Index" }));
                }

            }
        }



    }
}
