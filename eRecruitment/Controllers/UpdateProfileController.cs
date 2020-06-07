using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System.IO;
using BusinessLayer;
using System.Configuration;
using System.Globalization;
using Utils;
using System.Text;
using eRecruitment.CustomFilters;
using System.Security.Cryptography;

namespace eRecruitment.Controllers
{
    public class UpdateProfileController : BaseController
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

        string strViewUploadPhotoPath = ConfigurationManager.AppSettings["ViewPhoto"].ToString();
        string strAcademicQualificationUploadPath = ConfigurationManager.AppSettings["AcademicQualification"].ToString();

        // GET: UpdateProfile
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Applicant Registration";
            ViewBag.Title = "Applicant";
            ViewBag.Icon = "fa fa-user";
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            ApplicantRegistrationBO objApplicantRegistrationBO = new ApplicantRegistrationBO();
            objApplicantRegistrationBO = objUpdateProfileBAL.GetApplicantDetails(Convert.ToInt32(ViewData["EmployeeId"]));
            if (objApplicantRegistrationBO != null)
            {
                objApplicantRegistrationBO.CountriesList = objUpdateProfileBAL.CountryList();
                objApplicantRegistrationBO.TitleList = objUpdateProfileBAL.TitleList();
                objApplicantRegistrationBO.GenderList = objUpdateProfileBAL.GenderList();
                objApplicantRegistrationBO.RefererList = objUpdateProfileBAL.RefererList();
                objApplicantRegistrationBO.IdTypeList = objUpdateProfileBAL.IdTypeList();
                objApplicantRegistrationBO.AcademicQualificationsList = objUpdateProfileBAL.AcademicQualificationsList();
                objApplicantRegistrationBO.TypeOfIndustryList = objUpdateProfileBAL.TypeOfIndustryList();
            }
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
        //------------------------------------------------------------------------------//
     
        //-----------------------------Applicant Personal Information-------------------//
        [HttpPost]
        public JsonResult SaveApplicantRegistration(ApplicantPersonalInformationBO Data)
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
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            Data.IsActive = true;
            if (strResult == "")
            {
                strResult = objUpdateProfileBAL.SaveorUpdateApplicantRegistration(Data, 1);
            }
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        //-----------------------------Applicant Qualification-------------------------//

