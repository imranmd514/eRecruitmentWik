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
    public class OrganizationMasterController : BaseController
    {
        // GET: BranchMaster
        public ActionResult Index()
        {
            ViewBag.MainTitle = "OrganizationMaster";
            ViewBag.Title = "Security";
            ViewBag.Icon = "fa fa-user";
            OrganizationMasterBO objOrganizationMasterBO = new OrganizationMasterBO();
            return View(objOrganizationMasterBO);
        }
        [HttpGet]
        public ActionResult AddOrganization()
        {
            OrganizationMasterBO objOrganizationMasterBO = new OrganizationMasterBO();
            return PartialView("AddOrganization", objOrganizationMasterBO);
        }

        [HttpPost]
        public JsonResult SaveOrganization(OrganizationMasterBO Data)
        {
            OrganizationMasterBAL objOrganizationMasterBAL = new OrganizationMasterBAL();
            Data.IsActive = true;
            string strResult = objOrganizationMasterBAL.SaveorUpdateOrganizationMaster(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult selectOrganizationList()
        {
            OrganizationMasterBAL objOrganizationMasterBAL = new OrganizationMasterBAL();
            List<OrganizationMasterBO> objOrganizationMasterBOList = objOrganizationMasterBAL.selectOrganisationList();
            return PartialView("GetOrganizationList", objOrganizationMasterBOList);
        }

        [HttpGet]
        public ActionResult EditOrganization(int iOrganisationId)
        {
            OrganizationMasterBAL objOrganizationMasterBAL = new OrganizationMasterBAL();
            OrganizationMasterBO objOrganizationMasterBO = objOrganizationMasterBAL.EditOrganization(iOrganisationId);           
            return PartialView("AddOrganization", objOrganizationMasterBO);
        }



        [HttpPost]
        public JsonResult deleteOrganization(int iOrganisationId)
        {
            OrganizationMasterBAL objOrganizationMasterBAL = new OrganizationMasterBAL();
            string strResult = objOrganizationMasterBAL.deleteOrganisation(iOrganisationId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
    }
}