using BusinessLayer;
using eRecruitment.CustomFilters;
using Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using System.IO;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class ApplyJobsController : BaseController
    {
        string strFileUploadPath = ConfigurationManager.AppSettings["JobDescription"].ToString();
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Apply Jobs";
            ViewBag.Title = "Jobs";
            ApplyJobsBO objApplyJobsBO = new ApplyJobsBO();
            return View(objApplyJobsBO);
        }
        [HttpGet]
        public JsonResult CheckApplicantExist()
        {
            ApplyJobsBAL objApplyJobsBAL = new ApplyJobsBAL();
            string strResult = "";
            if (Convert.ToInt32(ViewData["LoginRoleId"]) == 70)
            {
                strResult = objApplyJobsBAL.CheckApplicantExist(Convert.ToInt32(ViewData["EmployeeId"]));
            }
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getAppliedJobsList()
        {
            ApplyJobsBAL objApplyJobsBAL = new ApplyJobsBAL();
            List<ApplyJobsBO> objApplyJobsBOList = objApplyJobsBAL.getAppliedJobsList(Convert.ToInt32(ViewData["EmployeeId"]));
            return PartialView("AppliedJobsList", objApplyJobsBOList);
        }

        [HttpGet]
        public ActionResult ViewApplyJob(int iJobPostingId)
        {
            ApplyJobsBAL objApplyJobsBAL = new ApplyJobsBAL();            
            ApplyJobsBO objApplyJobsBO = objApplyJobsBAL.DisplayApplyJob(iJobPostingId, Convert.ToInt32(ViewData["EmployeeId"]));
            return PartialView("_ViewApplyJob", objApplyJobsBO);
        }

        //[HttpPost]
        //public JsonResult SaveAppliedJobs(int A_iJobPostingId)
        //{
        //    ApplyJobsBAL objApplyJobsBAL = new ApplyJobsBAL();
        //    string strResult = objApplyJobsBAL.SaveApplyJob(A_iJobPostingId, Convert.ToInt32(ViewData["LoginUserId"]));
        //    return Json(strResult, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult SaveApplyJob(ApplyJobsBO Data)
        {
            ApplyJobsBAL objApplyJobsBAL = new ApplyJobsBAL();
            string strResult = objApplyJobsBAL.SaveApplyJob(Data, Convert.ToInt32(ViewData["EmployeeId"]), Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DownloadAttachment(string FileSavedName, string fileActualName)
        {
            string strFilePath = Path.Combine(strFileUploadPath, FileSavedName);
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