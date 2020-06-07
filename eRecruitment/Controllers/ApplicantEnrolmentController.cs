using BusinessLayer;
using eRecruitment.CustomFilters;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Utils;

namespace eRecruitment.Controllers
{

    public class ApplicantEnrolmentController : Controller
    {
        string strCVSavedUploadPath = ConfigurationManager.AppSettings["CV"].ToString();
        string strApplicationLetterUploadPath = ConfigurationManager.AppSettings["ApplicationLetter"].ToString();
        string strBachelorsUploadPath = ConfigurationManager.AppSettings["Bachelors"].ToString();
        string strDiplomaUploadPath = ConfigurationManager.AppSettings["Diploma"].ToString();
        string strMSCUploadPath = ConfigurationManager.AppSettings["MSC"].ToString();
        string strPHDUploadPath = ConfigurationManager.AppSettings["PHD"].ToString();
        string strPhotoUploadPath = ConfigurationManager.AppSettings["Photo"].ToString();
        string strCitizenShipIdCopyUploadPath = ConfigurationManager.AppSettings["CitizenShipIdCopy"].ToString();
        //string strIdTypeCopyUploadPath = ConfigurationManager.AppSettings["IdTypeCopy"].ToString();

        string strSenderEmailAddress = ConfigurationManager.AppSettings["SenderEmailAddress"].ToString();
        string strEmailSubject = ConfigurationManager.AppSettings["ApplicantEmailSubject"].ToString();

        string strViewUploadPhotoPath = ConfigurationManager.AppSettings["ViewPhoto"].ToString();

        public ActionResult Index()
        {
            ViewBag.MainTitle = "Applicant Registration";
            ViewBag.Title = "Applicant";
            ViewBag.Icon = "fa fa-user";
            ApplicantRegistrationBO objApplicantRegistrationBO = new ApplicantRegistrationBO();
            ApplicantRegistrationBAL objApplicantRegistrationBAL = new ApplicantRegistrationBAL();
            objApplicantRegistrationBO.CountriesList = objApplicantRegistrationBAL.CountryList();
            objApplicantRegistrationBO.TitleList = objApplicantRegistrationBAL.TitleList();
            objApplicantRegistrationBO.GenderList = objApplicantRegistrationBAL.GenderList();
            objApplicantRegistrationBO.RefererList = objApplicantRegistrationBAL.RefererList();
            objApplicantRegistrationBO.IdTypeList = objApplicantRegistrationBAL.IdTypeList();
            // @ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            if (objApplicantRegistrationBO.PhotoSavedName == "" || objApplicantRegistrationBO.PhotoSavedName == null)
            {
                ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            }
            else
            {
                ViewBag.ImagePath = Url.Content(strViewUploadPhotoPath + objApplicantRegistrationBO.PhotoSavedName);
            }
            return View(objApplicantRegistrationBO);
        }

