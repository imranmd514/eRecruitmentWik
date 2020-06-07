using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLayer;
using eRecruitment.CustomFilters;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class LocationMasterController : BaseController
    {
        // GET: LocationMaster
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Security";
            ViewBag.Title = "Location Master";
            ViewBag.Icon = "fa fa-user";
            LocationMasterBO objLocationMasterBO = new LocationMasterBO();
            return View();
        }
        [HttpGet]
        public ActionResult AddLocationMaster()
        {
            LocationMasterBO objLocationMasterBO = new LocationMasterBO();
            return PartialView("AddLocationMaster", objLocationMasterBO);
        }

        [HttpGet]
        public ActionResult GetLocationMasterList()
        {
            LocationMasterBAL objLocationMasterBAL = new LocationMasterBAL();
            List<LocationMasterBO> objLocationMasterBOList = objLocationMasterBAL.GetLocationMasterList();
            return PartialView("GetLocationMasterListDetails", objLocationMasterBOList);
        }


        [HttpPost]
        public JsonResult SaveorUpdateLocationMaster(LocationMasterBO Data)
        {
            LocationMasterBAL objLocationMasterBAL = new LocationMasterBAL();
            string strResult = objLocationMasterBAL.SaveorUpdateLocationMaster(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditLocationMaster(int A_iLocationId)
        {
            LocationMasterBAL objLocationMasterBAL = new LocationMasterBAL();
            LocationMasterBO objLocationMasterBO = objLocationMasterBAL.EditLocationMaster(A_iLocationId);
            return PartialView("AddLocationMaster", objLocationMasterBO);
        }


        [HttpPost]
        public JsonResult DeleteLocationMaster(int A_iLocationId)
        {
            LocationMasterBAL objLocationMasterBAL = new LocationMasterBAL();
            string strResult = objLocationMasterBAL.DeleteLocationMaster(A_iLocationId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
    }
}