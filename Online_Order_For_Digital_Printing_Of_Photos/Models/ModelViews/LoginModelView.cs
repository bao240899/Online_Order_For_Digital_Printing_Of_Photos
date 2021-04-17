using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews
{
    public class LoginModelView
    {
        [Required(ErrorMessage = ("Please Enter Your UserName "))]
        [Display(Name = "UserName")]
        public string userName { get; set; }
        [Required(ErrorMessage = ("Please Enter Your Password "))]
        [Display(Name = "Password")]
        public string userPwd { get; set; }
    }
}