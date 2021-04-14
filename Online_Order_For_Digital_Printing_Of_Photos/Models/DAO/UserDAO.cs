using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
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
        public UserDAO()
        {
            // new in constructor
            entities = new OnlineOrderEntities();
        }

        // show All User
        public List<UserModelView> ShowAllUser()
        {

            List<UserModelView> res = entities.Users.Select(d => new UserModelView
            {
                userID = (int)d.userID,
                userName = d.userName,
                userPwd = d.userPwd,
                email = d.email,
                address = d.address,
                status = d.status,
                role = d.role,
                name = d.name
            }).ToList();

            return res;
        }

        public Users GetUserByUserName(string username)
        {
            return entities.Users.SingleOrDefault(x => x.userName == username);
        }

        public int Login(string username, string password)
        {
            var res = entities.Users.SingleOrDefault(x => x.userName == username);
            if (res == null)
            {
                return 0;
            }
            else
            {
                if (res.status == 0)
                {
                    return -1;
                }
                else
                {
                    if (res.userPwd == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
    }
}