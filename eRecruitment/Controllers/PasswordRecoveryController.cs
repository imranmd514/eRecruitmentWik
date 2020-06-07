using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Utils;

namespace eRecruitment.Controllers
{
    public class PasswordRecoveryController : Controller
    {
        string strSenderEmailAddress = ConfigurationManager.AppSettings["SenderEmailAddress"].ToString();
        string strEmailSubject = ConfigurationManager.AppSettings["EmailSubject"].ToString();

        // GET: PasswordRecovery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult sendMail(string strEmailAddress)
        {
            string strReturnPassword = "";
            string strResult = "";
            if (strEmailAddress.Trim() != "")
            {
                PasswordRecoveryBAL objPasswordRecoveryDAL = new PasswordRecoveryBAL();
                string strEmailBody = getEmailBody(strEmailAddress, ref strReturnPassword);
                strResult = objPasswordRecoveryDAL.getAllApplicantsList(strEmailAddress, strReturnPassword);
                if (strResult == "SUCCESS")
                {
                    strResult = CommonUtils.SendEmail(strSenderEmailAddress, strEmailAddress, strEmailSubject, strEmailBody);
                }                
            }
            
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }


        public string getEmailBody(string strUserName, ref string strRefPassword)
        {
            string strResult = "<table><tr><td colspan='2' align='center'>";
            Random objRandom = new Random();
            string strPassword = "Win@" + objRandom.Next(10000) + "";
            strRefPassword = GenerateSHA512String(strPassword);
            strResult = strResult + "Your email credentials to login into E-Recruitment System WIK is : </td></tr>";
            strResult = strResult + "<tr><td>Email Address : </td>" + "<td>" + strUserName + " </td></tr>";
            strResult = strResult + "<tr><td>Password : </td>" + "<td>" + strPassword + " </td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td>Thank You</td><td></td></tr>";
            strResult = strResult + "</table>";

            return strResult;
        }

        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

    }
}