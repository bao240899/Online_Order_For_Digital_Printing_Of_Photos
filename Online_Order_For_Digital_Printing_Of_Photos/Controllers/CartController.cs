using Online_Order_For_Digital_Printing_Of_Photos.Common;
using Online_Order_For_Digital_Printing_Of_Photos.Models.DAO;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Order_For_Digital_Printing_Of_Photos.Controllers
{
    public class CartController : Controller
    {
        public PhotoDAO PhotoDAO = null;
        public OrderDao OrderDao = null;

        public CartController() {
            PhotoDAO = new PhotoDAO();
            OrderDao = new OrderDao();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var cart = Session[CommonConstant.CART_SESSION];
            var user = Session[CommonConstant.USER_SESSION];
            var list = (List<CartItemModelView>)cart;
            if (cart != null) {
                list = (List<CartItemModelView>)cart;
                ViewBag.Cart = list;
                ViewBag.user = user;
                return View();
            }
            return View();
        }
        public ActionResult AddItem(int photoID)
        {
            var rs = PhotoDAO.GetPhotoByPhotoID(photoID);
            var cart = Session[CommonConstant.CART_SESSION];
            if (cart != null)
            {
                var list = (List<CartItemModelView>)cart;
                if (list.Exists(x => x.photo.photoID == photoID))
                {
                    foreach (var item in list)
                    {
                        if (item.photo.photoID == photoID)
                        {
                            item.quantity = 1;
                        }
                    }
                }
                else
                {
                    // new cart item
                    var item = new CartItemModelView();
                    item.photo = rs;
                    item.quantity = 1;
                    list.Add(item);
                }
                // session
                Session[CommonConstant.CART_SESSION] = list;
            }
            else
            {
                // new cart item
                var item = new CartItemModelView();
                item.photo = rs;
                item.quantity = 1;
                var list = new List<CartItemModelView>();
                list.Add(item);
                // new cart item
                Session[CommonConstant.CART_SESSION] = list;
            }

            return RedirectToAction("Index");
        }
        public ActionResult Remove(int photoID)
        {

            var cart = Session[CommonConstant.CART_SESSION];

            if (cart != null)
            {
                int index = -1;
                int tmp = 0;
                var list = (List<CartItemModelView>)cart;
                if (list.Exists(x => x.photo.photoID == photoID))
                {

                    foreach (var item in list)
                    {
                        index++;
                        if (item.photo.photoID == photoID)
                        {
                            tmp = index;
                        }
                        
                    }
                    list.RemoveAt(tmp);
                }
                
                // session
                Session[CommonConstant.CART_SESSION] = list;
            }


            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddOrder(OrdersModelView _order)
        {
            // ko biet invalid o dau
            /*if (ModelState.IsValid)
            {*/
                if (Session[CommonConstant.USER_SESSION] != null && Session[CommonConstant.CART_SESSION] != null)
                {
                    var rs = OrderDao.AddOrder(_order);
                    if (rs == 1) {
                        var selectOrder = OrderDao.GetOrderByOrderCode(_order.orderCode);
                        foreach (var item in (List<CartItemModelView>)Session[CommonConstant.CART_SESSION]) {
                            OrderDetailModelView orderDetail = new OrderDetailModelView();
                            orderDetail.orderID = selectOrder.orderID;
                            orderDetail.photoID = item.photo.photoID;
                            orderDetail.quantity = 1;
                            rs =OrderDao.AddOrderDetail(orderDetail);
                            if (rs == 0) {
                                break;
                                return RedirectToAction("Index", "Cart");
                            }
                        }
                        Session["orderCode"] = _order.orderCode;
                        return RedirectToAction("PaymentWithPaypal", "PayPal");
                    }
                    /*Session[CommonConstant.CART_SESSION] = null;*/
                    return RedirectToAction("Index", "Cart", new { area = "" });
                }
                return RedirectToAction("Login", "Cart", new { area = "" });
            /*}
            return RedirectToAction("Index", "Cart", new { area = "" });*/
        }
    }
    
    
}