using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews
{
    public class UserModelView
    {
        public int userID { get; set; }
        [Required(ErrorMessage = "Please enter your UserName")]
        [Display(Name = "UserName")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string userPwd { get; set; }
        [Required(ErrorMessage = "Please enter your Email")]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter your Address")]
        [Display(Name = "Address")]
        public string address { get; set; }
        public int status { get; set; }
        public string role { get; set; }
        [Required(ErrorMessage = "Please enter your Name")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Please enter your ConfirmPassword")]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("userPwd")]
        public string confirmPassword { get; set; }
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