using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews.Cart
{
    public class CartItemModelView
    {
        
        public PhotoModelView photo { get; set; }
        public int quantity { get; set; }
        public CartItemModelView() { }
        public CartItemModelView( PhotoModelView photo, int quantity)
        {
            this.quantity = quantity;
            this.photo = photo;
        }
    }
}