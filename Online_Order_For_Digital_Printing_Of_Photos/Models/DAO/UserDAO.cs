using Online_Order_For_Digital_Printing_Of_Photos.Areas.Users.Models;
using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.DAO
{
    
    public class UserDAO
    {
        // declare entities
        OnlineOrderEntities entities = null;
        public UserDAO() {
            // new in constructor
            entities = new OnlineOrderEntities();
        }
         
        // show All User
        public List<UserModelView> ShowAllUser() {

            List<UserModelView> rs = entities.Users.Select(d => new UserModelView { userID = (int)d.userID, userName = d.userName, userPwd = d.userPwd, email = d.email, address = d.address, status = d.status, role = d.role, name = d.name }).ToList();

            return rs;
        }
    }
}