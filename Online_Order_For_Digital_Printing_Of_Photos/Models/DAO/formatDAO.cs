﻿using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.DAO
{
    public class formatDAO
    {
        OnlineOrderEntities db = null;
        public formatDAO()
        {
            db = new OnlineOrderEntities();
        }

        public List<FormatModel> GetAllFormat()
        {
            var res = db.Format.Select(x => new FormatModel
            {
                formatID = x.formatID,
                formatName = x.formatName,
                width = x.width,
                height = x.height
            }).ToList();
            return res;
        }
    }
}