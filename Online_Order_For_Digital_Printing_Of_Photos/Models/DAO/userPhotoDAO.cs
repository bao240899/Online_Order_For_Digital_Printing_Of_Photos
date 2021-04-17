using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.DAO
{
    public class userPhotoDAO
    {
        OnlineOrderEntities db = null;
        public userPhotoDAO()
        {
            db = new OnlineOrderEntities();
        }

        public void Insert(userPhoto userPhoto)
        {
            db.userPhoto.Add(userPhoto);
            db.SaveChanges();
        }
    }
}