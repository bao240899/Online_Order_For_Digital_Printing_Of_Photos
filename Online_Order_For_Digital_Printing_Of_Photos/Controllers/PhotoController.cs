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
    public class PhotoController : BaseController
    {
        // GET: Photo
        public ActionResult Show()
        {
            var model = new PhotoDAO().GetAllPhotos();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreatePhoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePhoto(PhotoModel photo)
        {
            if (ModelState.IsValid)
            {
                //var session = (UserSession)Session[CommonConstant.USER_SESSION];
                //var pt = new PhotoDAO();
                //int status = 1;
                //int userID = session.userID;
                //int cate = Convert.ToInt32(Request.Form["categories"]);
                //photo.userID = userID;
                //photo.status = status;
                //photo.cateID = cate;
                ////save
                //pt.Insert(photo);
            }
            return View("Show");
        }
    }
}