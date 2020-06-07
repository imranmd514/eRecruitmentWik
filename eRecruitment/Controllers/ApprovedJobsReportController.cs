using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLayer;

namespace eRecruitment.Controllers
{
    public class ApprovedJobsReportController : BaseController
    {
        // GET: ApprovedJobsReport
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Jobs Report";
            ViewBag.Title = "Approved Jobs Report";
            ViewBag.Icon = "fa fa-user";
            JobsReportBO objJobsReportBO = new JobsReportBO();
            return View(objJobsReportBO);
        }


        [HttpGet]
        public ActionResult GetApprovedJobsReportList()
        {
            ApprovedJobsReportListBAL objApprovedJobsReportListBAL = new ApprovedJobsReportListBAL();
            List<JobsReportBO> objApprovedJobsReportList = objApprovedJobsReportListBAL.getApprovedJobsReportList();
            return PartialView("ApprovedJobsReportList", objApprovedJobsReportList);
        }
    }
}