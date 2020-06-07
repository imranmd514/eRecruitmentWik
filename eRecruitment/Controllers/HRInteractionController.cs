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
    public class HRInteractionController : BaseController
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Applicants";
            ViewBag.MainTitle = "HR Interaction";
            ViewBag.Icon = "fa fa-user";
            HRInteractionBO objHRInteractionBO = new HRInteractionBO();
            return View(objHRInteractionBO);
        }
        [HttpGet]
        public ActionResult CreateHRInteraction()
        {
            ViewBag.Title = "Applicants";
            ViewBag.MainTitle = "HR Interaction";
            ViewBag.Icon = "fa fa-user";
            HRInteractionBAL objHRInteractionBAL = new HRInteractionBAL();
            HRInteractionBO objHRInteractionBO = new HRInteractionBO();
            return View("AddHRInteraction", objHRInteractionBO);
        }

        [HttpGet]
        public ActionResult getInteractionList()
        {
            HRInteractionBAL objHRInteractionBAL = new HRInteractionBAL();
            List<HRInteractionBO> objHRInteractionBOList = objHRInteractionBAL.getHRInteractionList();
            return PartialView("_HRInteractionList", objHRInteractionBOList);
        }

        [HttpPost]
        public JsonResult saveHRInteraction(HRInteractionBO Data)
        {
            HRInteractionBAL objHRInteractionBAL = new HRInteractionBAL();
            Data.StatusId = 1;
            Data.IsActive = true;
            string strResult = objHRInteractionBAL.SaveHRInteraction(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveHRReply(HRInteractionBO Data)
        {
            HRInteractionBAL objHRInteractionBAL = new HRInteractionBAL();
            Data.IsActive = true;
            Data.StatusId = 2;
            string strResult = objHRInteractionBAL.SaveHRReply(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditHRInteraction(int iRequestId)
        {
            HRInteractionBAL objHRInteractionBAL = new HRInteractionBAL();
            HRInteractionBO objHRInteractionBO = objHRInteractionBAL.EditHRInteraction(iRequestId);
            return View("EditHRInteraction",objHRInteractionBO);
        }

        [HttpGet]
        public ActionResult ViewHRInteractionList(int iRequestId)
        {
            HRInteractionBAL objHRInteractionBAL = new HRInteractionBAL();
            HRInteractionBO objHRInteractionBO = objHRInteractionBAL.DisplayHRDetails(iRequestId);
            return PartialView("ViewHRInteraction", objHRInteractionBO);
        }

        [HttpPost]
        public JsonResult deleteHRInteraction(int iRequestId)
        {
            HRInteractionBAL objHRInteractionBAL = new HRInteractionBAL();
            string strResult = objHRInteractionBAL.deleteHRInteraction(iRequestId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

    }
}