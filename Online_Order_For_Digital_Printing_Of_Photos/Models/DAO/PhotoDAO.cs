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
            var res = db.Photos.Where(x => x.status != 0 || x.status == null).Select(x => new PhotoModel
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

        public PhotoModel GetPhotoByID(string id)
        {
            //List<Photos> photo = db.Photos.ToList();
            var res = db.Photos.GroupBy(c => new { c.ID, c.description, c.photoLink, c.photoName, c.cateID }).Select(x => new PhotoModel
            {
                ID = x.Key.ID,
                photoName = x.Key.photoName,
                description = x.Key.description,
                cateID = x.Key.cateID,
                photoLink = x.Key.photoLink,
            }).SingleOrDefault(x => x.ID == id);
            return res;
        }

        public List<PhotoModel> GetFormatIdByID(string id)
        {
            var res = db.Photos.Where(x => x.ID == id).Select(x => new PhotoModel
            {
                photoID = x.photoID,
                formatID = x.formatID
            }).ToList();
            return res;
        }

        public List<Photos> GetPhoto()
        {
            List<Photos> photo = db.Photos.ToList();

            var res = photo.GroupBy(c => new { c.ID, c.photoName, c.photoLink, c.cateID }).Select(gr => new Photos()
            {
                ID = gr.Key.ID,
                photoName = gr.Key.photoName,
                photoLink = gr.Key.photoLink,
                cateID = gr.Key.cateID
            }).ToList();

            return res;

        }

        public List<ViewUserPhotoModel> GetPhotoByUserid(int userid)
        {
            List<Photos> photo = db.Photos.ToList();
            List<userPhoto> userphoto = db.userPhoto.ToList();

            var photoRecord = (from ps in photo
                               join userps in userphoto on ps.photoID equals userps.photoID
                               select new ViewUserPhotoModel()
                               {
                                   photo = ps,
                                   userphoto = userps
                               }).Where(x => x.userphoto.userID == userid).ToList();
            return photoRecord;
        }

        public void Insert(Photos photo)
        {
            db.Photos.Add(photo);
            db.SaveChanges();
        }
    }
}