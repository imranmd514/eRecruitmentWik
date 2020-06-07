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
using eRecruitment.CustomFilters;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class AllApplicantsController : BaseController
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
            ViewBag.MainTitle = "All Applicants";
            ViewBag.Icon = "fa fa-user";
            AllApplicantsBO objAllApplicantsBO = new AllApplicantsBO();
            return View(objAllApplicantsBO);
        }

        [HttpGet]
        public ActionResult getAllApplicantsList()
        {
            AllApplicantsBAL objAllApplicantsBAL = new AllApplicantsBAL();
            List<AllApplicantsBO> objAllApplicantsBOList = objAllApplicantsBAL.getAllApplicantsList();
            return PartialView("_AllApplicantsList", objAllApplicantsBOList);
        }

        [HttpPost]
        public JsonResult saveApprovedApplicant(AllApplicantsBO Data)
        {
            AllApplicantsBAL objAllApplicantsBAL = new AllApplicantsBAL();
            Data.StatusId = 2;
            string strResult = objAllApplicantsBAL.saveApprovedApplicant(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult saveRejectedApplicant(AllApplicantsBO Data)
        {
            AllApplicantsBAL objAllApplicantsBAL = new AllApplicantsBAL();
            Data.StatusId = 3;
            string strResult = objAllApplicantsBAL.saveRejectedApplicant(Data, 1);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult saveonHoldApplicant(AllApplicantsBO Data)
        {
            AllApplicantsBAL objAllApplicantsBAL = new AllApplicantsBAL();
            Data.StatusId = 4;
            string strResult = objAllApplicantsBAL.saveOnHoldApplicant(Data, 1);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult EditAllApplicants(int iApplicantId)
        {
            AllApplicantsBAL objAllApplicantsBAL = new AllApplicantsBAL();
            AllApplicantsBO objAllApplicantsBO = objAllApplicantsBAL.EditAllApplicants(iApplicantId);
            return View("EditAllApplicant", objAllApplicantsBO);
        }


        [HttpGet]
        public ActionResult ViewApplicant(int iApplicantId)
        {
            AllApplicantsBAL objAllApplicantsBAL = new AllApplicantsBAL();
            AllApplicantsBO objAllApplicantsBO = objAllApplicantsBAL.ViewAllApplicant(iApplicantId);
            if (objAllApplicantsBO.PhotoSavedName != "" && objAllApplicantsBO.PhotoSavedName != null)
            {
                ViewBag.ImagePath = Url.Content(strDownLoadPhoto + objAllApplicantsBO.PhotoSavedName);
            }
            else
            {
                ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            }
            return PartialView("ViewAllApplicantList", objAllApplicantsBO);
        }


        [HttpPost]
        public JsonResult DeleteAllApplicants(int iApplicantId)
        {
            AllApplicantsBAL objAllApplicantsBAL = new AllApplicantsBAL();
            string strResult = objAllApplicantsBAL.deleteAllApplicants(iApplicantId);
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





