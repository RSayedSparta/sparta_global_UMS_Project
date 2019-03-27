using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using UMS_Project.Controllers;

namespace UMS_Project.AuthData
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller  
                return;
            }

            // Check for authorization  
            if (HttpContext.Current.Session["Role"] == null)
            {
                filterContext.Result = new RedirectResult("~/Default");
            }
        }
    }
}