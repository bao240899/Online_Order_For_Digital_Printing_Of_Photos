using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews
{
    public class CategoriesModel
    {
        public int cateID { get; set; }
        public string cateName { get; set; }
        public string cateDesc { get; set; }

        public CategoriesModel() { }

        public CategoriesModel(int cateID, string cateName, string cateDesc)
        {
            this.cateID = cateID;
            this.cateName = cateName;
            this.cateDesc = cateDesc;
        }
    }
}