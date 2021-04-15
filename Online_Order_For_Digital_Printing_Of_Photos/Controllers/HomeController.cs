using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Order_For_Digital_Printing_Of_Photos.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }
<<<<<<< HEAD
        public ActionResult Index() {
=======

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(UserModelView model )
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var res = dao.Login(model.userName, model.userPwd);
                if (res == 1)
                {
                    var user = dao.GetUserByUserName(model.userName);
                    //var stt = dao.GetByIdd(user.userID);
                    if (user.role == "user")
                    {
                        var userSession = new UserSession();
                        userSession.userID = user.userID;
                        userSession.userName = user.userName;
                        userSession.userPwd = user.userPwd;
                        userSession.role = user.role;
                        userSession.name = user.name;
                        userSession.status = user.status;
                        Session.Add(CommonConstant.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Home");
                    }
                    else if (user.role == "admin")
                    {
                        var userSession = new UserSession();
                        userSession.userID = user.userID;
                        userSession.userName = user.userName;
                        userSession.userPwd = user.userPwd;
                        userSession.role = user.role;
                        userSession.name = user.name;
                        Session.Add(CommonConstant.USER_SESSION, userSession);
                        return RedirectToAction("", "Admin");
                    }

                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Not Available!");
                }
                else if (res == -1)
                {
                    ModelState.AddModelError("", "You Are blocking!");
                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "passwrod isvalid!");
                }
                else
                {
                    ModelState.AddModelError("", "Login False!");
                }

            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

>>>>>>> Lam
            return View();
        }

        
    }
}