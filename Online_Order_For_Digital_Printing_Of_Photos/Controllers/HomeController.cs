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

        public ActionResult Index(int page = 1, int pageSize = 20)
        {
            var model = photoDAO.GetPhoto(page, pageSize);
            if (model != null)
                return View(model);
            else
                return Redirect("~/Home/NotFound");
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

        //sort a-z
        //public PartialViewResult GetPhotoForPhotosSortA_Z(int? page)
        //{
        //    int pageSize = 24;
        //    int pageNumber = (page ?? 1);
        //    return PartialView("_GetDataPhotoForPhotos", new PhotoDAO().GetPhotoForPhotosSortA_Z().ToPagedList(pageNumber, pageSize));
        //}

        public ActionResult DetailPhoto(string id)
        {
            var model = new PhotoDAO().GetPhotoByID(id);
            if (model == null || id == null)
                return Redirect("~/Home/NotFound");
            else
                return View(model);
        }
        public ActionResult Search()
        {
            //var search = Request.Params["search"];
            //var model = new PhotoDAO().GetDataForSearch(search);
            return View();
        }

        public PartialViewResult GetPhotoForSearch(int? page)
        {
            int pageSize = 24;
            int pageNumber = (page ?? 1);
            var search = Request.Params["search"];
            //var model = new PhotoDAO().GetDataForSearch(search);
            return PartialView("_GetPhotoForSearch", new PhotoDAO().GetDataForSearch(search).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}