using BusinessLayer;
using eRecruitment.CustomFilters;
using Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class JobsListController : BaseController
    {

        public ActionResult Index()
        {
            ViewBag.MainTitle = "Jobs List";
            ViewBag.Title = "Jobs List";
            ViewBag.Icon = "fa fa-user";
            JobsListBO objJobsListBO = new JobsListBO();
            return View(objJobsListBO);
        }

        [HttpGet]
        public ActionResult GetJobsList()
        {
            JobsListBAL objJobsListBAL = new JobsListBAL();
            List<JobsListBO> objJobsBOList = objJobsListBAL.getJobsList();
            return PartialView("JobsList", objJobsBOList);
        }
    }
}