using Online_Order_For_Digital_Printing_Of_Photos.Common;
using Online_Order_For_Digital_Printing_Of_Photos.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Order_For_Digital_Printing_Of_Photos.Controllers
{
    public class UserController : BaseController
    {
        public new ActionResult Profile(int id)
        {
            var model = new UserDAO().GetUserByUserid(id);
            return View(model);
        }

        public ActionResult MyPhoto()
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            var userID = session.userID;
            var model = new PhotoDAO().GetPhotoByUserid(userID);
            return View(model);
        }
    }
}