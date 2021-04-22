using Online_Order_For_Digital_Printing_Of_Photos.Common;
using Online_Order_For_Digital_Printing_Of_Photos.Models.DAO;
using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Order_For_Digital_Printing_Of_Photos.Controllers
{
    public class HomeController : Controller
    {
        PhotoDAO photoDAO = null;
        public HomeController()
        {
            photoDAO = new PhotoDAO();
        }

        public ActionResult Index()
        {
            var model = photoDAO.GetAllPhotos();
            return View(model);
        }

        public ActionResult Photos()
        {
            var model = new PhotoDAO().GetPhoto();

            return View(model);
        }

        public ActionResult DetailPhoto(string id)
        {
            var model = new PhotoDAO().GetPhotoByID(id);
            return View(model);

        }
    }
}