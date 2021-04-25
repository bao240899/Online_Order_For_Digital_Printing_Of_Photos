using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews
{
    public class SearchModelView
    {
        public OrdersModelView OrderModelView { get; set; }
        public PhotoModelView PhotoModelView { get; set; }
        public UserModelView UserModelView { get; set; }

        public SearchModelView(OrdersModelView orderModelView, PhotoModelView photoModelView, UserModelView userModelView)
        {
            OrderModelView = orderModelView;
            PhotoModelView = photoModelView;
            UserModelView = userModelView;
        }

        public SearchModelView()
        {
        }
    }
}