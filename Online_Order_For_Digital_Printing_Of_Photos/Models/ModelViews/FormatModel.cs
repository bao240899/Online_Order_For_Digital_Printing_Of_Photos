using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews
{
    public class FormatModel
    {
        public int formatID { get; set; }
        public string formatName { get; set; }
        public Nullable<int> width { get; set; }
        public Nullable<int> height { get; set; }
    }
}