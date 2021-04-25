using Online_Order_For_Digital_Printing_Of_Photos.Models.DAO;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
using PagedList;
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
        public OrderDao orderDao = null;
        public PhotoDAO PhotoDAO = null;
        // Call Model in Dao
        public AdminController()
        {
            // new DAO
            userDao = new UserDAO();
            orderDao = new OrderDao();
            PhotoDAO = new PhotoDAO();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManagerUser()
        {
            //var rs = userDao.ListUserToManager();
            return View();
        }

        public PartialViewResult GetUserForManageUser(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return PartialView("_GetUserForManageUser", userDao.ListUserToManager().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ManagerOrder()
        {
            //var rs = orderDao.ListOrderToManager();
            return View();
        }

        public PartialViewResult GetOrderForManageOrder(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return PartialView("_GetOrderForManageOrder", orderDao.ListOrderToManager().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ManagerPhoto()
        {
            //var rs = PhotoDAO.GetPhotoToManager();
            return View();
        }

        public PartialViewResult GetDataForManagephoto(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return PartialView("_GetDataForManagephoto", PhotoDAO.GetPhotoToManager().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DetailOrder(int ID)
        {
            var rs = orderDao.GetOrderDetailByOrderID(ID);
            return View(rs);
        }
        public ActionResult CancelOrder(string ID)
        {
            var rs = orderDao.OrderFail(ID);
            return RedirectToAction("ManagerOrder", "Admin");
        }
        public ActionResult ChangeStatus(int id)
        {
            var rs = userDao.ChangeStatusByID(id);
            if (rs == 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("ManagerUser", "Admin");
        }
        public ActionResult ChangeStatusPhoto(int id)
        {
            var rs = PhotoDAO.changeStasus(id);
            if (rs == 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("ManagerPhoto", "Admin");
        }

    }
}