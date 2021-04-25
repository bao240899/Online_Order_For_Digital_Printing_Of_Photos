using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
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
        public OrderDao()
        {
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
            var rs = entities.Orders.Add(order);
            entities.SaveChanges();
            if (rs == null)
            {
                return 0;
            }
            return 1;
        }

        public int SetPayPalIDInOrder(string _orderCode, string PayPalID)
        {
            Orders rs = entities.Orders.Where(d => d.orderCode == _orderCode).FirstOrDefault();
            rs.PayPalInvoiceID = PayPalID;
            entities.SaveChanges();
            if (rs == null)
            {
                return 0;
            }
            return 1;
        }

        public OrdersModelView GetOrderByOrderCode(string orderCode)
        {
            var rs = entities.Orders.Where(d => d.orderCode == orderCode).Select(d => new OrdersModelView { orderID = d.orderID, userID = d.userID, orderCode = d.orderCode, orderDay = d.orderDay, orderStatus = d.orderStatus, deliveryAddress = d.deliveryAddress, paymentMethod = d.paymentMethod, totalPrice = d.totalPrice }).FirstOrDefault();
            return rs;
        }
        public List<OrderDetailModelView> GetOrderDetailByOrderID(int orderID)
        {
            var rs = entities.OrderDetail.Where(d => d.orderID == orderID).Select(d => new OrderDetailModelView { orderID = d.orderID, orderDetailID = d.orderDetailID, photoID = d.photoID, quantity = d.quantity }).ToList();
            return rs;
        }
        public IEnumerable<OrdersModelView> ListOrderToManager()
        {
            var rs = entities.Orders.Select(d => new OrdersModelView
            {
                orderID = d.orderID,
                userID = d.userID,
                orderCode = d.orderCode,
                orderDay = d.orderDay,
                orderStatus = d.orderStatus,
                deliveryAddress = d.deliveryAddress,
                paymentMethod = d.paymentMethod,
                totalPrice = d.totalPrice
            }).ToList();
            return rs;
        }
        public int OrderFail(string _orderCode)
        {
            Orders rs = entities.Orders.Where(d => d.orderCode == _orderCode).FirstOrDefault();
            rs.orderStatus = 2;
            entities.SaveChanges();
            if (rs == null)
            {
                return 0;
            }
            return 1;
        }
        public int AddOrderDetail(OrderDetailModelView _orderDetail)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.orderID = _orderDetail.orderID;
            orderDetail.photoID = _orderDetail.photoID;
            orderDetail.quantity = _orderDetail.quantity;
            var rs = entities.OrderDetail.Add(orderDetail);
            entities.SaveChanges();
            if (rs == null)
            {
                return 0;
            }
            return 1;
        }
        public List<OrdersModelView> GetOrderByUserID(int userID)
        {
            var rs = entities.Orders.Where(d => d.userID == userID).Select(d => new OrdersModelView
            {
                orderID = d.orderID,
                userID = d.userID,
                orderCode = d.orderCode,
                orderDay = d.orderDay,
                orderStatus = d.orderStatus,
                deliveryAddress = d.deliveryAddress,
                paymentMethod = d.paymentMethod,
                totalPrice = d.totalPrice
            }).ToList();
            return rs;
        }
        public List<PhotoModelView> GetPhotoDownLoadedByUserid(int userid)
        {
            List<Users> lsUser = entities.Users.Where(d=>d.userID==userid).ToList();
            List<Orders> lsOrder = entities.Orders.ToList();
            List<OrderDetail> lsOrderDetail = entities.OrderDetail.ToList();
            List<Photos> LsPhotoModelView = entities.Photos.ToList();
            var photoRecord = (from user in lsUser
                               join order in lsOrder on user.userID equals order.userID
                               join orderDetail in lsOrderDetail on order.orderID equals orderDetail.orderID
                               join photo in LsPhotoModelView on orderDetail.photoID equals photo.photoID
                               select new PhotoModelView()
                               {
                  
                                   photoID = photo.photoID,
                                   photoName = photo.photoName,
                                   description = photo.description,
                                   status = photo.status,
                                   cateID = photo.cateID,
                                   photoLink = photo.photoLink,
                                   formatID = photo.formatID,
                                   Price = photo.Price,
                                   ID = photo.ID
                               }).ToList();
            return photoRecord;
        }
        ///////
        public List<OrdersModelView> ListOrderByDate(DateTime date)
        {
            var _date = date.DayOfYear;
            var Lis = entities.Orders.Select(d => new OrdersModelView { orderID = d.orderID, userID = d.userID, orderCode = d.orderCode, orderDay = d.orderDay, orderStatus = d.orderStatus, deliveryAddress = d.deliveryAddress, paymentMethod = d.paymentMethod, totalPrice = d.totalPrice }).ToList();
            var rs = new List<OrdersModelView>();
            foreach (var item in Lis)
            {
                DateTime d = (DateTime)item.orderDay;
                if (d.DayOfYear == _date)
                {
                    rs.Add(item);
                }
            }
            return rs;
        }
        public List<OrdersModelView> ListOrderByOrderCode(string OrderCode)
        {
            string _OrderCode = OrderCode;
            var rs = entities.Orders.Where(d => d.orderCode.Contains(_OrderCode)).Select(d => new OrdersModelView { orderID = d.orderID, userID = d.userID, orderCode = d.orderCode, orderDay = d.orderDay, orderStatus = d.orderStatus, deliveryAddress = d.deliveryAddress, paymentMethod = d.paymentMethod, totalPrice = d.totalPrice }).ToList();

            // no view
            return rs;
        }
        public List<OrdersModelView> ListOrderByOrderStatus(string OrderStatus)
        {
            string _OrderStatus = OrderStatus;
            var rs = entities.Orders.Where(d => d.orderStatus.ToString().Contains(_OrderStatus)).Select(d => new OrdersModelView { orderID = d.orderID, userID = d.userID, orderCode = d.orderCode, orderDay = d.orderDay, orderStatus = d.orderStatus, deliveryAddress = d.deliveryAddress, paymentMethod = d.paymentMethod, totalPrice = d.totalPrice }).ToList();

            // no view
            return rs;
        }
        public List<SearchModelView> searches(SearchModelView view)
        {
            List<SearchModelView> lis = new List<SearchModelView>();
            var listOrderByDate= ListOrderByDate((DateTime)view.OrderModelView.orderDay);
            foreach (var item in listOrderByDate)
            {
                SearchModelView searchModelView = new SearchModelView();
                searchModelView.OrderModelView = item;
                lis.Add(searchModelView);
            }
            return lis;
        }
    }

}