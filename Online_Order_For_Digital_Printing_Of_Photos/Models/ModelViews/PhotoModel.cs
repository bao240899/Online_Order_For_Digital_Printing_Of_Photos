using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews
{
    public class PhotoModel
    {
        public int photoID { get; set; }
        public string photoName { get; set; }
        public string description { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> cateID { get; set; }
        public Nullable<int> userID { get; set; }
        public string photoLink { get; set; }

        public PhotoModel() { }

        public PhotoModel(int photoID, string photoName, string description, int? status, int? cateID, int? userID, string photoLink)
        {
            this.photoID = photoID;
            this.photoName = photoName;
            this.description = description;
            this.status = status;
            this.cateID = cateID;
            this.userID = userID;
            this.photoLink = photoLink;
        }
    }
}