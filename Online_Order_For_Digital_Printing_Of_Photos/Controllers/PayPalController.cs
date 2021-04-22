using Online_Order_For_Digital_Printing_Of_Photos.Common;
using Online_Order_For_Digital_Printing_Of_Photos.Models.DAO;
using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews.Cart;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Order_For_Digital_Printing_Of_Photos.Controllers
{
    public class PayPalController : Controller
    {
        OrderDao orderDao = new OrderDao();
        PhotoDAO photoDAO = new PhotoDAO();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Failure()
        {
            string orderCode = (string)Session["orderCode"];
            orderDao.OrderFail(orderCode);
            Session["orderCode"]=null;
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult Success()
        {
            List<CartItemModelView> Cart = (List<CartItemModelView>)Session[CommonConstant.CART_SESSION];
            foreach ( var item in Cart) {
                photoDAO.changeStasus(item.photo.photoID);
            }
            Session[Common.CommonConstant.CART_SESSION] = null;
            return RedirectToAction("DownLoadedPhoto", "User");
        }
        //work with paypal payment
        private Payment payment;

        //create a payment using an APIContext
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var lsItem = new ItemList();
            UserSession user = (UserSession)Session[Common.CommonConstant.USER_SESSION];
            var cart = Session[Common.CommonConstant.CART_SESSION];
            string subtotal = "0";
            
                List<CartItemModelView> list = (List<CartItemModelView>)cart;
                lsItem = new ItemList() { items = new List<Item>() };
                var subtotal_Cart = 0;
                foreach (var item in list) {
                    lsItem.items.Add(new Item { name = item.photo.photoName, currency = "USD", price =(string)item.photo.Price.ToString(), quantity = "1", sku = "photo" });
                    subtotal_Cart = (int)(subtotal_Cart + item.photo.Price);
                }
                subtotal = subtotal_Cart.ToString();
            
            /*var lsItem = new ItemList() { items = new List<Item>() };
            lsItem.items.Add(new Item { name = "Item 1", currency = "USD", price = "5", quantity = "1", sku = "sku" });
            lsItem.items.Add(new Item { name = "Item 2", currency = "USD", price = "5", quantity = "2", sku = "sku" });*/

            var payer = new Payer()
            {
                payment_method = "paypal",
                payer_info = new PayerInfo
                {
                    email = "" //personal account
                }

            };
            var redictUrl = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };
            var detail = new Details() { tax = "0", shipping = "0", subtotal = subtotal }; //subtotal: sum(price*quantity) if sum is incorrect, it will return an error 400.
            var amount = new Amount() { currency = "USD", details = detail, total = subtotal}; //total= tax + shipping + subtotal
            var transList = new List<Transaction>();
            transList.Add(new Transaction
            {
                description = " Payment",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = lsItem,

            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transList,
                redirect_urls = redictUrl
            };
            return this.payment.Create(apiContext);
        }
        //create execute payment method
        private Payment ExecutePayment(APIContext apiContext, string payerID, string paymentID)
        {
            var paymentExecute = new PaymentExecution() { payer_id = payerID };
            this.payment = new Payment() { id = paymentID };
            return this.payment.Execute(apiContext, paymentExecute);
        }
        //create method
        public ActionResult PaymentWithPaypal()
        {
            APIContext apiContext = Models.PayPalModel.PaypalConfiguration.GetAPIContext();
            try
            {
                string payerID = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerID))
                {
                    //create a payment
                    string baseUri = Request.Url.Scheme + "://" + Request.Url.Authority + "/Paypal/PaymentWithPaypal?guid=";
                    string guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = CreatePayment(apiContext, baseUri + guid);

                    var link = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;
                    while (link.MoveNext())
                    {
                        Links links = link.Current;
                        if (links.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = links.href;
                        }
                    }
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executePayment = ExecutePayment(apiContext, payerID, Session[guid] as string);
                    if (executePayment.state.ToLower() != "approved")
                    {
                        return RedirectToAction("Failure", "PayPal");
                    }
                }
            }
            catch (PayPal.PaymentsException ex)
            {
                Models.PayPalModel.PaypalLogger.Log("Error: " + ex.Message);
                return RedirectToAction("Failure", "PayPal");
            }

            return RedirectToAction("Success", "PayPal");
        }
    }
}