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
    public class JobMarketingListController : BaseController
    {
        // GET: JobMarketingList
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Job Marketing List";
            ViewBag.Title = "Job Marketing";
            ViewBag.Icon = "fa fa-user";
            JobMarketingListBO objJobMarketingListBO = new JobMarketingListBO();
            return View(objJobMarketingListBO);
        }

        [HttpGet]
        public ActionResult GetJobMarketingList()
        {
            JobMarketingListBAL objJobMarketingListBAL = new JobMarketingListBAL();
            List<JobMarketingListBO> objJobMarketingBOList = objJobMarketingListBAL.getJobMarketingList();
            return PartialView("JobMarketingList", objJobMarketingBOList);
        }
    }
}