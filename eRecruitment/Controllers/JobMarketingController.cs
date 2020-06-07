using Models;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLayer;
using System;
using eRecruitment.CustomFilters;
using System.Configuration;
using System.IO;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class JobMarketingController : BaseController
    {
        string strFileUploadPath = ConfigurationManager.AppSettings["JobDescription"].ToString();
        public ActionResult Index()
        {
            ViewBag.Title = "Job";
            ViewBag.MainTitle = "Job Marketing";
            ViewBag.Icon = "fa fa-graduation";
            JobMarketingBO objJobMarketingBO = new JobMarketingBO();
            return View(objJobMarketingBO);
        }

        [HttpGet]
        public ActionResult getJobMarketing(JobMarketingBO Data)
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            List<PostJobBO> objJobsBOList = objApprovedJobsBAL.getApprovedJobsList(Convert.ToInt32(ViewData["LoginUserId"]), Convert.ToInt32(ViewData["LoginRoleId"]), 2);
            return PartialView("GetJobMarketingList", objJobsBOList);
        }

        [HttpPost]
        public JsonResult SaveJobMarketing(JobMarketingBO Data)
        {
            JobMarketingBAL objJobMarketingBAL = new JobMarketingBAL();            
            Data.MarketingStatus = "2";
            Data.IsActive = true;
            string strResult = objJobMarketingBAL.SaveJobMarketing(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EditJobMarketing(JobMarketingBO Data, int iJobPostingId)
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            AllJobsBAL objAllJobsBAL = new AllJobsBAL();
            ApprovedJobsBO objJobsBO = objApprovedJobsBAL.DisplayApprovedJob(iJobPostingId);
            objJobsBO.DonorProgramList = objAllJobsBAL.DonorProgramList(Convert.ToInt32(ViewData["LoginUserId"]));
            return PartialView("EditJobMarketing", objJobsBO);
        }
        [HttpGet]
        public ActionResult ViewJobMarketing(int iJobPostingId)
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            ApprovedJobsBO objJobsBO = objApprovedJobsBAL.DisplayApprovedJob(iJobPostingId);
            return PartialView("ViewJobMarketingList", objJobsBO);
        }

        [HttpPost]
        public JsonResult deleteJobMarketing(int iJobPostingId)
        {
            JobMarketingBAL objJobMarketingBAL = new JobMarketingBAL();
            string strResult = objJobMarketingBAL.deleteJobMarketing(iJobPostingId);
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
