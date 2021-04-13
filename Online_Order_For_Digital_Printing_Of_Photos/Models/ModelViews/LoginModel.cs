using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter your UserName")]
        [Display(Name = "User Name")]
        public string userName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your Password")]
        public string userPwd { get; set; }
    }
}