using Online_Order_For_Digital_Printing_Of_Photos.Common;
using Online_Order_For_Digital_Printing_Of_Photos.Models.DAO;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Order_For_Digital_Printing_Of_Photos.Controllers
{
    public class UserController : Controller
    {
        UserDAO userDao = null;

        public UserController()
        {

            userDao = new UserDAO();
        }
        public ActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModelView _user)
        {
            if (ModelState.IsValid)
            {

                var res = userDao.Login(_user);
                if (res == 1)
                {
                    var user = userDao.GetUserByName(_user.userName);
                    if (user.role == "user")
                    {
                        var userSession = new UserSession();
                        userSession.userID = user.userID;
                        userSession.userName = user.userName;
                        userSession.userPwd = user.userPwd;
                        userSession.role = user.role;
                        userSession.name = user.name;

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
                        TempData["notice"] = "Successfully registered";
                        return RedirectToAction("Index", "Admin", new { Area = "Admin"});
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
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserModelView _user)
        {
            if (ModelState.IsValid)
            {
                var stt = 1;
                var role = "user";
                _user.status = stt;
                _user.role = role;
                var rs = userDao.Register(_user);
                if (rs == 1)
                {
                    return RedirectToAction("Login", "User");
                }
                else if (rs == 0)
                {
                    ModelState.AddModelError("", "Register False!!");
                }
                else if (rs == -1)
                {
                    ModelState.AddModelError("", "userName is exist !");
                }
                else if (rs == -2)
                {
                    ModelState.AddModelError("", "email is exist!");
                }
                else
                {
                    ModelState.AddModelError("", "Register False!");
                }
            }
            //má chỗ này quên mất là k được redirect vì redirect xong là mất erros
            return View("SignUp");
        }
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }
        public ActionResult AccountDetail()
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            var rs = userDao.GetUserById(session.userID);
            return View(rs);
        }
        [HttpPost]
        public ActionResult ChangePwd(UserModelView _user)
        {
            var rs = userDao.ChangePwd(_user);
            if (rs == 0)
            {
                return RedirectToAction("Login", "User");
            }
            return RedirectToAction("AccountDetail", "User");
        }
        [HttpPost]
        public ActionResult ChangeEmail(UserModelView _user)
        {
            var rs = userDao.ChangeEmail(_user);
            if (rs == 0)
            {
                return RedirectToAction("Login", "User");
            }
            return RedirectToAction("AccountDetail", "User");
        }
        [HttpPost]
        public ActionResult ChangeAddress(UserModelView _user)
        {
            var rs = userDao.ChangeAddress(_user);
            if (rs == 0)
            {
                return RedirectToAction("Login", "User");
            }
            return RedirectToAction("AccountDetail", "User");
        }
    }
}