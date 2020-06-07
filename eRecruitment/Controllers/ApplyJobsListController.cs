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
    public class ApplyJobsListController : BaseController
    {
        // GET: ApplyJobsList
        public ActionResult Index()
        {
            ViewBag.MainTitle = "ApplyJobsList";
            ViewBag.Title = "ApplyJobs";
            ViewBag.Icon = "fa fa-user";
            ApplyJobsListBO objApplicantsListBO = new ApplyJobsListBO();
            return View(objApplicantsListBO);
        }

        [HttpGet]
        public ActionResult GetApplyJobsList()
        {
            ApplyJobsListBAL objApplyJobsListBAL = new ApplyJobsListBAL();
            List<ApplyJobsListBO> objApplicantsBOList = objApplyJobsListBAL.getApplyJobsList();
            return PartialView("ApplyJobsList", objApplicantsBOList);
        }
    }
}