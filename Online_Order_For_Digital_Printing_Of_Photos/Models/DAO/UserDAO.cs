using Online_Order_For_Digital_Printing_Of_Photos.Models.ModelViews;
using Online_Order_For_Digital_Printing_Of_Photos.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using Online_Order_For_Digital_Printing_Of_Photos.Areas.Admin.Models;

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
        // show ////////
        public List<UserModelView> ListUserByName()
        {
            var rs = entities.Users.Select(d => new UserModelView { userID = (int)d.userID, userName = d.userName, userPwd = d.userPwd, email = d.email, address = d.address, status = d.status, role = d.role, name = d.name }).ToList();
            return rs;
        }

        public int ChangeStatusByID(int id)
        {
            var rs = entities.Users.Where(d => d.userID == id).FirstOrDefault();
            if (rs.status == 1)
            {
                rs.status = 0;
                entities.SaveChanges();
                return 1;
            }
            else if (rs.status == 0)
            {
                rs.status = 1;
                entities.SaveChanges();
                return 1;
            }
            return 0;
        }

        public List<ManagerUserModelView> ListUserToManager()
        {
            var rs = entities.Users.Select(d => new ManagerUserModelView { userID = (int)d.userID, userName = d.userName, email = d.email, address = d.address, status = d.status, role = d.role, name = d.name }).ToList();
            return rs;
        }
        public List<UserModelView> ShowAllUser()
        {

            List<UserModelView> rs = entities.Users.Select(d => new UserModelView { userID = (int)d.userID, userName = d.userName, userPwd = d.userPwd, email = d.email, address = d.address, status = d.status, role = d.role, name = d.name }).ToList();

            return rs;
        }
        public UserModelView GetUserByName(string username)
        {
            var rs = entities.Users.Where(d => d.userName == username).Select(d => new UserModelView { userID = (int)d.userID, userName = d.userName, userPwd = d.userPwd, email = d.email, address = d.address, status = d.status, role = d.role, name = d.name }).FirstOrDefault();
            return rs;
        }

        public UserModelView GetUserById(int userid)
        {
            var rs = entities.Users.Where(d => d.userID == userid).Select(d => new UserModelView { userID = (int)d.userID, userName = d.userName, userPwd = d.userPwd, email = d.email, address = d.address, status = d.status, role = d.role, name = d.name }).FirstOrDefault();
            return rs;
        }
        /// show ////////
        public int Login(LoginModelView loginModelView)
        {

            string pwd = GetMD5(loginModelView.userPwd);
            var res = entities.Users.Where(d => d.userName == loginModelView.userName).Select(d => new UserModelView { userID = (int)d.userID, userName = d.userName, userPwd = d.userPwd, email = d.email, address = d.address, status = d.status, role = d.role, name = d.name }).FirstOrDefault();
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
                    if (res.userPwd == pwd)
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
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
        public int Register(UserModelView user)
        {
            var CkName = entities.Users.SingleOrDefault(x => x.userName == user.userName);

            var CkMail = entities.Users.Select(d => d.email == user.email);
            if (CkName != null)
            {
                return -1;
            }
            else if (CkMail != null)
            {
                return -2;
            }
            Users _user = new Users() { };
            _user.userID = user.userID;

            _user.userName = user.userName;
            ////////
            var pwd = GetMD5(user.userPwd);
            ///////
            _user.userPwd = pwd;
            _user.email = user.email;
            _user.address = user.address;
            _user.role = user.role;
            _user.status = user.status;
            _user.name = user.name;
            entities.Configuration.ValidateOnSaveEnabled = false;
            var rs = entities.Users.Add(_user);
            entities.SaveChanges();
            if (rs == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public int ChangePwd(UserModelView user)
        {
            var NewPwd = user.userPwd;
            NewPwd = GetMD5(NewPwd);
            Users rs = entities.Users.Where(d => d.userID == user.userID).FirstOrDefault();
            rs.userPwd = NewPwd;
            int resultAction = entities.SaveChanges();
            if (resultAction > 0)
            {
                return 1;
            }
            return 0;
        }

        public int ChangeEmail(UserModelView user)
        {
            var NewEmail = user.email;
            Users rs = entities.Users.Where(d => d.userID == user.userID).FirstOrDefault();
            rs.email = NewEmail;
            int resultAction = entities.SaveChanges();
            if (resultAction > 0)
            {
                return 1;
            }
            return 0;
        }
        public int ChangeAddress(UserModelView user)
        {
            var NewAddress = user.address;
            Users rs = entities.Users.Where(d => d.userID == user.userID).FirstOrDefault();
            rs.address = NewAddress;
            int resultAction = entities.SaveChanges();
            if (resultAction > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}