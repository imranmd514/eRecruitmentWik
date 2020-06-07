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
    public class RejectedJobsListController : BaseController
    {
        // GET: RejectedJobsList
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Rejected Jobs List";
            ViewBag.Title = "Rejected Jobs";
            ViewBag.Icon = "fa fa-user";
            RejectedJobsListBO objRejectedJobsListBO = new RejectedJobsListBO();
            return View(objRejectedJobsListBO);
        }

        [HttpGet]
        public ActionResult GetRejectedJobsList()
        {
            RejectedJobsListBAL objRejectedJobsListBAL = new RejectedJobsListBAL();
            List<RejectedJobsListBO> objRejectedJobsBOList = objRejectedJobsListBAL.getRejectedJobsList();
            return PartialView("RejectedJobsList", objRejectedJobsBOList);
        }
    }
}