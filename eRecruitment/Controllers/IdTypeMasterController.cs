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
    public class IdTypeMasterController : BaseController
    {
        // GET: IdTypeMaster
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Security";
            ViewBag.Title = "Id Type Master";
            ViewBag.Icon = "fa fa-user";
            IdTypeMasterBO objIdTypeMasterBO = new IdTypeMasterBO();
            return View();
        }

        [HttpGet]
        public ActionResult AddIdTypeMaster()
        {
            IdTypeMasterBO objIdTypeMasterBO = new IdTypeMasterBO();
            return PartialView("AddIdTypeMaster", objIdTypeMasterBO);
        }

        [HttpGet]
        public ActionResult GetIdTypeMasterList()
        {
            IdTypeMasterBAL objIdTypeMasterBAL = new IdTypeMasterBAL();
            List<IdTypeMasterBO> objIdTypeMasterBOList = objIdTypeMasterBAL.GetIdTypeMasterList();
            return PartialView("GetIdTypeMasterListDetails", objIdTypeMasterBOList);
        }


        [HttpPost]
        public JsonResult SaveorUpdateIdTypeMaster(IdTypeMasterBO Data)
        {
            IdTypeMasterBAL objIdTypeMasterBAL = new IdTypeMasterBAL();
            string strResult = objIdTypeMasterBAL.SaveorUpdateIdTypeMaster(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditIdTypeMaster(int A_iIdTypeMasterId)
        {
            IdTypeMasterBAL objIdTypeMasterBAL = new IdTypeMasterBAL();
            IdTypeMasterBO objIdTypeMasterBO = objIdTypeMasterBAL.EditIdTypeMaster(A_iIdTypeMasterId);
            return PartialView("AddIdTypeMaster", objIdTypeMasterBO);
        }


        [HttpPost]
        public JsonResult DeleteIdTypeMaster(int A_iIdTypeMasterId)
        {
            IdTypeMasterBAL objIdTypeMasterBAL = new IdTypeMasterBAL();
            string strResult = objIdTypeMasterBAL.DeleteIdTypeMaster(A_iIdTypeMasterId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
    }
}