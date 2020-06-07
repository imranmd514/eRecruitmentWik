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
    public class ShortListDetailsListController : BaseController
    {
        // GET: ShortListDetailsList
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Short List Details";
            ViewBag.Title = "Short List details";
            ViewBag.Icon = "fa fa-user";
            ShortListDetailsListBO objShortListDetailsListBO = new ShortListDetailsListBO();
            ShortListDetailsListBAL objShortListDetailsListBAL = new ShortListDetailsListBAL();
            objShortListDetailsListBO.JobList = objShortListDetailsListBAL.GetJobTypeList();
            return View(objShortListDetailsListBO);
        }

        [HttpGet]
        public ActionResult GetShortListDetailsList(int A_iJobId)
        {
            ShortListDetailsListBAL objShortListDetailsListBAL = new ShortListDetailsListBAL();
            List<ShortListDetailsListBO> objShortListDetailsListBOList = objShortListDetailsListBAL.getShortListDetailsList(A_iJobId);
            return PartialView("ShortListDetails", objShortListDetailsListBOList);
        }
    }
}