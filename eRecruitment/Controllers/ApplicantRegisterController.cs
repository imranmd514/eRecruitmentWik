using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLayer;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using Utils;



namespace eRecruitment.Controllers
{
    public class ApplicantRegisterController : Controller
    {
        string strSenderEmailAddress = ConfigurationManager.AppSettings["SenderEmailAddress"].ToString();
        string strEmailSubject = ConfigurationManager.AppSettings["ApplicantEmailSubject"].ToString();
        // GET: ApplicantRegister
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Applicant Register";
            ViewBag.Title = "Applicant";
            ViewBag.Icon = "fa fa-user";
            EmailAddressBO objEmailAddressBO = new EmailAddressBO();
            return View();
        }

        [HttpPost]
        public JsonResult SaveApplicantRegisterEmail(EmailAddressBO Data)
        {
            string strResult = "";
            ApplicantRegisterBAL objApplicantRegisterBAL = new ApplicantRegisterBAL();
            Data.IsActive = true;
            string strReturnPassword = "";
            string strEmailBody = "";
            if (Data.EmailAddress != "")
            {
                strEmailBody = getEmailBody(Data.EmailAddress, ref strReturnPassword);
            }

            if (strResult == "")
            {
                strResult = objApplicantRegisterBAL.SaveorUpdateApplicantRegisterEmail(Data, strReturnPassword, 1);
                if (strResult == "SUCCESS" && Data.EmailAddress != "")
                {
                    CommonUtils.SendEmail(strSenderEmailAddress, Data.EmailAddress, strEmailSubject, strEmailBody);
                }
            }
            return Json(strResult, JsonRequestBehavior.AllowGet);

        }

        public string getEmailBody(string strUserName, ref string strRefPassword)
        {
            string strResult = "<table>";
            Random objRandom = new Random();
            string strPassword = "Win@" + objRandom.Next(10000) + "";
            strRefPassword = GenerateSHA512String(strPassword);
            //strResult = strResult + "<tr><td>Dear " + name + ", </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td>Thank you for interest in windle </td></tr>";
            strResult = strResult + "<tr><td>If you need to log back in to your account at any time to complete an application or to change any of your details, please log in to windle e - recruitment portal.</td></tr>";
            strResult = strResult + "<tr><td>Please note that we do not review incomplete applications. </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td>Your email credentials to login into E-Recruitment Portal is : </td></tr>";
            strResult = strResult + "<table><tr><td>Email Address : </td><td>" + strUserName + " </td></tr>";
            strResult = strResult + "<tr><td>Password : </td><td>" + strPassword + " </td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "</table>";
            strResult = strResult + "<tr><td>You can ensure that your application is complete by checking: </td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td>*That all mandatory fields are filled out.</td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td>*That all sections are completed and ticked as completed.</td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td>Please note that you need to complete your application before the closing date of the position in order for it to be considered. </td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td>**This mailbox is not monitored. </td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td>Please note that we do not accept CVs via email. You must apply online to be considered for our vacancies.** </td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td>Thank you for your interest in working with Windle International Kenya.</td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td>Recruitment Team,  </td></tr>";
            strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr></table>";

            //strResult = strResult + "<tr><td td colspan='2' align='center'>Your email credentials to login into E-Recruitment System WIK is : </td></tr>";
            //strResult = strResult + "<table><tr><td>Email Address : </td><td>" + strUserName + " </td></tr>";
            //strResult = strResult + "<tr><td>Password : </td><td>" + strPassword + " </td></tr>";
            //strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            //strResult = strResult + "<tr><td><br/></td><td></td></tr>";
            //strResult = strResult + "<tr><td>Thank You</td><td></td></tr>";
            //strResult = strResult + "</table>";

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

