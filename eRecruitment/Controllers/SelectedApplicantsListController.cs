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
    public class SelectedApplicantsListController : BaseController
    {
        // GET: SelectedApplicantsList
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Selected Applicants List";
            ViewBag.Title = "Selected Applicants List";
            ViewBag.Icon = "fa fa-user";
            SelectedApplicantsListBO objSelectedApplicantsListBO = new SelectedApplicantsListBO();
            SelectedApplicantsListBAL objSelectedApplicantsListBAL = new SelectedApplicantsListBAL();
            objSelectedApplicantsListBO.JobList = objSelectedApplicantsListBAL.GetJobTypeList();
            return View(objSelectedApplicantsListBO);
        }

        [HttpGet]
        public ActionResult GetSelectedApplicantsDetailsList(int A_iJobId)
        {
            SelectedApplicantsListBAL objSelectedApplicantsListBAL = new SelectedApplicantsListBAL();
            List<SelectedApplicantsListBO> objSelectedApplicantsList = objSelectedApplicantsListBAL.getSelectedApplicantsList(A_iJobId);
            return PartialView("SelectedApplicantDetails", objSelectedApplicantsList);
        }
    }
}