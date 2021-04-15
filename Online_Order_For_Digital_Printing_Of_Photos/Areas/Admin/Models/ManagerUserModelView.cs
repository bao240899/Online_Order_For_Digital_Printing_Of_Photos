using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Areas.Admin.Models
{
    public class ManagerUserModelView
    {
        public int userID { get; set; }
        [Display(Name = "UserName")]
        public string userName { get; set; } 
       
        [Display(Name = "Email")]
        public string email { get; set; }
       
        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "Status")]
        public int status { get; set; }

        [Display(Name = "Role")]
        public string role { get; set; }
        
        [Display(Name = "Name")]
        public string name { get; set; }
        public ManagerUserModelView() { }
        public ManagerUserModelView(int userID, string userName, string email, string address, int status, string role, string name)
        {
            this.userID = userID;
            this.userName = userName;
            this.email = email;
            this.address = address;
            this.status = status;
            this.role = role;
            this.name = name;
        }
    }

}