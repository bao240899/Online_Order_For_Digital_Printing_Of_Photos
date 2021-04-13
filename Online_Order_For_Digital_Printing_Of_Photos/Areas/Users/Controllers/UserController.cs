using Online_Order_For_Digital_Printing_Of_Photos.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Order_For_Digital_Printing_Of_Photos.Areas.Users.Controllers
{
    public class UserController : Controller
    {
        //declare dao
        public UserDAO UserDAO = null;
        // Call Model in Dao
        public UserController() {
            // new DAO
            UserDAO = new UserDAO();
        }
        public ActionResult Index()
        {
            // user Model
            var rs = UserDAO.ShowAllUser();
            // use Viewbag, viewdata, viewResult to give data to view
            // viewbag chi co quen tuy cap trong 1 controller
            // check session, ModelView, ...
            ViewBag.abc = "bao dep trai";
            return View(rs);
        }
    }
}