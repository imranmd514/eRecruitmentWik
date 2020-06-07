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
    public class AddRequisitionByHODController : BaseController
    {
        
        public ActionResult Index()
        {

            ViewBag.MainTitle = "AddRequisitionByHOD";
            ViewBag.Title = "AddRequisitionByHOD";
            ViewBag.Icon = "fa fa-user";
            AddRequisitionByHODBO objAddRequisitionByHODBO = new AddRequisitionByHODBO();
            return View(objAddRequisitionByHODBO);
        }
        [HttpPost]
        public JsonResult SaveRequisitionByHOD(AddRequisitionByHODBO Data)
        {
            AddRequisitionByHODBAL objAddRequisitionByHODBAL = new AddRequisitionByHODBAL();
            string strResult = objAddRequisitionByHODBAL.SaveAddRequisitionByHOD(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult,JsonRequestBehavior.AllowGet);
        }
    }
}