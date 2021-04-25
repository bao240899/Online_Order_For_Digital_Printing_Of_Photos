using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews
{
    public class PhotoModel
    {
        public int photoID { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name of Photo")]
        [Display(Name = "Photo Name")]
        public string photoName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Description of Photo")]
        [Display(Name = "Description")]
        public string description { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> cateID { get; set; }
        public string photoLink { get; set; }
        public Nullable<int> formatID { get; set; }
        public Nullable<int> Price { get; set; }
        public string ID { get; set; }

        public PhotoModel() { }

        public PhotoModel(int photoID, string photoName, string description, int? status, int? cateID, string photoLink, int? formatID, int? price, string iD)
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