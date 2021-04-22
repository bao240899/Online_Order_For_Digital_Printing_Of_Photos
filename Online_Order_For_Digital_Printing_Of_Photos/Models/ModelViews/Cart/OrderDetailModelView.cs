using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews.Cart
{
    public class OrderDetailModelView
    {
        public int orderDetailID { get; set; }
        public Nullable<int> orderID { get; set; }
        public Nullable<int> photoID { get; set; }
        public Nullable<int> quantity { get; set; }

        public OrderDetailModelView() { }

        public OrderDetailModelView(int orderDetailID, int? orderID, int? photoID, int? quantity)
        {
            this.orderDetailID = orderDetailID;
            this.orderID = orderID;
            this.photoID = photoID;
            this.quantity = quantity;
        }
    }
}