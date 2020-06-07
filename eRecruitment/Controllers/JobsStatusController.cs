using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLayer;
using eRecruitment.CustomFilters;
using System.Configuration;
using System.IO;

namespace eRecruitment.Controllers
{

    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class JobsStatusController : BaseController
    {
        string strFileUploadPath = ConfigurationManager.AppSettings["JobDescription"].ToString();
        // GET: JobsStatus
        public ActionResult Index()
        {
            ViewBag.Title = "Jobs";
            ViewBag.MainTitle = "Job Status";
            ViewBag.Icon = "fa fa-graduation";
            ApprovedJobsBO objApprovedJobsBO = new ApprovedJobsBO();
            return View(objApprovedJobsBO);
        }

        [HttpGet]
        public ActionResult getApprovedJobs()
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            List<PostJobBO> objApprovedJobsBOList = objApprovedJobsBAL.getApprovedJobsList(Convert.ToInt32(ViewData["LoginUserId"]), Convert.ToInt32(ViewData["LoginRoleId"]), 0);
            return PartialView("JobStatusList", objApprovedJobsBOList);
        }

        [HttpGet]
        public ActionResult ViewApprovedJobs(int iJobPostingId)
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            ApprovedJobsBO objApprovedJobsBO = objApprovedJobsBAL.DisplayApprovedJob(iJobPostingId);
            return PartialView("ViewJobStatusList", objApprovedJobsBO);
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