using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.DAO
{
    public class PhotoDAO
    {
        OnlineOrderEntities db = null;
        public PhotoDAO()
        {
            db = new OnlineOrderEntities();
        }

        public List<PhotoModel> GetAllPhotos()
        {
            var res = db.Photos.Where(x => x.status != 0).Select(x => new PhotoModel
            {
                photoID = x.photoID,
                photoName = x.photoName,
                description = x.description,
                status = x.status,
                cateID = x.cateID,
                photoLink = x.photoLink,
                formatID = x.formatID,
                ID = x.ID
            }).ToList();
            return res;
        }

        public List<ViewUserPhotoModel> GetPhotoByUserid(int userid)
        {
            List<Photos> photo = db.Photos.ToList();
            List<userPhoto> userphoto = db.userPhoto.ToList();
            List<Format> format = db.Format.ToList();

            var photoRecord = (from ps in photo
                               join userps in userphoto on ps.photoID equals userps.photoID
                               join fm in format on ps.formatID equals fm.formatID
                               select new ViewUserPhotoModel()
                               {
                                   photo = ps,
                                   userphoto = userps,
                                   format = fm
                               }).Where(x => x.userphoto.userID == userid).ToList();
            return photoRecord;
        }

        public void Insert(PhotoModel entity)
        {
            //var res = db.Photos.Where(x => new PhotoModel
            //{
            //    photoID = x.photoID
            //});


            db.SaveChanges();
        }
    }
}