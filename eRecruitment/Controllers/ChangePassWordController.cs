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
    public class ChangePassWordController : BaseController
    {
        // GET: ChangePassWord
        public ActionResult Index(string strEmailId)
        {
            //ViewData["EmailAddress"] ="";
            //string strEmailId ;
            //strEmailId = ViewData["EmailAddress"].ToString();
            //if (strEmailId != null && strEmailId != "")
            //{
            //    ViewData["EmailAddress"] = strEmailId;
            //}
            //else
            //{
            //    ViewData["EmailAddress"] = "";
            //}
            ViewBag.MainTitle = "Security";
            ViewBag.Title = "ChangePassWord";
            ViewBag.Icon = "fa fa-user";
            ChangePassWordBO objChangePassWordBO = new ChangePassWordBO();
            ChangePassWordBAL objChangePassWordBAL = new ChangePassWordBAL();
            objChangePassWordBO = objChangePassWordBAL.GetEmailAddress(Convert.ToInt32(ViewData["LoginUserId"]));
            return View(objChangePassWordBO);
        }


        [HttpPost]
        public JsonResult SaveNewPassword(ChangePassWordBO Data)
        {
            ChangePassWordBAL objChangePassWordBAL = new ChangePassWordBAL();
            Data.IsActive = true;
            string strResult = objChangePassWordBAL.SaveChangePassword(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
    }
}