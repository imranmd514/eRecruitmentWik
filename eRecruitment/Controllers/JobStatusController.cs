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
    public class JobStatusController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Apply Jobs";
            ViewBag.Title = "Jobs";
            JobStatusBO objJobStatusBo = new JobStatusBO();
            return View(objJobStatusBo);
        }

        //[HttpGet]
        //public ActionResult GetJobStatusList()
        //{
        //    JobStatusBAL objJobStatusBAL = new JobStatusBAL();
        //    List<JobStatusBO> objListJobStatusBo = objJobStatusBAL.getAppliedJobsList();
        //    return PartialView("_JobStatusList", objListJobStatusBo);
        //}


        [HttpGet]
        public ActionResult GetAllApplicantsJobList()
        {
            JobStatusBAL objJobStatusBAL = new JobStatusBAL();
            List<JobStatusBO> objListJobStatusBo = objJobStatusBAL.GetAllApplicantsJobList(Convert.ToInt32(ViewData["LoginUserId"]));
            return PartialView("_ApplicantJobStatusList", objListJobStatusBo);
        }
    }
}