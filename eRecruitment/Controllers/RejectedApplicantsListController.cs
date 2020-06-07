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
    public class RejectedApplicantsListController : BaseController
    {
        // GET: RejectedApplicantsList
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Rejected Applicants List";
            ViewBag.Title = "Rejected Applicants";
            ViewBag.Icon = "fa fa-user";
            RejectedApplicantsListBO objRejectedApplicantsListBO = new RejectedApplicantsListBO();
            RejectedApplicantsListBAL objRejectedApplicantsListBAL = new RejectedApplicantsListBAL();
            objRejectedApplicantsListBO.JobList = objRejectedApplicantsListBAL.GetJobTypeList();
            return View(objRejectedApplicantsListBO);
        }

        [HttpGet]
        public ActionResult GetRejectedApplicantsList(int A_iJobId)
        {
            RejectedApplicantsListBAL objRejectedApplicantsListBAL = new RejectedApplicantsListBAL();
            List<RejectedApplicantsListBO> objRejectedApplicantsBOList = objRejectedApplicantsListBAL.getRejectedApplicantsList(A_iJobId);
            return PartialView("RejectedApplicantsList", objRejectedApplicantsBOList);
        }
    }
}