        [HttpPost]
        public JsonResult SaveApplicantQualification(ApplicantQualificationBO Data)
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
                                Data.AttachmentSavedName = strFileName;
                                strFileUploadPath = strAcademicQualificationUploadPath;
                                strFileName = Path.Combine(strFileUploadPath, strFileName);
                                file.SaveAs(strFileName);
                            }
                            //else
                            //{
                            //    strResult = strResult + "Please Upload Valid file for " + strFileType[0] + "</br>";
                            //}
                        }
                    }
                }
            }
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            Data.IsActive = true;
            strResult = objUpdateProfileBAL.SaveorUpdateApplicantQualification(Data, 1);
            //if (strResult == "")
            //{
            //    strResult = objUpdateProfileBAL.SaveorUpdateApplicantQualification(Data, 1);
            //}
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetApplicantQualificationList()
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            List<ApplicantQualificationBO> objApplicantQualificationBOList = objUpdateProfileBAL.GetApplicantQualificationList(Convert.ToInt32(ViewData["EmployeeId"]));
            return PartialView("ApplicantQualificationGrid", objApplicantQualificationBOList);
        }

        [HttpGet]
        public JsonResult EditApplicantQualification(int A_iApplicantQualificationId)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            ApplicantQualificationBO objApplicantQualificationBO = objUpdateProfileBAL.EditApplicantQualificationList(A_iApplicantQualificationId,Convert.ToInt32(ViewData["EmployeeId"]));
            return Json(objApplicantQualificationBO, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult DeleteApplicantQualification(int A_iApplicantQualificationId)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            string strResult = objUpdateProfileBAL.DeleteApplicantQualification(A_iApplicantQualificationId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveMembershipDataDetails(ApplicantMotivationalSkillBO Data)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            Data.IsActive = true;
            string strResult = objUpdateProfileBAL.SaveorUpdateMembershipData(Data, 1);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
        //-------------------------------------------------------------//

        [HttpPost]
        public JsonResult SaveApplicantEmploymentHistory(ApplicantEmploymentHistoryBO Data)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            Data.IsActive = true;
            string strResult = objUpdateProfileBAL.SaveorUpdateApplicantEmploymentHistory(Data, 1);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetApplicantEmploymentHistoryList()
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            List<ApplicantEmploymentHistoryBO> objEmploymentHistoryList = objUpdateProfileBAL.GetEmploymentHistoryList(Convert.ToInt32(ViewData["EmployeeId"]));
            return PartialView("EmploymentHistoryGrid", objEmploymentHistoryList);
        }

        [HttpGet]
        public JsonResult EditApplicantEmploymentHistory(int A_iEmploymentHistoryId)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO = objUpdateProfileBAL.EditApplicantEmploymentHistory(A_iEmploymentHistoryId, Convert.ToInt32(ViewData["EmployeeId"]));
            return Json(objApplicantEmploymentHistoryBO, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult DeleteApplicantEmploymentHistory(int A_iEmploymentHistoryId)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            string strResult = objUpdateProfileBAL.DeleteApplicantEmploymentHistory(A_iEmploymentHistoryId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        //-----------------------------------------------------------//
        [HttpPost]
        public JsonResult SaveApplicantRefereesDetails(ApplicantRefereesBO Data)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            Data.IsActive = true;
            string strResult = objUpdateProfileBAL.SaveorUpdateRefereesDetails(Data, 1);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetApplicantRefereesList()
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            List<ApplicantRefereesBO> objEmploymentHistoryList = objUpdateProfileBAL.GetApplicantRefereesList(Convert.ToInt32(ViewData["EmployeeId"]));
            return PartialView("ApplicantRefereesGrid", objEmploymentHistoryList);
        }

        [HttpGet]
        public JsonResult EditApplicantRefereesDetails(int A_iRefereesId)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            ApplicantRefereesBO objApplicantRefereesBO = objUpdateProfileBAL.EditApplicantRefereesData(A_iRefereesId, Convert.ToInt32(ViewData["EmployeeId"]));
            return Json(objApplicantRefereesBO, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteApplicantRefereesData(int A_iRefereesId)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            string strResult = objUpdateProfileBAL.DeleteApplicantRefereesData(A_iRefereesId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }


        //-------------------------------------------------------------------//
        [HttpPost]
        public JsonResult SaveMotivationSkillsDetails(ApplicantMotivationalSkillBO Data)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            Data.IsActive = true;
            string strResult = objUpdateProfileBAL.SaveorUpdateMotivationSkills(Data, 1);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        //---------------------------------------------------------------//

        [HttpPost]
        public JsonResult SaveApplicantDeclarationDetails(DeclarationBO Data)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            Data.IsActive = true;
            string strResult = objUpdateProfileBAL.SaveorUpdateDeclarationDetails(Data, 1);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        //-----------------------------Language------------------------------------------//
        [HttpPost]
        public JsonResult SaveApplicantLanguageDetails(LanguageSpokenBO Data)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            Data.IsActive = true;
            string strResult = objUpdateProfileBAL.SaveorUpdateApplicantLanguageDetails(Data, 1);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetApplicantLanguageList()
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            List<LanguageSpokenBO> objLanguageSpokenList = objUpdateProfileBAL.GetApplicantLanguageList(Convert.ToInt32(ViewData["EmployeeId"]));
            return PartialView("ApplicantLanguageGrid", objLanguageSpokenList);
        }

        [HttpGet]
        public JsonResult EditApplicantLanguageDetails(int A_iLanguageSpokenId)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            LanguageSpokenBO objLanguageSpokenBO = objUpdateProfileBAL.EditApplicantLanguageData(A_iLanguageSpokenId, Convert.ToInt32(ViewData["EmployeeId"]));
            return Json(objLanguageSpokenBO, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteApplicantLanguageData(int A_iLanguageSpokenId)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            string strResult = objUpdateProfileBAL.DeleteApplicantLanguageData(A_iLanguageSpokenId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        //--------------------------------Relation--------------------------------------//
        [HttpPost]
        public JsonResult SaveApplicantRelationDetails(ApplicantRelationBO Data)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            Data.IsActive = true;
            string strResult = objUpdateProfileBAL.SaveorUpdateApplicantRelationDetails(Data, 1);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetApplicantRelationDetailsList()
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            List<ApplicantRelationBO> objApplicantRelationList = objUpdateProfileBAL.GetApplicantRelationDetailsList(Convert.ToInt32(ViewData["EmployeeId"]));
            return PartialView("ApplicantRelationGrid", objApplicantRelationList);
        }

        [HttpGet]
        public JsonResult EditApplicantRelativeData(int A_iRelationId)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            ApplicantRelationBO objApplicantRelationBO = objUpdateProfileBAL.EditApplicantRelativeData(A_iRelationId, Convert.ToInt32(ViewData["EmployeeId"]));
            return Json(objApplicantRelationBO, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteApplicantRelationData(int A_iRelationId)
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            string strResult = objUpdateProfileBAL.DeleteApplicantRelationData(A_iRelationId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        //---------------------------------------------------------------------------//
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

        public ActionResult DownloadResume(string fileSavedName, string fileActualName)
        {
            string strFilePath = Path.Combine(strCVSavedUploadPath, fileSavedName);
            if (!System.IO.File.Exists(strFilePath))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = fileActualName
            };
            return response;
        }

        public ActionResult DownloadQualificationAttachment(string fileSavedName, string fileActualName)
        {
            string strFilePath = Path.Combine(strAcademicQualificationUploadPath, fileSavedName);
            if (!System.IO.File.Exists(strFilePath))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = fileActualName
            };
            return response;
        }

        public ActionResult DownloadApplicationLetter(string FileSavedName, string fileActualName)
        {
            string strFilePath = Path.Combine(strApplicationLetterUploadPath, FileSavedName);
            if (!System.IO.File.Exists(strFilePath))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = fileActualName
            };
            return response;
        }

        public ActionResult DownloadBachelors(string fileSavedName, string fileActualName)
        {
            string strFilePath = Path.Combine(strBachelorsUploadPath, fileSavedName);
            if (!System.IO.File.Exists(strFilePath))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = fileActualName
            };
            return response;
        }

        public ActionResult DownloadDiploma(string fileSavedName, string fileActualName)
        {
            string strFilePath = Path.Combine(strDiplomaUploadPath, fileSavedName);
            if (!System.IO.File.Exists(strFilePath))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = fileActualName
            };
            return response;
        }

        public ActionResult DownloadMSC(string fileSavedName, string fileActualName)
        {
            string strFilePath = Path.Combine(strMSCUploadPath, fileSavedName);
            if (!System.IO.File.Exists(strFilePath))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = fileActualName
            };
            return response;
        }

        public ActionResult DownloadPHD(string fileSavedName, string fileActualName)
        {
            string strFilePath = Path.Combine(strPHDUploadPath, fileSavedName);
            if (!System.IO.File.Exists(strFilePath))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = fileActualName
            };
            return response;
        }

        public ActionResult DownloadCitizenShipIdCopy(string fileSavedName, string fileActualName)
        {
            string strFilePath = Path.Combine(strCitizenShipIdCopyUploadPath, fileSavedName);
            if (!System.IO.File.Exists(strFilePath))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = fileActualName
            };
            return response;
        }
    }
}