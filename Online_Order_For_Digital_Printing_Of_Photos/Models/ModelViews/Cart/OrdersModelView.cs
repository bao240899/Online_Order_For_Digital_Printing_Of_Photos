using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews.Cart
{
    public class OrdersModelView
    {
        public int orderID { get; set; }
        public Nullable<int> userID { get; set; }
        [Display(Name = "Order Code")]
        public string orderCode { get; set; }
        [Display(Name = "Date")]
        public Nullable<System.DateTime> orderDay { get; set; }
        [Display(Name = "Total Price")]
        public Nullable<decimal> totalPrice { get; set; }
        public Nullable<int> paymentMethod { get; set; }
        [Display(Name = "Delivery Address")]
        public string deliveryAddress { get; set; }
        public Nullable<int> orderStatus { get; set; }

        public OrdersModelView() { }
        public OrdersModelView(int orderID, int? userID, string orderCode, DateTime? orderDay, decimal? totalPrice, int? paymentMethod, string deliveryAddress, int? orderStatus)
        {
            this.orderID = orderID;
            this.userID = userID;
            this.orderCode = orderCode;
            this.orderDay = orderDay;
            this.totalPrice = totalPrice;
            this.paymentMethod = paymentMethod;
            this.deliveryAddress = deliveryAddress;
            this.orderStatus = orderStatus;
        }
    }
}