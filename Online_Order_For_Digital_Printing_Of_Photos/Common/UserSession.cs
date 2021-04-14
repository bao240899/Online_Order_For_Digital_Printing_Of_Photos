using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Common
{
    [Serializable]
    public class UserSession
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string userPwd { get; set; }
        public int status { get; set; }
        public string role { get; set; }
        public string name { get; set; }
    }
}