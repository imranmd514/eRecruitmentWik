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
    public class RejectedJobsController : BaseController
    {
        string strFileUploadPath = ConfigurationManager.AppSettings["JobDescription"].ToString();
        public ActionResult Index()
        {
            ViewBag.Title = "Jobs";
            ViewBag.MainTitle = "Rejected Jobs";
            ViewBag.Icon = "fa fa-graduation";
            RejectedJobsBO objRejectedJobsBO = new RejectedJobsBO();
            return View(objRejectedJobsBO);
        }

        [HttpGet]
        public ActionResult getRejectedJobsList()
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            List<PostJobBO> objJobsBOList = objApprovedJobsBAL.getApprovedJobsList(Convert.ToInt32(ViewData["LoginUserId"]), Convert.ToInt32(ViewData["LoginRoleId"]), 3);
            return PartialView("_RejectedJobsList", objJobsBOList);
        }


        [HttpGet]
        public ActionResult ViewRejectedJobs(int iJobPostingId)
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            ApprovedJobsBO objJobsBO = objApprovedJobsBAL.DisplayApprovedJob(iJobPostingId);
            return PartialView("ViewRejectedJobsList", objJobsBO);
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