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
        [RegularExpression(pattern: "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$", ErrorMessage = "Minimum eight characters, at least one letter and one number")]        
        public string userPwd { get; set; }
        [Required(ErrorMessage = "Please enter your Email")]
        [Display(Name = "Email")]
        [RegularExpression(pattern: "^[a-z][a-z0-9\\.]{5,32}@[a-z0-9]{2,}(\\.[a-z0-9]{2,4}){1,2}$")]
        [EmailAddress(ErrorMessage = "Please enter a valid email: example@gmail.com")]
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
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [System.ComponentModel.DataAnnotations.Compare(otherProperty: "userPwd", ErrorMessage = "New & confirm password does not match")]
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