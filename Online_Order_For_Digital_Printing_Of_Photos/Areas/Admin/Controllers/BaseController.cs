using Online_Order_For_Digital_Printing_Of_Photos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Online_Order_For_Digital_Printing_Of_Photos.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "User", action = "Login", Area = "" }));
            }
            else if (session.role != "admin")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", Area = "" }));

            }
            base.OnActionExecuting(filterContext);
        }
    }
}