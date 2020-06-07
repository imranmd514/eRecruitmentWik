using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLayer;

namespace eRecruitment.Controllers
{
    public class RejectedJobsReportController : BaseController
    {
        // GET: RejectedJobsReport
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Jobs Report";
            ViewBag.Title = "Rejected Jobs Report";
            ViewBag.Icon = "fa fa-user";
            JobsReportBO objJobsReportBO = new JobsReportBO();
            return View(objJobsReportBO);
        }
        [HttpGet]
        public ActionResult GetRejectedJobsReportList()
        {
            RejectedJobsReportListBAL objRejectedJobsReportListBAL = new RejectedJobsReportListBAL();
            List<JobsReportBO> objRejectedJobsReportList = objRejectedJobsReportListBAL.getRejectedJobsReportList();
            return PartialView("RejectedJobsReportList", objRejectedJobsReportList);
        }
    }
}