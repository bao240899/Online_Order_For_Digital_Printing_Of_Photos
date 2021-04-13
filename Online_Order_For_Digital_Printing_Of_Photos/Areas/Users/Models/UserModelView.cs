using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Areas.Users.Models
{
    public class UserModelView
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string userPwd { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int status { get; set; }
        public string role { get; set; }
        public string name { get; set; }

        public UserModelView() { }
        public UserModelView(int userID, string userName, string userPwd, string email, string address, int status, string role, string name)
        {
            this.userID = userID;
            this.userName = userName;
            this.userPwd = userPwd;
            this.email = email;
            this.address = address;
            this.status = status;
            this.role = role;
            this.name = name;
        }
    }
}