using eRecruitment.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult CheckApplicantExist()
        {
            UpdateProfileBAL objUpdateProfileBAL = new UpdateProfileBAL();
            string strResult = "";
            if (Convert.ToInt32(ViewData["LoginRoleId"])==70)
            {
                strResult=objUpdateProfileBAL.CheckApplicantExist(Convert.ToInt32(ViewData["EmployeeId"]));
            }
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

    }
}