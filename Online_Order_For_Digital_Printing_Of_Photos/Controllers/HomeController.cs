using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Order_For_Digital_Printing_Of_Photos.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }
        public ActionResult Index() {
            return View();
        }

        
    }
}