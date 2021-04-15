using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.DAO
{
    public class UserPhotoModel
    {
        public int userPhotoID { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<int> photoID { get; set; }
        public Nullable<System.DateTime> date { get; set; }

        public UserPhotoModel() { }

        public UserPhotoModel(int userPhotoID, int? userID, int? photoID, DateTime? date)
        {
            this.userPhotoID = userPhotoID;
            this.userID = userID;
            this.photoID = photoID;
            this.date = date;
        }
    }
}