        [HttpPost]
        public JsonResult SaveApplicantRegistration(ApplicantRegistrationBO Data)
        {
            string strResult = "";
            if (Request.Files.Count > 0)
            {
                string strFileName = "";
                string strExtention = "";
                Random objRandom = new Random();
                string strRandom = objRandom.Next(10000) + "";
                string strFileUploadPath = "";

                string fileName = "";
                string fileContentType = "";
                byte[] tempFileBytes = null;
                dynamic data = null;
                dynamic types = null;
                bool result = false;

                HttpFileCollectionBase files = Request.Files;
                if (files != null)
                {

                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        if (file.ContentLength == 0)
                        {
                            strResult = "Upload file should not be empty";
                        }
                        else if (file.ContentLength > 0)
                        {
                            strExtention = Path.GetExtension(file.FileName);
                            fileName = file.FileName; // getting File Name
                            fileContentType = file.ContentType; // getting ContentType
                            tempFileBytes = new byte[file.ContentLength]; // getting filebytes
                            data = file.InputStream.Read(tempFileBytes, 0, Convert.ToInt32(file.ContentLength));
                            types = CommonUtils.FileType.Image;  // Setting Image type
                            if (strExtention.ToUpper() == ".PDF")
                            {
                                types = CommonUtils.FileType.PDF;
                            }
                            else if (strExtention.ToUpper() == ".DOC")
                            {
                                types = CommonUtils.FileType.DOC;
                            }
                            else if (strExtention.ToUpper() == ".DOCX")
                            {
                                types = CommonUtils.FileType.DOCX;
                            }
                            result = CommonUtils.isValidFile(tempFileBytes, types, fileContentType); // Validate Header                                   
                            strFileName = strRandom + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) + strExtention;
                            var strFileType = file.FileName.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                            if (result)
                            {
                                int FileLength = 1024 * 1024 * 3; //FileLength 3 MB
                                if (file.ContentLength > FileLength)
                                {
                                    strResult = "Upload file should not be greater than 3MB";
                                }

                                if (strFileType[0] == "PHOTO")
                                {
                                    Data.PhotoSavedName = strFileName;
                                    strFileUploadPath = strPhotoUploadPath;
                                }
                                if (strFileType[0] == "RESUME")
                                {
                                    Data.CVSavedName = strFileName;
                                    strFileUploadPath = strCVSavedUploadPath;
                                }
                                if (strFileType[0] == "IDCOPY")
                                {
                                    Data.CitizenShipIdCopySavedName = strFileName;
                                    strFileUploadPath = strCitizenShipIdCopyUploadPath;
                                }
                                if (strFileType[0] == "APPLICATIONLETTER")
                                {
                                    Data.ApplicationLetterSavedName = strFileName;
                                    strFileUploadPath = strApplicationLetterUploadPath;
                                }
                                //if (strFileType[0] == "BACHELORS")
                                //{
                                //    Data.BachelorsSavedName = strFileName;
                                //    strFileUploadPath = strBachelorsUploadPath;
                                //}
                                //if (strFileType[0] == "DIPLOMA")
                                //{
                                //    Data.DiplomaSavedName = strFileName;
                                //    strFileUploadPath = strDiplomaUploadPath;
                                //}
                                //if (strFileType[0] == "MSC")
                                //{
                                //    Data.MSCSavedName = strFileName;
                                //    strFileUploadPath = strMSCUploadPath;
                                //}
                                //if (strFileType[0] == "PHD")
                                //{
                                //    Data.PHDSavedName = strFileName;
                                //    strFileUploadPath = strPHDUploadPath;
                                //}
                                strFileName = Path.Combine(strFileUploadPath, strFileName);
                                file.SaveAs(strFileName);

                            }
                            else
                            {
                                strResult = strResult + "Please Upload Valid file for " + strFileType[0] + "</br>";
                            }
                        }
                    }
                }
            }
            ApplicantRegistrationBAL objApplicantRegistrationBAL = new ApplicantRegistrationBAL();
            Data.IsActive = true;
            string strReturnPassword = "";
            string strEmailBody = "";
            if (Data.EmailAddress != "")
            {
                strEmailBody = getEmailBody((Data.FirstName + Data.LastName), Data.EmailAddress, ref strReturnPassword);
            }

            if (strResult == "")
            {
                strResult = objApplicantRegistrationBAL.SaveorUpdateApplicantRegistration(Data, strReturnPassword, 1);
                if (strResult == "SUCCESS" && Data.EmailAddress != "")
                {
                    strResult = CommonUtils.SendEmail(strSenderEmailAddress, Data.EmailAddress, strEmailSubject, strEmailBody);
                }
            }
            return Json(strResult, JsonRequestBehavior.AllowGet);

        }

        public string getEmailBody(string name, string strUserName, ref string strRefPassword)
        {
            string strResult = "<table>";
            Random objRandom = new Random();
            string strPassword = "Win@" + objRandom.Next(10000) + "";
            strRefPassword = GenerateSHA512String(strPassword);
            strResult = strResult + "<tr><td>Dear " + name + ", </td></tr>";
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


        //public string getEmailBody(string name, string strUserName, ref string strRefPassword)
        //{
        //    string strResult = "<table>";
        //    Random objRandom = new Random();
        //    string strPassword = "Win@" + objRandom.Next(10000) + "";
        //    strRefPassword = GenerateSHA512String(strPassword);
        //    strResult = strResult + "<tr><td>Dear " + name + ", </td></tr>";
        //    strResult = strResult + "<tr><td><td><br/></td></tr>";
        //    strResult = strResult + "<tr><td>Welcome to WIK Job Portal </td></tr>";
        //    strResult = strResult + "<tr><td>Thanks for signing up. With WIK Job Portal, you can apply for jobs, get updates on job openings and more. </td></tr>";
        //    strResult = strResult + "<tr><td><td><br/></td></tr>";
        //    strResult = strResult + "<tr><td><td><br/></td></tr></table>";

        //    strResult = strResult + "<tr><td td colspan='2' align='center'>Your email credentials to login into E-Recruitment System WIK is : </td></tr>";
        //    strResult = strResult + "<table><tr><td>Email Address : </td><td>" + strUserName + " </td></tr>";
        //    strResult = strResult + "<tr><td>Password : </td><td>" + strPassword + " </td></tr>";
        //    strResult = strResult + "<tr><td><br/></td><td></td></tr>";
        //    strResult = strResult + "<tr><td><br/></td><td></td></tr>";
        //    strResult = strResult + "<tr><td>Thank You</td><td></td></tr>";
        //    strResult = strResult + "</table>";

        //    return strResult;
        //}

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


