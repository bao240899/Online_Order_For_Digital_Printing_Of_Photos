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
    public class PhotoController : BaseController
    {
        [HttpGet]
        public ActionResult CreatePhoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePhoto(Photos photo)
        {
            if (ModelState.IsValid)
            {
                var pt = new PhotoDAO();
                var ID = Guid.NewGuid().ToString();
                int status = 1;
                int cateid = Convert.ToInt32(Request.Form["categories"]);
                photo.ID = ID;
                photo.status = status;
                photo.cateID = cateid;
                //pt.Insert(photo);

                var formatID = Request.Params["formatID"];
                var pr = Request.Params["price"];
                var checkNull = pr.Replace(",", "").Length;
                //table Photos
                var userPhotoDAO = new userPhotoDAO();
                var userPhoto = new userPhoto();

                string[] userphoto = formatID.Split(',');
                string[] pri = pr.Split(',');
                if (checkNull == 0)
                {
                    ModelState.AddModelError("", "You need to price at least 1 size!!!");
                }
                else
                {
                    for (int i = 0; i < userphoto.Length; i++)
                    {
                        if (pri[i] == "" || pri[i] == null)
                        {
                            continue;
                        }
                        else
                        {
                            var price = Convert.ToInt32(pri[i]);
                            var formatid = Convert.ToInt32(userphoto[i]);
                            photo.formatID = formatid;
                            photo.Price = price;
                            pt.Insert(photo);

                            var session = (UserSession)Session[CommonConstant.USER_SESSION];
                            var userid = session.userID;
                            var latestPhotoID = photo.photoID;
                            var datetime = DateTime.Now;
                            userPhoto.photoID = latestPhotoID;
                            userPhoto.userID = userid;
                            userPhoto.date = datetime;
                            userPhotoDAO.Insert(userPhoto);
                        }
                    }
                }
                SetAlert("Add New Photo Success", "success");
                return Redirect("~/Home/Photos");
            }
            return View("CreatePhoto");
        }

        public ActionResult Download()
        {
            
            return View();
        }
    }
}