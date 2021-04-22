using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.PayPalModel
{
    public class PaypalLogger
    {
        public static string LogDirectoryPath = Environment.CurrentDirectory;
        public static void Log(string msg)
        {
            try
            {
                StreamWriter str = new StreamWriter(LogDirectoryPath + "\\PaypalError.log", true);
                str.WriteLine("{0}--->{1}", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), msg);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}