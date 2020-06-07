using BusinessLayer;
using Models;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using System.IO;
using System.Globalization;
using System;
using eRecruitment.CustomFilters;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class BranchMasterController : BaseController
    {
        // GET: BranchMaster
        public ActionResult Index()
        {
            ViewBag.MainTitle = "BranchMaster";
            ViewBag.Title = "Users";
            ViewBag.Icon = "fa fa-user";
            BranchMasterBO objBranchMasterBO = new BranchMasterBO();
            return View(objBranchMasterBO);
        }


        [HttpGet]
        public ActionResult CreateBranch()
        {
            ViewBag.MainTitle = "BranchMaster";
            ViewBag.Title = "Users";
            ViewBag.Icon = "fa fa-user";
            BranchMasterBO objBranchMasterBO = new BranchMasterBO();
            BranchMasterBAL objBranchMasterBAL = new BranchMasterBAL();
            objBranchMasterBO.getOrganizationList = objBranchMasterBAL.dropdownOrganization();
            return PartialView("AddBranch", objBranchMasterBO);
        }


        [HttpPost]
        public JsonResult SaveBranchMaster(BranchMasterBO Data)
        {
            BranchMasterBAL objBranchMasterBAL = new BranchMasterBAL();
            Data.IsActive = true;
            string strResult = objBranchMasterBAL.SaveorUpdateBranchMaster(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetBranchList()
        {
            BranchMasterBAL objBranchMasterBAL = new BranchMasterBAL();
            List<BranchMasterBO> objBranchMasterBOList = objBranchMasterBAL.selectBranchList();
            return PartialView("GetBranchList", objBranchMasterBOList);
        }

        [HttpGet]
        public ActionResult EditBranch(int iBranchId)
        {
            BranchMasterBAL objBranchMasterBAL = new BranchMasterBAL();
            BranchMasterBO objBranchMasterBO = objBranchMasterBAL.EditBranch(iBranchId);
            objBranchMasterBO.getOrganizationList = objBranchMasterBAL.dropdownOrganization();
            return PartialView("AddBranch", objBranchMasterBO);
        }

        [HttpGet]
        public ActionResult ViewBranchMaster(int iBranchId)
        {
            BranchMasterBAL objBranchMasterBAL = new BranchMasterBAL();
            BranchMasterBO objBranchMasterBO = objBranchMasterBAL.ViewBranchMaster(iBranchId);
            return PartialView("ViewBranchMaster", objBranchMasterBO);
        }



        [HttpPost]
        public JsonResult deleteBranch(int iBranchId)
        {
            BranchMasterBAL objBranchMasterBAL = new BranchMasterBAL();
            string strResult = objBranchMasterBAL.deleteBranch(iBranchId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
    }
}