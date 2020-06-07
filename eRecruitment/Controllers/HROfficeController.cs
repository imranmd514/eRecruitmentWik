using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using Models;
using eRecruitment.CustomFilters;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class HROfficeController : BaseController
    {
        // GET: HROffice
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
            HROfficeBAL objHROfficeBAL = new HROfficeBAL();
            List<AllJobsBO> objAllJobsBOList = objHROfficeBAL.getHROfficeGridList();
            return PartialView("HROfficeGrid", objAllJobsBOList);
        }


        [HttpGet]
        public ActionResult EditHROfficeGrid(AllJobsBO Data, int iJobPostingId)
        {
            HROfficeBAL objHROfficeBAL = new HROfficeBAL();
            AllJobsBO objAllJobsBO = objHROfficeBAL.EditHROfficeGrid(iJobPostingId);
            objAllJobsBO.DonorProgrammList = objHROfficeBAL.GetDropDownDonorProgramList(Convert.ToInt32(ViewData["LoginUserId"]));
            return PartialView("EditGrid", objAllJobsBO);
        }


        [HttpPost]
        public JsonResult SaveHRApprovedJob(AllJobsBO Data)
        {
            HROfficeBAL objHROfficeBAL = new HROfficeBAL();
            Data.HRStatus = 1;
            Data.IsActive = true;
            string strResult = objHROfficeBAL.SaveHRApprovedJob(Data, Convert.ToInt32(ViewData["LoginUserId"]),1);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveHRRejectedJob(AllJobsBO Data)
        {
            HROfficeBAL objHROfficeBAL = new HROfficeBAL();
            Data.StatusId = 3;
            Data.HRStatus = 2;
            Data.IsActive = true;
            string strResult = objHROfficeBAL.SaveHRRejectedJob(Data, 1);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ViewHRAllJob(int iJobPostingId)
        {
            HROfficeBAL objHROfficeBAL = new HROfficeBAL();
            AllJobsBO objAllJobsBO = objHROfficeBAL.DisplayHRAllJob(iJobPostingId);
            return PartialView("ViewHRJobs", objAllJobsBO);
        }

    }
}