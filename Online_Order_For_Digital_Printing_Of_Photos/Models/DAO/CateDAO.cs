using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.DAO
{
    public class CateDAO
    {
        OnlineOrderEntities db = null;
        public CateDAO()
        {
            db = new OnlineOrderEntities();
        }

        public List<CategoriesModel> GetAllCategory()
        {
            var res = db.Categories.Select(x => new CategoriesModel
            {
                cateID = x.cateID,
                cateName = x.cateName
            }).ToList();
            return res;
        }
    }
}