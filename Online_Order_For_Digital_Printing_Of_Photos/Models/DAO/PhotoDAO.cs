using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;
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

        public List<Photos> PhotoList()
        {

            return db.Photos.Where(x => x.status != 0).ToList();
        }
    }
}