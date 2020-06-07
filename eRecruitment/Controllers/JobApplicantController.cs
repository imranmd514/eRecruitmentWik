using BusinessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using System.IO;
using System.Globalization;
using eRecruitment.CustomFilters;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class JobApplicantController : BaseController
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
            ViewBag.MainTitle = "Job Wise Applicant";
            JobApplicantModelBO objJobApplicantModelBo = new JobApplicantModelBO();
            JobApplicantBAL obJobApplicantBAL = new JobApplicantBAL();
            objJobApplicantModelBo.JobList = obJobApplicantBAL.GetJobTypeList();
            return View(objJobApplicantModelBo);
        }

        [HttpGet]
        public ActionResult GetJobApplicantList(int A_iJobId)
        {
            JobApplicantBAL obJobApplicantBAL = new JobApplicantBAL();
            List<JobApplicantModelBO> objListJobApplicantModelBo = obJobApplicantBAL.GetJobApplicantList(A_iJobId);
            return PartialView("_JobApplicant", objListJobApplicantModelBo);
        }

        [HttpGet]
        public ActionResult ViewJobApplicants(int A_iApplicantJobId)
        {
            JobApplicantBAL obJobApplicantBAL = new JobApplicantBAL();
            JobApplicantModelBO objJobApplicantModelBo = obJobApplicantBAL.ViewAllApplicants(A_iApplicantJobId);
            if (objJobApplicantModelBo.PhotoSavedName != "" && objJobApplicantModelBo.PhotoSavedName != null)
            {
                ViewBag.ImagePath = Url.Content(strDownLoadPhoto + objJobApplicantModelBo.PhotoSavedName);
            }
            else
            {
                ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            }
            return PartialView("_JobWiseApplicantList", objJobApplicantModelBo);
        }

        [HttpPost]

        public JsonResult UpdateJobWiseApplicant(JobApplicantModelBO Data)
        {
            JobApplicantBAL obJobApplicantBAL = new JobApplicantBAL();
            string strResult = obJobApplicantBAL.UpdateJobWiseApplicant(Data,Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]

        public JsonResult RejectJobWiseApplicant(JobApplicantModelBO Data)
        {
            JobApplicantBAL obJobApplicantBAL = new JobApplicantBAL();
            string strResult = obJobApplicantBAL.RejectJobWiseApplicant(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);

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
    }
}