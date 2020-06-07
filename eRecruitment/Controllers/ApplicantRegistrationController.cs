using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLayer;
using System.Configuration;
using System.IO;
using System.Globalization;
using Utils;
using System.Security.Cryptography;
using System.Text;
using eRecruitment.CustomFilters;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class ApplicantRegistrationController : BaseController
    {
        string strCVSavedUploadPath = ConfigurationManager.AppSettings["CV"].ToString();
        string strApplicationLetterUploadPath = ConfigurationManager.AppSettings["ApplicationLetter"].ToString();
        string strBachelorsUploadPath = ConfigurationManager.AppSettings["Bachelors"].ToString();
        string strDiplomaUploadPath = ConfigurationManager.AppSettings["Diploma"].ToString();
        string strMSCUploadPath = ConfigurationManager.AppSettings["MSC"].ToString();
        string strPHDUploadPath = ConfigurationManager.AppSettings["PHD"].ToString();
        string strPhotoUploadPath = ConfigurationManager.AppSettings["Photo"].ToString();
        string strCitizenShipIdCopyUploadPath = ConfigurationManager.AppSettings["CitizenShipIdCopy"].ToString();

        string strSenderEmailAddress = ConfigurationManager.AppSettings["SenderEmailAddress"].ToString();
        string strEmailSubject = ConfigurationManager.AppSettings["ApplicantEmailSubject"].ToString();


        public ActionResult Index()
        {
            ViewBag.MainTitle = "Applicant Registration";
            ViewBag.Title = "Applicant";
            ViewBag.Icon = "fa fa-user";
            ApplicantRegistrationBAL objApplicantRegistrationBAL = new ApplicantRegistrationBAL();
            ApplicantRegistrationBO objApplicantRegistrationBO = new ApplicantRegistrationBO();
            return View(objApplicantRegistrationBO);
        }

        [HttpGet]
        public ActionResult CreateApplicant()
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
            return View("AddApplicant", objApplicantRegistrationBO);
        }


        [HttpPost]
        public JsonResult SaveApplicantRegistration(ApplicantRegistrationBO Data)
        {
            if (Request.Files.Count > 0)
            {
                string strFileName = "";
                string strExtention = "";
                Random objRandom = new Random();
                string strRandom = objRandom.Next(1000000) + "";
                string strFileUploadPath = "";
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    strExtention = Path.GetExtension(file.FileName);
                    strFileName = strRandom + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) + strExtention;
                    var strFileType = file.FileName.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                    if (strFileType[0] == "PHOTO")
                    {
                        Data.PhotoSavedName = strFileName;
                        strFileUploadPath = strPhotoUploadPath;
                    }
                    if (strFileType[0] == "RESUME")
                    {
                        Data.ResumSavedName = strFileName;
                        strFileUploadPath = strCVSavedUploadPath;
                    }
                    if (strFileType[0] == "CITIZENSHIPIDCOPY")
                    {
                        Data.CitizenShipIdCopySavedName = strFileName;
                        strFileUploadPath = strCitizenShipIdCopyUploadPath;
                    }
                    if (strFileType[0] == "APPLICATIONLETTER")
                    {
                        Data.ApplicationLetterSavedName = strFileName;
                        strFileUploadPath = strApplicationLetterUploadPath;
                    }
                    if (strFileType[0] == "BACHELORS")
                    {
                        Data.BachelorsSavedName = strFileName;
                        strFileUploadPath = strBachelorsUploadPath;
                    }
                    if (strFileType[0] == "DIPLOMA")
                    {
                        Data.DiplomaSavedName = strFileName;
                        strFileUploadPath = strDiplomaUploadPath;
                    }
                    if (strFileType[0] == "MSC")
                    {
                        Data.MSCSavedName = strFileName;
                        strFileUploadPath = strMSCUploadPath;
                    }
                    if (strFileType[0] == "PHD")
                    {
                        Data.PHDSavedName = strFileName;
                        strFileUploadPath = strPHDUploadPath;
                    }

                    strFileName = Path.Combine(strFileUploadPath, strFileName);
                    file.SaveAs(strFileName);
                }
            }            

            ApplicantRegistrationBAL objApplicantRegistrationBAL = new ApplicantRegistrationBAL();
            Data.IsActive = true;
            string strResult = "";
            string strReturnPassword = "";
            string strEmailBody = "";
            if (Data.EmailAddress != "")
            {
                strEmailBody = getEmailBody((Data.FirstName + Data.LastName), Data.EmailAddress, ref strReturnPassword);
            }

            strResult = objApplicantRegistrationBAL.SaveorUpdateApplicantRegistration(Data, strReturnPassword, 1);
            if (strResult == "SUCCESS" && Data.EmailAddress != "")
            {
                strResult = CommonUtils.SendEmail(strSenderEmailAddress, Data.EmailAddress, strEmailSubject, strEmailBody);
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
            strResult = strResult + "<tr><td>Welcome to WIK Job Portal </td></tr>";
            strResult = strResult + "<tr><td>Thanks for signing up. With WIK Job Portal, you can apply for jobs, get updates on job openings and more. </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr></table>";

            strResult = strResult + "<tr><td td colspan='2' align='center'>Your email credentials to login into E-Recruitment System WIK is : </td></tr>";
            strResult = strResult + "<table><tr><td>Email Address : </td><td>" + strUserName + " </td></tr>";
            strResult = strResult + "<tr><td>Password : </td><td>" + strPassword + " </td></tr>";
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


        [HttpGet]
        public ActionResult getApplicantsList()
        {
            ApplicantRegistrationBAL objApplicantRegistrationBAL = new ApplicantRegistrationBAL();
            List<ApplicantRegistrationBO> objApplicantRegistrationBOList = objApplicantRegistrationBAL.getApplicantsList();
            return PartialView("ApplicantsList", objApplicantRegistrationBOList);
        }


        [HttpGet]
        public ActionResult EditApplicant(int iApplicantId)
        {
            ViewBag.MainTitle = "Applicant Registration";
            ViewBag.Title = "Applicant";
            ViewBag.Icon = "fa fa-user";
            ApplicantRegistrationBAL objApplicantRegistrationBAL = new ApplicantRegistrationBAL();
            ApplicantRegistrationBO objApplicantRegistrationBO = objApplicantRegistrationBAL.EditApplicantDetails(iApplicantId);
            objApplicantRegistrationBO.CountriesList = objApplicantRegistrationBAL.CountryList();
            objApplicantRegistrationBO.TitleList = objApplicantRegistrationBAL.TitleList();
            objApplicantRegistrationBO.GenderList = objApplicantRegistrationBAL.GenderList();
            objApplicantRegistrationBO.RefererList = objApplicantRegistrationBAL.RefererList();
            return PartialView("EditApplicantRegistration", objApplicantRegistrationBO);
        }


        [HttpPost]
        public JsonResult deleteApplicant(int iApplicantId)
        {
            ApplicantRegistrationBAL objApplicantRegistrationBAL = new ApplicantRegistrationBAL();
            string strResult = objApplicantRegistrationBAL.deleteApplicant(iApplicantId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ViewApplicantRegistration(int iApplicantId)
        {
            ApplicantRegistrationBAL objApplicantRegistrationBAL = new ApplicantRegistrationBAL();
            ApplicantRegistrationBO objApplicantRegistrationBO = objApplicantRegistrationBAL.ViewApplicant(iApplicantId);
            return PartialView("ViewApplicantRegistration", objApplicantRegistrationBO);
        }



        //public ActionResult DownloadAttachment(string FileSavedName, string fileActualName)
        //{
        //    string strFilePath = Path.Combine(strFileUploadPath1, FileSavedName);
        //    if (!System.IO.File.Exists(strFilePath))
        //    {
        //        return HttpNotFound();
        //    }

        //    var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
        //    var response = new FileContentResult(fileBytes, "application/octet-stream")
        //    {
        //        FileDownloadName = fileActualName
        //    };
        //    return response;
        //}

        //public ActionResult DownloadAttachment(string fileSavedName, string fileActualName)
        //{
        //    string strFilePath = Path.Combine(strFileUploadPath, fileSavedName);
        //    if (!System.IO.File.Exists(strFilePath))
        //    {
        //        return HttpNotFound();
        //    }

        //    var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
        //    var response = new FileContentResult(fileBytes, "application/octet-stream")
        //    {
        //        FileDownloadName = fileActualName
        //    };
        //    return response;
        //}

        //public ActionResult DownloadAttachment2(string fileSavedName, string fileActualName)
        //{
        //    string strFilePath = Path.Combine(strFileUploadPath2, fileSavedName);
        //    if (!System.IO.File.Exists(strFilePath))
        //    {
        //        return HttpNotFound();
        //    }

        //    var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
        //    var response = new FileContentResult(fileBytes, "application/octet-stream")
        //    {
        //        FileDownloadName = fileActualName
        //    };
        //    return response;
        //}

        //public ActionResult DownloadAttachment3(string fileSavedName, string fileActualName)
        //{
        //    string strFilePath = Path.Combine(strFileUploadPath3, fileSavedName);
        //    if (!System.IO.File.Exists(strFilePath))
        //    {
        //        return HttpNotFound();
        //    }

        //    var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
        //    var response = new FileContentResult(fileBytes, "application/octet-stream")
        //    {
        //        FileDownloadName = fileActualName
        //    };
        //    return response;
        //}

        //public ActionResult DownloadAttachment4(string fileSavedName, string fileActualName)
        //{
        //    string strFilePath = Path.Combine(strFileUploadPath4, fileSavedName);
        //    if (!System.IO.File.Exists(strFilePath))
        //    {
        //        return HttpNotFound();
        //    }

        //    var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
        //    var response = new FileContentResult(fileBytes, "application/octet-stream")
        //    {
        //        FileDownloadName = fileActualName
        //    };
        //    return response;
        //}

        //public ActionResult DownloadAttachment5(string fileSavedName, string fileActualName)
        //{
        //    string strFilePath = Path.Combine(strFileUploadPath5, fileSavedName);
        //    if (!System.IO.File.Exists(strFilePath))
        //    {
        //        return HttpNotFound();
        //    }

        //    var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
        //    var response = new FileContentResult(fileBytes, "application/octet-stream")
        //    {
        //        FileDownloadName = fileActualName
        //    };
        //    return response;
        //}
    }
}