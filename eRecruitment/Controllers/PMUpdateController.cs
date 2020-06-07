using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Models;
using BusinessLayer;
using eRecruitment.CustomFilters;
using System.IO;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class PMUpdateController : BaseController
    {
        string strFileUploadPath = ConfigurationManager.AppSettings["JobDescription"].ToString();
        // GET: PMUpdate
        public ActionResult Index()
        {
            ViewBag.MainTitle = "All Jobs";
            ViewBag.Title = "HR Office";
            ViewBag.Icon = "fa fa-graduation";
            AllJobsBO objAllJobsBO = new AllJobsBO();
            return View(objAllJobsBO);
        }


        [HttpGet]
        public ActionResult getAllJobsList()
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            List<PostJobBO> objJobsBOList = objApprovedJobsBAL.getApprovedJobsList(Convert.ToInt32(ViewData["LoginUserId"]), Convert.ToInt32(ViewData["LoginRoleId"]), 4);
            return PartialView("PMGrid", objJobsBOList);
        }

        [HttpGet]
        public ActionResult EditPMUpdateGrid(AllJobsBO Data, int iJobPostingId)
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            AllJobsBAL objAllJobsBAL = new AllJobsBAL();
            ApprovedJobsBO objJobsBO = objApprovedJobsBAL.DisplayApprovedJob(iJobPostingId);
            objJobsBO.DonorProgramList = objAllJobsBAL.DonorProgramList(Convert.ToInt32(ViewData["LoginUserId"]));
            return PartialView("EditPMGrid", objJobsBO);
        }

        [HttpPost]
        public JsonResult SavePMApprovedJob(AllJobsBO Data)
        {
            PMUpdateBAL objPMUpdateBAL = new PMUpdateBAL();
            Data.IsActive = true;
            string strResult = objPMUpdateBAL.SavePMApprovedJob(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ViewPMAllJob(int iJobPostingId)
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            ApprovedJobsBO objJobsBO = objApprovedJobsBAL.DisplayApprovedJob(iJobPostingId);
            return PartialView("ViewPMGrid", objJobsBO);
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