using Online_Order_For_Digital_Printing_Of_Photos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Online_Order_For_Digital_Printing_Of_Photos.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (session == null)
            {
                SetAlert("You need to Login First!!! ", "warning");
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "User", action = "Login" }));
            }
            base.OnActionExecuting(filterContext);
        }

        


        //Alert
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "failse")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-danger";
            }
            //else
            //{
            //    TempData["AlertType"] = "alert-info";
            //}
        }
    }
}