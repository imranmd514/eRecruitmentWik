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
    public class SelectedListController : BaseController
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
            ViewBag.MainTitle = "Selected List";
            SelectedListBO objSelectedListBO = new SelectedListBO();
            SelectedListBAL objSelectedListBAL = new SelectedListBAL();
            objSelectedListBO.JobList = objSelectedListBAL.GetJobTypeList();
            return View(objSelectedListBO);
        }
        [HttpGet]
        public ActionResult getSelectedList(int A_iJobId)
        {
            SelectedListBAL objSelectedListBAL = new SelectedListBAL();
            List<SelectedListBO> objSelectedListBOList = objSelectedListBAL.getSelectedList(A_iJobId);
            return PartialView("GetSelectedApplicantList", objSelectedListBOList);
        }

        [HttpGet]
        public ActionResult ViewSelectedApplicant(int iApplicantId,int iJobPostingId)
        {
            SelectedListBAL objSelectedListBAL = new SelectedListBAL();
            SelectedListBO objSelectedListBO = objSelectedListBAL.ViewSelectedApplicant(iApplicantId, iJobPostingId);
            if (objSelectedListBO.PhotoSavedName != "" && objSelectedListBO.PhotoSavedName != null)
            {
                ViewBag.ImagePath = Url.Content(strDownLoadPhoto + objSelectedListBO.PhotoSavedName);
            }
            else
            {
                ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            }
            return PartialView("ViewSelectedApplicantList",objSelectedListBO);
        }

        //[HttpGet]
        //public ActionResult getSkillsInfoList(int A_iApplicantId, int A_iJobPostingId)
        //{
        //    SelectedListBAL objSelectedListBAL = new SelectedListBAL();
        //    List<SelectedListBO> objSelectedListBOList = objSelectedListBAL.getSkillsInfoList(A_iApplicantId, A_iJobPostingId);
        //    return PartialView("SkillsInfoListGrid", objSelectedListBOList);
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