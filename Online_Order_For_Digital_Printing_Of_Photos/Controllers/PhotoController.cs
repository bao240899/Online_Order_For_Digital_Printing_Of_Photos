using Online_Order_For_Digital_Printing_Of_Photos.Common;
using Online_Order_For_Digital_Printing_Of_Photos.Models.DAO;
using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Order_For_Digital_Printing_Of_Photos.Controllers
{
    public class PhotoController : BaseController
    {
        private string GetNewPathForDupes(string path, ref string fn)
        {
            string directory = Path.GetDirectoryName(path);
            string filename = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);
            int counter = 1;
            string newFullPath = path;
            string new_file_name = filename + extension;
            while (System.IO.File.Exists(newFullPath))
            {
                string newFilename = string.Format("{0}({1}){2}", filename, counter, extension);
                new_file_name = newFilename;
                newFullPath = Path.Combine(directory, newFilename);
                counter++;
            };
            fn = new_file_name;
            return newFullPath;
        }

        [HttpGet]
        public ActionResult CreatePhoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePhoto(Photos photo, FormCollection fc)
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
                    ModelState.AddModelError("", "You need to add at least 1 format!!!");
                    return View("CreatePhoto");
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
                            var format = new formatDAO().GetFormatById(formatid);
                            foreach (var item in format)
                            {
                                string width = Convert.ToString(item.width);
                                string height = Convert.ToString(item.height);
                                int widthResize = 200;
                                int heightResize = 200;
                                if (!string.IsNullOrEmpty(width))
                                {
                                    int.TryParse(width, out widthResize);
                                }
                                if (!string.IsNullOrEmpty(height))
                                {
                                    int.TryParse(height, out heightResize);
                                }
                                List<string> fileNames = new List<string>();
                                // Duyệt file
                                foreach (string fileName in Request.Files)
                                {
                                    //Lấy ra file gởi lên
                                    HttpPostedFileBase file = Request.Files[fileName];
                                    if (file != null && file.ContentLength > 0)
                                    {
                                        //Lưu và /Photos
                                        var originalDirectory = new DirectoryInfo(string.Format("{0}Photos\\", Server.MapPath(@"\")));
                                        //Lưu hình ảnh vào folder /images
                                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "images");
                                        bool isExists = System.IO.Directory.Exists(pathString);
                                        if (!isExists) System.IO.Directory.CreateDirectory(pathString);
                                        var originalPath = string.Format("{0}\\{1}", pathString, file.FileName);
                                        var path = string.Format("{0}\\{1}", pathString, String.Concat("(" + item.width + "x" + item.height + ")", file.FileName));
                                        string newFileName = file.FileName;
                                        //lấy đường dẫn lưu file sau khi kiểm tra tên file trên server có tồn tại hay không
                                        //var newPath = GetNewPathForDupes(path, ref newFileName);
                                        string serverPath = string.Format("/{0}/{1}/{2}", "Photos", "images", newFileName);
                                        //Lưu hình ảnh đã Resize
                                        SaveResizeImage(Image.FromStream(file.InputStream), widthResize, heightResize, path);
                                        SaveResizeImage(Image.FromStream(file.InputStream), widthResize, heightResize, originalPath);
                                        fileNames.Add("LocalPath: " + path + "<br/>ServerPath: " + serverPath);

                                        photo.formatID = formatid;
                                        photo.Price = price;
                                        photo.photoLink = serverPath;
                                        //save into Photo
                                        pt.Insert(photo);

                                        var session = (UserSession)Session[CommonConstant.USER_SESSION];
                                        var userid = session.userID;
                                        var latestPhotoID = photo.photoID;
                                        var datetime = DateTime.Now;
                                        userPhoto.photoID = latestPhotoID;
                                        userPhoto.userID = userid;
                                        userPhoto.date = datetime;
                                        //save into userPhto
                                        userPhotoDAO.Insert(userPhoto);
                                    }
                                }
                            }
                        }
                    }
                }
                SetAlert("Add New Photo Success", "success");
                return Redirect("~/User/MyPhoto");
            }
            return View("CreatePhoto");
        }

        //Hàm resize hình ảnh
        public bool SaveResizeImage(Image img, int width, int height, string path)
        {
            try
            {
                // lấy chiều kích thước ban đầu
                int originalW = img.Width;
                int originalH = img.Height;
                // lấy chiều rộng và chiều cao mới 
                int resizedW = width;
                int resizedH = height;
                Bitmap b = new Bitmap(resizedW, resizedH);
                Graphics g = Graphics.FromImage((Image)b);
                g.InterpolationMode = InterpolationMode.Bicubic;
                g.DrawImage(img, 0, 0, resizedW, resizedH);
                g.Dispose();
                b.Save(path);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public ActionResult Download(int id)
        {
            var image = new PhotoDAO().getphotofordownload(id);
            var imgPath = Server.MapPath(image.photoLink);
            string FileName = Path.GetFileName(imgPath);
            var format = new formatDAO().GetFormatById((int)image.formatID);
            foreach (var item in format)
            {
                string serverPath = string.Format("/{0}/{1}/{2}", "Photos", "images", String.Concat("(" + item.width + "x" + item.height + ")", FileName));
                return File(serverPath, "image/jpg", String.Concat("(" + item.width + "x" + item.height + ")", image.photoName) + ".jpg");
            }
            SetAlert("Download Photo Success.", "success");
            return Redirect("~/User/DownLoadedPhoto");

        }
    }
}