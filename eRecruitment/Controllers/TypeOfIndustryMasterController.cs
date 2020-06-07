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
    public class TypeOfIndustryMasterController : BaseController
    {
        // GET: TypeOfIndustryMaster
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Security";
            ViewBag.Title = "Type Of Industry Master";
            ViewBag.Icon = "fa fa-user";
            TypeOfIndustryMasterBO objTypeOfIndustryMasterBO = new TypeOfIndustryMasterBO();
            return View();
        }


        [HttpGet]
        public ActionResult AddTypeOfIndustryMaster()
        {
            TypeOfIndustryMasterBO objTypeOfIndustryMasterBO = new TypeOfIndustryMasterBO();
            return PartialView("AddTypeOfIndustry", objTypeOfIndustryMasterBO);
        }


        [HttpGet]
        public ActionResult GetTypeOfIndustryMasterList()
        {
            TypeOfIndustryMasterBAL objTypeOfIndustryMasterBAL = new TypeOfIndustryMasterBAL();
            List<TypeOfIndustryMasterBO> objTypeOfIndustryMasterList = objTypeOfIndustryMasterBAL.GetTypeOfIndustryList();
            return PartialView("GetTypeOfIndustryListDetails", objTypeOfIndustryMasterList);
        }


        [HttpPost]
        public JsonResult SaveorUpdateTypeOfIndustryMaster(TypeOfIndustryMasterBO Data)
        {
            TypeOfIndustryMasterBAL objTypeOfIndustryMasterBAL = new TypeOfIndustryMasterBAL();
            string strResult = objTypeOfIndustryMasterBAL.SaveorUpdateTypeOfIndustry(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult EditTypeOfIndustryMaster(int A_iTypeOfIndustryId)
        {
            TypeOfIndustryMasterBAL objTypeOfIndustryMasterBAL = new TypeOfIndustryMasterBAL();
            TypeOfIndustryMasterBO objTypeOfIndustryMasterBO = objTypeOfIndustryMasterBAL.EditTypeOfIndustryMaster(A_iTypeOfIndustryId);
            return PartialView("AddTypeOfIndustry", objTypeOfIndustryMasterBO);
        }

        [HttpPost]
        public JsonResult DeleteTypeOfIndustry(int A_iTypeOfIndustryId)
        {
            TypeOfIndustryMasterBAL objTypeOfIndustryMasterBAL = new TypeOfIndustryMasterBAL();
            string strResult = objTypeOfIndustryMasterBAL.DeleteTypeOfIndustry(A_iTypeOfIndustryId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
    }
}