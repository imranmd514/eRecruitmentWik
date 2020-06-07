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
    public class ApplicantsListController : BaseController
    {
        // GET: ApplicantsList
        public ActionResult Index()
        {
            ViewBag.MainTitle = "ApplicantsList";
            ViewBag.Title = "Applicants";
            ViewBag.Icon = "fa fa-user";
            ApplicantsListBO objApplicantsListBO = new ApplicantsListBO();
            ApplicantsListBAL objApplicantsListBAL = new ApplicantsListBAL();
            objApplicantsListBO.JobList = objApplicantsListBAL.GetJobTypeList();
            return View(objApplicantsListBO);
        }

        [HttpGet]
        public ActionResult GetApplicantsList(int A_iJobId)
        {
            ApplicantsListBAL objApplicantsListBAL = new ApplicantsListBAL();
            List<ApplicantsListBO> objApplicantsBOList = objApplicantsListBAL.getApplicantsList(A_iJobId);
            return PartialView("ApplicantsList", objApplicantsBOList);
        }
    }
}