using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLayer;
using eRecruitment.CustomFilters;
using System.IO;
using System.Configuration;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class HOPUpdateController : BaseController
    {
        string strFileUploadPath = ConfigurationManager.AppSettings["JobDescription"].ToString();
        // GET: HOPUpdate
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
            List<PostJobBO> objJobsBOList  = objApprovedJobsBAL.getApprovedJobsList(Convert.ToInt32(ViewData["LoginUserId"]), Convert.ToInt32(ViewData["LoginRoleId"]), 4);            
            return PartialView("HOPUpdateGrid", objJobsBOList);
        }

        [HttpGet]
        public ActionResult EditHOPUpdateGrid(AllJobsBO Data, int iJobPostingId)
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            AllJobsBAL objAllJobsBAL = new AllJobsBAL();
            ApprovedJobsBO objJobsBO = objApprovedJobsBAL.DisplayApprovedJob(iJobPostingId);
            objJobsBO.DonorProgramList = objAllJobsBAL.DonorProgramList(Convert.ToInt32(ViewData["LoginUserId"]));
            return PartialView("EditHOPGrid", objJobsBO);
        }

        [HttpPost]
        public JsonResult SaveHOPApprovedJob(AllJobsBO Data)
        {
            HOPUpdateBAL objHOPUpdateBAL = new HOPUpdateBAL();
            Data.IsActive = true;
            string strResult = objHOPUpdateBAL.SaveHOPApprovedJob(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewHOPAllJob(int iJobPostingId)
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            ApprovedJobsBO objJobsBO = objApprovedJobsBAL.DisplayApprovedJob(iJobPostingId);
            return PartialView("ViewHOPGrid", objJobsBO);
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