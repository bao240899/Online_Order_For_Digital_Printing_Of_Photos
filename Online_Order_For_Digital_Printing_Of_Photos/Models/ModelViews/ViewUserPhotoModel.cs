using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews
{
    public partial class ViewUserPhotoModel
    {
        public Photos photo { get; set; }
        public userPhoto userphoto { get; set; }
        public Format format { get; set; }
    }
}