using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using eRecruitment.CustomFilters;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class OnHoldJobsController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Jobs";
            ViewBag.MainTitle = "Approved Jobs";
            ViewBag.Icon = "fa fa-graduation";
            ApprovedJobsBO objApprovedJobsBO = new ApprovedJobsBO();
            return View(objApprovedJobsBO);
        }

       
    }
}