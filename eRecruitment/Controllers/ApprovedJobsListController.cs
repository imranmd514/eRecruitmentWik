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
    public class ApprovedJobsListController : BaseController
    {
        // GET: ApprovedJobsList
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Approved Jobs list";
            ViewBag.Title = "Approved Jobs";
            ViewBag.Icon = "fa fa-user";
            ApprovedJobsListBO objApprovedJobsListBO = new ApprovedJobsListBO();
            return View(objApprovedJobsListBO);
        }

        [HttpGet]
        public ActionResult GetApprovedJobsList()
        {
            ApprovedJobsListBAL objApprovedJobsListBAL = new ApprovedJobsListBAL();
            List<ApprovedJobsListBO> objApprovedJobsBOList = objApprovedJobsListBAL.getApprovedJobsList();
            return PartialView("ApprovedJobsList", objApprovedJobsBOList);
        }
    }
}