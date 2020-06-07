using BusinessLayer;
using eRecruitment.CustomFilters;
using Models;
using System;
using System.Collections.Generic;
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
    public class ApprovedApplicantsController : BaseController
    {
        string strCVSavedUploadPath = ConfigurationManager.AppSettings["CV"].ToString();
        string strApplicationLetterUploadPath = ConfigurationManager.AppSettings["ApplicationLetter"].ToString();
        string strBachelorsUploadPath = ConfigurationManager.AppSettings["Bachelors"].ToString();
        string strDiplomaUploadPath = ConfigurationManager.AppSettings["Diploma"].ToString();
        string strMSCUploadPath = ConfigurationManager.AppSettings["MSC"].ToString();
        string strPHDUploadPath = ConfigurationManager.AppSettings["PHD"].ToString();
        string strPhotoUploadPath = ConfigurationManager.AppSettings["Photo"].ToString();
        string strCitizenShipIdCopyUploadPath = ConfigurationManager.AppSettings["CitizenShipIdCopy"].ToString();


        string strDownLoadPhoto = ConfigurationManager.AppSettings["ViewPhoto"].ToString();
        string strAcademicQualificationUploadPath = ConfigurationManager.AppSettings["AcademicQualification"].ToString();
        public ActionResult Index()
        {
            ViewBag.Title = "Applicants";
            ViewBag.MainTitle = "Approved Applicants";
            ViewBag.Icon = "fa fa-user";
            ApprovedApplicantsBO objApprovedApplicantsBO = new ApprovedApplicantsBO();
            ApprovedApplicantsBAL objApprovedApplicantsBAL = new ApprovedApplicantsBAL();
            objApprovedApplicantsBO.JobList = objApprovedApplicantsBAL.GetJobTypeList();
            return View(objApprovedApplicantsBO);
        }

        [HttpGet]
        public ActionResult getApprovedApplicantsList(int A_iJobId)
        {
            ApprovedApplicantsBAL objApprovedApplicantsBAL = new ApprovedApplicantsBAL();
            List<ApprovedApplicantsBO> objApprovedApplicantsBOList = objApprovedApplicantsBAL.getApprovedApplicants(A_iJobId);
            return PartialView("GetShortListedApplicantList", objApprovedApplicantsBOList);
        }

        [HttpGet]
        public ActionResult ViewApprovedApplicant(int A_iAppliedJobId, int A_iApplicantId)
        {
            ApprovedApplicantsBAL objApprovedApplicantsBAL = new ApprovedApplicantsBAL();
            ApprovedApplicantsBO objApprovedApplicantsBO = objApprovedApplicantsBAL.DisplayApprovedApplicant(A_iAppliedJobId,A_iApplicantId);
            if (objApprovedApplicantsBO.PhotoSavedName != "" && objApprovedApplicantsBO.PhotoSavedName != null)
            {
                ViewBag.ImagePath = Url.Content(strDownLoadPhoto + objApprovedApplicantsBO.PhotoSavedName);
            }
            else
            {
                ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            }
            return PartialView("ViewApprovedApplicants", objApprovedApplicantsBO);
        }

        [HttpGet]
        public ActionResult EditShortListApplicant(int A_iAppliedJobId, int A_iApplicantId)
        {
            ApprovedApplicantsBAL objApprovedApplicantsBAL = new ApprovedApplicantsBAL();
            ApprovedApplicantsBO objApprovedApplicantsBO = objApprovedApplicantsBAL.EditShortList(A_iAppliedJobId, A_iApplicantId);
            if (objApprovedApplicantsBO.PhotoSavedName != "" && objApprovedApplicantsBO.PhotoSavedName != null)
            {
                ViewBag.ImagePath = Url.Content(strDownLoadPhoto + objApprovedApplicantsBO.PhotoSavedName);
            }
            else
            {
                ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            }
            return View("EditShortListApplicant", objApprovedApplicantsBO);
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


        // Evaluation Form

        [HttpGet]
        public ActionResult CreateEvaluation(int A_iApplicantId, int A_iJobId)
        {
            ViewBag.MainTitle = "Applicants";
            ViewBag.Title = "Shortlisted Applicant";
            ViewBag.Icon = "fa fa-user";
            ApprovedApplicantsBAL objApprovedApplicantsBAL = new ApprovedApplicantsBAL();
            EvaluationFormBO objEvaluationFormBO = objApprovedApplicantsBAL.GetEvaluationApplicantDetails(A_iApplicantId, A_iJobId);
            objEvaluationFormBO.CommunicationSkillList = objApprovedApplicantsBAL.CommunicationSkillList();
            objEvaluationFormBO.ExperienceList = objApprovedApplicantsBAL.ExperienceList();
            objEvaluationFormBO.RatingList = objApprovedApplicantsBAL.RatingList();
            objEvaluationFormBO.getMonthsList = objApprovedApplicantsBAL.getMonthsList();
            objEvaluationFormBO.getYearList = objApprovedApplicantsBAL.getYearList();
            return PartialView("_EvaluationForm", objEvaluationFormBO);
        }

        [HttpPost]
        public JsonResult SaveSelectApplicant(EvaluationFormBO objEvaluationFormBO)
        {
            ApprovedApplicantsBAL objApprovedApplicantsBAL = new ApprovedApplicantsBAL();
            objEvaluationFormBO.IsActive = true;
            objEvaluationFormBO.Status = "Selected";
            string strResult = objApprovedApplicantsBAL.saveSelectedApplicant(objEvaluationFormBO, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveSkillInfo(EvaluationFormBO objEvaluationFormBO)
        {
            ApprovedApplicantsBAL objApprovedApplicantsBAL = new ApprovedApplicantsBAL();
            objEvaluationFormBO.IsActive = true;
            string strResult = objApprovedApplicantsBAL.saveSkillInfo(objEvaluationFormBO, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getSkillsInfoList(int A_iApplicantId, int A_iJobPostingId)
        {
            ApprovedApplicantsBAL objApprovedApplicantsBAL = new ApprovedApplicantsBAL();
            List<EvaluationFormBO> objEvaluationFormBOList = objApprovedApplicantsBAL.getSkillsInfoList(A_iApplicantId, A_iJobPostingId);
            return PartialView("SkillsInfoListGrid", objEvaluationFormBOList);
        }

        [HttpPost]
        public JsonResult DeleteSkillList(int A_iApplicantSkillId)
        {
            ApprovedApplicantsBAL objApprovedApplicantsBAL = new ApprovedApplicantsBAL();
            string strResult = objApprovedApplicantsBAL.DeleteSkillsList(A_iApplicantSkillId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveRejectedApplicant(EvaluationFormBO Data)
        {
            ApprovedApplicantsBAL objApprovedApplicantsBAL = new ApprovedApplicantsBAL();
            Data.IsActive = true;
            Data.Status = "Rejected";
            string strResult = objApprovedApplicantsBAL.saveRejectedApplicant(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }



        //[HttpGet]
        //public JsonResult getMonthList(int ApplicantExprienceId)
        //{
        //    ApprovedApplicantsBAL objApprovedApplicantsBAL = new ApprovedApplicantsBAL();
        //    List<CommonDropDownBO> objEvaluationFormBOList = objApprovedApplicantsBAL.getMonthsList(ApplicantExprienceId);
        //    return Json(objEvaluationFormBOList, JsonRequestBehavior.AllowGet);
        //}


        //[HttpGet]
        //public JsonResult getYearList(int ApplicantExprienceId)
        //{
        //    ApprovedApplicantsBAL objApprovedApplicantsBAL = new ApprovedApplicantsBAL();
        //    List<CommonDropDownBO> objEvaluationFormBOList = objApprovedApplicantsBAL.getYearList(ApplicantExprienceId);
        //    return Json(objEvaluationFormBOList, JsonRequestBehavior.AllowGet);
        //}
    }
}