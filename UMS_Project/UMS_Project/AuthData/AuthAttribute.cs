using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using UMS_Project.Controllers;
using UMS_Project;

namespace UMS_Project.AuthData
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

                if (filterContext.HttpContext.Session["Role"].ToString() == "0" )
                {
                    var Url = new UrlHelper(filterContext.RequestContext);
                    var url = Url.Action("Login", "Login");
                    filterContext.Result = new RedirectResult(url);
                }
                else if (filterContext.HttpContext.Session["Role"].ToString() != "1")
                {
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "Error"
                    };
                }
            
        }
    }
}