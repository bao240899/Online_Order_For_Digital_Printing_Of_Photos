using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews.Cart
{
    public class PhotoModelView
    {
        public int photoID { get; set; }
        public string photoName { get; set; }
        public string description { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> cateID { get; set; }
        public string photoLink { get; set; }
        public Nullable<int> formatID { get; set; }
        public Nullable<int> Price { get; set; }
        public string ID { get; set; }
        public PhotoModelView() { }

        public PhotoModelView(int photoID, string photoName, string description, int? status, int? cateID, string photoLink, int? formatID, int? price, string iD)
        {
            this.photoID = photoID;
            this.photoName = photoName;
            this.description = description;
            this.status = status;
            this.cateID = cateID;
            this.photoLink = photoLink;
            this.formatID = formatID;
            Price = price;
            ID = iD;
        }
    }
}