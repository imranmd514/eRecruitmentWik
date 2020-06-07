using BusinessLayer;
using eRecruitment.CustomFilters;
using Models;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class ApplicantDashBoardController : Controller
    {
        string strFileUploadPath = ConfigurationManager.AppSettings["ResumeSaved"].ToString();
        string strFileUploadPath1 = ConfigurationManager.AppSettings["SaveApplicationLetter"].ToString();
        string strFileUploadPath2 = ConfigurationManager.AppSettings["SaveBachelors"].ToString();
        string strFileUploadPath3 = ConfigurationManager.AppSettings["SaveDiplomaAttachment"].ToString();
        string strFileUploadPath4 = ConfigurationManager.AppSettings["SaveMSCAttachment"].ToString();
        string strFileUploadPath5 = ConfigurationManager.AppSettings["SavePHDAttachment"].ToString();

        public ActionResult Index()
        {
            ViewBag.Title = "Dashboard";
            ViewBag.MainTitle = "Applicant Dashboard";
            ViewBag.Icon = "fa fa-user";
            ApplicantDashboardBO objApplicantDashboardBO = new ApplicantDashboardBO();
            return View(objApplicantDashboardBO);
        }
        [HttpPost]
        public JsonResult savePersonalInformation(ApplicantPersonalInformationBO Data)
        {
            if (Request.Files.Count > 0)
            {
                string strFileName = "";
                string strExtention = "";
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    strExtention = Path.GetExtension(file.FileName);
                    strFileName = ViewData["LoginUserId"].ToString() + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) + strExtention;
                    Data.FileSavedName1 = strFileName;
                    strFileName = Path.Combine(strFileUploadPath1, strFileName);
                    file.SaveAs(strFileName);
                }
            }
            if (Request.Files.Count > 0)
            {
                string strFileName1 = "";
                string strExtention1 = "";
                HttpFileCollectionBase files1 = Request.Files;
                for (int j = 0; j < files1.Count; j++)
                {
                    HttpPostedFileBase file = files1[j];
                    strExtention1 = Path.GetExtension(file.FileName);
                    strFileName1 = ViewData["LoginUserId"].ToString() + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) + strExtention1;

                    Data.FileSavedName = strFileName1;
                    strFileName1 = Path.Combine(strFileUploadPath, strFileName1);
                    file.SaveAs(strFileName1);
                }
            }
            ApplicantDashboardBAL objApplicantDashboardBAL = new ApplicantDashboardBAL();
            string strResult = objApplicantDashboardBAL.SavePersonalInformation(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult saveQualification(ApplicantQualificationBO Data)
        {
            if (Request.Files.Count > 0)
            {
                string strFileName2 = "";
                string strExtention2 = "";
                HttpFileCollectionBase files2 = Request.Files;
                for (int k = 0; k < files2.Count; k++)
                {
                    HttpPostedFileBase file = files2[k];
                    strExtention2 = Path.GetExtension(file.FileName);
                    strFileName2 = ViewData["LoginUserId"].ToString() + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) + strExtention2;

                    Data.FileSavedName2 = strFileName2;
                    strFileName2 = Path.Combine(strFileUploadPath2, strFileName2);
                    file.SaveAs(strFileName2);
                }
            }
            if (Request.Files.Count > 0)
            {
                string strFileName3 = "";
                string strExtention3 = "";
                HttpFileCollectionBase files3 = Request.Files;
                for (int l = 0; l < files3.Count; l++)
                {
                    HttpPostedFileBase file = files3[l];
                    strExtention3 = Path.GetExtension(file.FileName);
                    strFileName3 = ViewData["LoginUserId"].ToString() + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) + strExtention3;

                    Data.FileSavedName3 = strFileName3;
                    strFileName3 = Path.Combine(strFileUploadPath3, strFileName3);
                    file.SaveAs(strFileName3);
                }
            }
            if (Request.Files.Count > 0)
            {
                string strFileName4 = "";
                string strExtention4 = "";
                HttpFileCollectionBase files4 = Request.Files;
                for (int m = 0; m < files4.Count; m++)
                {
                    HttpPostedFileBase file = files4[m];
                    strExtention4 = Path.GetExtension(file.FileName);
                    strFileName4 = ViewData["LoginUserId"].ToString() + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) + strExtention4;

                    Data.FileSavedName4 = strFileName4;
                    strFileName4 = Path.Combine(strFileUploadPath4, strFileName4);
                    file.SaveAs(strFileName4);
                }
            }
            if (Request.Files.Count > 0)
            {
                string strFileName5 = "";
                string strExtention5 = "";
                HttpFileCollectionBase files5 = Request.Files;
                for (int n = 0; n < files5.Count; n++)
                {
                    HttpPostedFileBase file = files5[n];
                    strExtention5 = Path.GetExtension(file.FileName);
                    strFileName5 = ViewData["LoginUserId"].ToString() + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) + strExtention5;

                    Data.FileSavedName5 = strFileName5;
                    strFileName5 = Path.Combine(strFileUploadPath5, strFileName5);
                    file.SaveAs(strFileName5);
                }
            }
            ApplicantDashboardBAL objApplicantDashboardBAL = new ApplicantDashboardBAL();
            string strResult = objApplicantDashboardBAL.SaveApplicantQualification(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult saveEmploymentHistory(ApplicantEmploymentHistoryBO Data)
        {
            ApplicantDashboardBAL objApplicantDashboardBAL = new ApplicantDashboardBAL();
            string strResult = objApplicantDashboardBAL.SaveApplicantEmploymentHistory(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult saveMotivation(ApplicantMotivationBO Data)
        {
            ApplicantDashboardBAL objApplicantDashboardBAL = new ApplicantDashboardBAL();
            string strResult = objApplicantDashboardBAL.SaveApplicantMotivation(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EditPersonalInformation(int iApplicantId)
        {
            ApplicantDashboardBAL objApplicantDashboardBAL = new ApplicantDashboardBAL();
            ApplicantPersonalInformationBO objApplicantPersonalInformationBO = objApplicantDashboardBAL.editPersonalInformation(iApplicantId);
            return PartialView("_EditPersonalInformation",objApplicantPersonalInformationBO);
        }
        [HttpGet]
        public ActionResult EditQualification(int iApplicantId)
        {
            ApplicantDashboardBAL objApplicantDashboardBAL = new ApplicantDashboardBAL();
            ApplicantQualificationBO objApplicantQualificationBO = objApplicantDashboardBAL.editQualification(iApplicantId);
            return PartialView("_EditQualification",objApplicantQualificationBO);
        }
        [HttpGet]
        public ActionResult EditEmploymentHistory(int iApplicantId)
        {
            ApplicantDashboardBAL objApplicantDashboardBAL = new ApplicantDashboardBAL();
            ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO = objApplicantDashboardBAL.editEmploymentHistory(iApplicantId);
            return PartialView("_EditEmploymenyHistory",objApplicantEmploymentHistoryBO);
        }
        [HttpGet]
        public ActionResult EditMotivation(int iApplicantId)
        {
            ApplicantDashboardBAL objApplicantDashboardBAL = new ApplicantDashboardBAL();
            ApplicantMotivationBO objApplicantMotivationBO = objApplicantDashboardBAL.EditMotivation(iApplicantId);
            return PartialView("_EditMotivation", objApplicantMotivationBO);
        }
        [HttpGet]
        public ActionResult getPersonalInformation()
        {
            ApplicantDashboardBAL objApplicantDashboardBAL = new ApplicantDashboardBAL();
            ApplicantPersonalInformationBO objApplicantPersonalInformationBO = new ApplicantPersonalInformationBO();
            objApplicantPersonalInformationBO.TitleList = objApplicantDashboardBAL.TitleList();
            objApplicantPersonalInformationBO.CountriesList = objApplicantDashboardBAL.CountryList();
            objApplicantPersonalInformationBO.GenderList = objApplicantDashboardBAL.GenderList();
            return PartialView("_EditPersonalInformation",objApplicantPersonalInformationBO);
        }
        [HttpGet]
        public ActionResult getQualification()
        {
            ApplicantDashboardBAL objApplicantDashboardBAL = new ApplicantDashboardBAL();
            ApplicantQualificationBO objApplicantQualificationBO = new ApplicantQualificationBO();
            return PartialView("_EditQualification", objApplicantQualificationBO);
        }
        [HttpGet]
        public ActionResult getEmployment()
        {
            ApplicantDashboardBAL objApplicantDashboardBAL = new ApplicantDashboardBAL();
            ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO = new ApplicantEmploymentHistoryBO();
            return PartialView("_EditEmploymenyHistory", objApplicantEmploymentHistoryBO);
        }
        [HttpGet]
        public ActionResult getMotivation()
        {
            ApplicantDashboardBAL objApplicantDashboardBAL = new ApplicantDashboardBAL();
            ApplicantMotivationBO objApplicantMotivationBO = new ApplicantMotivationBO();
            return PartialView("_EditMotivation", objApplicantMotivationBO);
        }
    }
}