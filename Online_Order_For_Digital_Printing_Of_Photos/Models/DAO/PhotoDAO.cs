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
                description = x.description,
                cateID = x.cateID,
                photoLink = x.photoLink,
                photoName = x.photoName,
                status = x.status
            }).ToList();
            return res;
        }
    }
}