using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews.Cart;
using PagedList;
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
        public IEnumerable<PhotoModel> GetPhotoToManager()
        {
            var res = db.Photos.Select(x => new PhotoModel
            {
                photoID = x.photoID,
                photoName = x.photoName,
                description = x.description,
                status = x.status,
                cateID = x.cateID,
                photoLink = x.photoLink,
                formatID = x.formatID,
                Price = x.Price,
                ID = x.ID
            }).ToList();
            return res;
        }
        public PhotoModel GetPhotoByID(string id)
        {
            //List<Photos> photo = db.Photos.ToList();.Where(c=>c.Key.ID == id) 
            var res = db.Photos.GroupBy(c => new { c.ID, c.description, c.photoLink, c.photoName, c.cateID }).Select(x => new PhotoModel
            {
                ID = x.Key.ID,
                photoName = x.Key.photoName,
                description = x.Key.description,
                cateID = x.Key.cateID,
                photoLink = x.Key.photoLink,
            }).FirstOrDefault(x => x.ID == id);
            return res;
        }

        public PhotoModel EditPhotoByPhotoId(int photoid)
        {
            //List<Photos> photo = db.Photos.ToList();.Where(c=>c.Key.ID == id) ||GroupBy(c => new { c.ID, c.description, c.photoLink, c.photoName, c.cateID })
            var res = db.Photos.Select(x => new PhotoModel
            {
                photoID = x.photoID,
                photoName = x.photoName,
                description = x.description,
                status = x.status,
                cateID = x.cateID,
                photoLink = x.photoLink,
                formatID = x.formatID,
                Price = x.Price,
                ID = x.ID
            }).FirstOrDefault(x => x.photoID == photoid);
            return res;
        }

        public void EditPhoto(Photos photo)
        {
            var listPhotoByID = db.Photos.Where(x => x.ID == photo.ID).ToList();
            var listPhotoByphotoId = db.Photos.FirstOrDefault(x => x.photoID == photo.photoID);
            listPhotoByphotoId.Price = photo.Price;

            foreach (var item in listPhotoByID)
            {
                item.photoName = photo.photoName;
                item.description = photo.description;
                item.cateID = photo.cateID;
                db.SaveChanges();
            }
        }


        public List<PhotoModel> GetFormatIdByID(string id)
        {
            var res = db.Photos.Where(x => x.ID == id).Select(x => new PhotoModel
            {
                status = x.status,
                Price = x.Price,
                photoID = x.photoID,
                formatID = x.formatID
            }).ToList();
            return res;
        }

        public IEnumerable<Photos> GetPhoto(int page, int pageSize)
        {
            List<Photos> photo = db.Photos.ToList();

            var res = photo.OrderBy(x => x.ID).GroupBy(c => new { c.ID, c.photoName, c.photoLink, c.cateID }).Select(gr => new Photos()
            {
                ID = gr.Key.ID,
                photoName = gr.Key.photoName,
                photoLink = gr.Key.photoLink,
                cateID = gr.Key.cateID
            }).ToPagedList(page, pageSize);

            return res;

        }

        public IEnumerable<Photos> GetPhotoForPhotos()
        {
            List<Photos> photo = db.Photos.ToList();

            var res = photo.OrderBy(x => x.ID).GroupBy(c => new { c.ID, c.photoName, c.photoLink, c.cateID }).Select(gr => new Photos()
            {
                photoLink = gr.Key.photoLink,
                ID = gr.Key.ID,
                photoName = gr.Key.photoName
            }).ToList();
            return res;
        }

        public List<ViewUserPhotoModel> GetPhotoByUserid(int userid)
        {
            List<Photos> photo = db.Photos.ToList();
            List<userPhoto> userphoto = db.userPhoto.ToList();
            List<Format> fm = db.Format.ToList();

            var photoRecord = (from ps in photo
                               join userps in userphoto on ps.photoID equals userps.photoID
                               join FM in fm on ps.formatID equals FM.formatID
                               select new ViewUserPhotoModel()
                               {
                                   photo = ps,
                                   userphoto = userps,
                                   format = FM
                               }).Where(x => x.userphoto.userID == userid).OrderBy(x => x.photo.photoName).ToList();
            return photoRecord;
        }

        public Photos getphotofordownload(int id)
        {
            return db.Photos.Find(id);
        }

        public void Insert(Photos photo)
        {
            db.Photos.Add(photo);
            db.SaveChanges();
        }

        public PhotoModelView GetPhotoByPhotoID(int photoID)
        {
            var rs = db.Photos.Where(d => d.photoID == photoID).Select(d => new PhotoModelView
            {
                photoID = d.photoID,
                photoName = d.photoName,
                description = d.description,
                status = d.status,
                cateID = d.cateID,
                photoLink = d.photoLink,
                formatID = d.formatID,
                Price = d.Price,
                ID = d.ID
            }).FirstOrDefault();
            return rs;
        }
        public int changeStasus(int photoID)
        {
            Photos photo = db.Photos.Where(d => d.photoID == photoID).FirstOrDefault();
            if (photo.status == 0)
            {
                photo.status = 1; //enable;
            }
            else
            {
                photo.status = 0; // disable
            }
            int resultAction = db.SaveChanges();
            if (resultAction > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}