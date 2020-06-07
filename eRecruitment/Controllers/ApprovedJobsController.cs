using Models;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLayer;
using System;
using System.Web;
using System.Configuration;
using System.Globalization;
using eRecruitment.CustomFilters;
using System.IO;


namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class ApprovedJobsController : BaseController
    {
        string strFileUploadPath = ConfigurationManager.AppSettings["JobDescription"].ToString();
        public ActionResult Index()
        {
            ViewBag.Title = "Jobs";
            ViewBag.MainTitle = "Approved Jobs";
            ViewBag.Icon = "fa fa-graduation";
            ApprovedJobsBO objApprovedJobsBO = new ApprovedJobsBO();
            return View(objApprovedJobsBO);
        }

        [HttpGet]
        public ActionResult getApprovedJobs()
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            List<PostJobBO> objApprovedJobsBOList = objApprovedJobsBAL.getApprovedJobsList(Convert.ToInt32(ViewData["LoginUserId"]), Convert.ToInt32(ViewData["LoginRoleId"]), 2);
            return PartialView("_ApprovedJobsList", objApprovedJobsBOList);
        }

        [HttpGet]
        public ActionResult ViewApprovedJobs(int iJobPostingId)
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            ApprovedJobsBO objApprovedJobsBO = objApprovedJobsBAL.DisplayApprovedJob(iJobPostingId);
            return PartialView("ViewApprovedJobList", objApprovedJobsBO);
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