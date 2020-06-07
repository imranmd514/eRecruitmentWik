using BusinessLayer;
using Models;
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
    public class RejectedApplicantsController : BaseController
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
            ViewBag.MainTitle = "Rejected Applicants";
            ViewBag.Icon = "fa fa-user";
            RejectedApplicantsBO objRejectedApplicantsBO = new RejectedApplicantsBO();
            RejectedApplicantsBAL objRejectedApplicantsBAL = new RejectedApplicantsBAL();
            objRejectedApplicantsBO.JobList = objRejectedApplicantsBAL.GetJobTypeList();
            return View(objRejectedApplicantsBO);
        }
        [HttpGet]
        public ActionResult getRejectedApplicantsList(int A_iJobId)
        {
            RejectedApplicantsBAL objRejectedApplicantsBAL = new RejectedApplicantsBAL();
            List<RejectedApplicantsBO> objRejectedApplicantsBOList = objRejectedApplicantsBAL.getRejectedApplicantsList(A_iJobId);
            return PartialView("_RejectedApplicantsList", objRejectedApplicantsBOList);
        }

        [HttpGet]
        public ActionResult ViewRejectedApplicants(int iApplicantId,int iJobPostingId)
        {
            RejectedApplicantsBAL objRejectedApplicantsBAL = new RejectedApplicantsBAL();
            RejectedApplicantsBO objRejectedApplicantsBO = objRejectedApplicantsBAL.DisplayRejectedApplicant(iApplicantId, iJobPostingId);
            if (objRejectedApplicantsBO.PhotoSavedName != "" && objRejectedApplicantsBO.PhotoSavedName != null)
            {
                ViewBag.ImagePath = Url.Content(strDownLoadPhoto + objRejectedApplicantsBO.PhotoSavedName);
            }
            else
            {
                ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            }
            return PartialView("_ViewRejectedApplicant", objRejectedApplicantsBO);
        }

        //[HttpGet]
        //public ActionResult getSkillsInfoList(int A_iApplicantId, int A_iJobPostingId)
        //{
        //    RejectedApplicantsBAL objRejectedApplicantsBAL = new RejectedApplicantsBAL();
        //    List<RejectedApplicantsBO> objRejectedApplicantsBOList = objRejectedApplicantsBAL.getSkillsInfoList(A_iApplicantId, A_iJobPostingId);
        //    return PartialView("SkillsInfoListGrid", objRejectedApplicantsBOList);
        //}


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