using Online_Order_For_Digital_Printing_Of_Photos.Models.DAO;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Order_For_Digital_Printing_Of_Photos.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        //declare dao
        public UserDAO userDao = null;
        // Call Model in Dao
        public AdminController() {
            // new DAO
            userDao = new UserDAO();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManagerUser()
        {
            var rs = userDao.ListUserToManager();
            return View(rs);
        }
       
        public ActionResult ChangeStatus(int id) {
            var rs = userDao.ChangeStatusByID(id);
            if (rs == 0) {
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("ManagerUser","Admin");
        }
    }
}