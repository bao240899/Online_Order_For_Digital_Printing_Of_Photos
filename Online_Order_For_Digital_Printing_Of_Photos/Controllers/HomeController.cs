using Online_Order_For_Digital_Printing_Of_Photos.Common;
using Online_Order_For_Digital_Printing_Of_Photos.Models.DAO;
using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
using PagedList;
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

        public ActionResult Index(int page = 1, int pageSize = 28)
        {
            var model = photoDAO.GetPhoto(page, pageSize);
            return View(model);
        }

        public ActionResult Photos()
        {
            return View();
        }

        public PartialViewResult GetPhotoForPhotos(int? page)
        {
            int pageSize = 24;
            int pageNumber = (page ?? 1);
            return PartialView("_GetDataPhotoForPhotos", new PhotoDAO().GetPhotoForPhotos().ToPagedList(pageNumber, pageSize));
        }
        
        public PartialViewResult GetPhotoByCateIdForPhotos(int? page, int catid)
        {
            int pageSize = 24;
            int pageNumber = (page ?? 1);
            return PartialView("_GetPhotoByCateIdForPhotos", new PhotoDAO().GetPhotoByCateIdForPhotos(catid).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DetailPhoto(string id)
        {
            var model = new PhotoDAO().GetPhotoByID(id);
            return View(model);

        }
    }
}