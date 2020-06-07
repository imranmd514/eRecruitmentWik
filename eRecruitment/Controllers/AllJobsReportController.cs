using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using Models;

namespace eRecruitment.Controllers
{
    public class AllJobsReportController : BaseController
    {
        // GET: AllJobsReport
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Jobs Report";
            ViewBag.Title = "All Jobs Report";
            ViewBag.Icon = "fa fa-user";
            JobsReportBO objJobsReportBO = new JobsReportBO();
            return View(objJobsReportBO);
        }

        [HttpGet]
        public ActionResult GetAllJobsReportList()
        {
            AllJobsReportListBAL objAllJobsReportListBAL = new AllJobsReportListBAL();
            List<JobsReportBO> objAllJobsReportList = objAllJobsReportListBAL.getAllJobsReportList();
            return PartialView("AllJobsReportList", objAllJobsReportList);
        }
    }
}