using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.DAO
{
    public class OrderDao
    {
        OnlineOrderEntities entities = null;
        public OrderDao() {
            entities = new OnlineOrderEntities();
        }
        public int AddOrder(OrdersModelView _order)
        {
            Orders order = new Orders();
            order.orderID = _order.orderID;
            order.userID = _order.userID;
            order.orderCode = _order.orderCode;
            order.orderDay = _order.orderDay;
            order.totalPrice = _order.totalPrice;
            order.paymentMethod = _order.paymentMethod;
            order.deliveryAddress = _order.deliveryAddress;
            order.orderStatus = _order.orderStatus;
            var rs=entities.Orders.Add(order);
            entities.SaveChanges();
            if (rs== null) {
                return 0;
            }
            return 1;
        }
        public OrdersModelView GetOrderByOrderCode(string orderCode) {
            var rs= entities.Orders.Where(d => d.orderCode == orderCode).Select(d=> new OrdersModelView {orderID= d.orderID, userID=d.userID, orderCode=d.orderCode, orderDay=d.orderDay, orderStatus=d.orderStatus, deliveryAddress=d.deliveryAddress,paymentMethod=d.paymentMethod, totalPrice=d.totalPrice }).FirstOrDefault();
            return rs;
        }
        public int AddOrderDetail(OrderDetailModelView _orderDetail)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.orderID = _orderDetail.orderID;
            orderDetail.photoID = _orderDetail.photoID;
            orderDetail.quantity = _orderDetail.quantity;
            var rs =entities.OrderDetail.Add(orderDetail);
            entities.SaveChanges();
            if (rs == null) {
                return 0;
            }
            return 1;
        }
        public List<OrdersModelView> GetOrderByUserID(int userID) {
            var rs = entities.Orders.Where(d => d.userID == userID).Select(d => new OrdersModelView { orderID = d.orderID, userID = d.userID, orderCode = d.orderCode, orderDay = d.orderDay, orderStatus = d.orderStatus, deliveryAddress = d.deliveryAddress, paymentMethod = d.paymentMethod, totalPrice = d.totalPrice }).ToList();
            return rs;
        }
    }
   
}