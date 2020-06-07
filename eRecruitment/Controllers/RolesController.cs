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
    public class RolesController : BaseController
    {

        public ActionResult Index()
        {
            ViewBag.MainTitle = "Roles";
            ViewBag.Title = "My Pages";
            ViewBag.Icon = "fa fa-user";
            RolesBO objRolesBO = new RolesBO();
            return View(objRolesBO);
        }

        [HttpGet]
        public ActionResult AddRole()
        {
            RolesBO objRolesBO = new RolesBO();
            return PartialView("AddRole", objRolesBO);
        }

        [HttpGet]
        public ActionResult getRolesList()
        {
            RolesBAL objRolesBAL = new RolesBAL();
            List<RolesBO> objRolesBOList = objRolesBAL.getRolesList();
            return PartialView("GetRolesList", objRolesBOList);
        }

        [HttpPost]
        public JsonResult saveRole(RolesBO Data)
        {
            RolesBAL objRolesBAL = new RolesBAL();
            Data.IsActive = true;
            string strResult = objRolesBAL.SaveorUpdateRole(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EditRole(int iRoleId)
        {
            RolesBAL objRolesBAL = new RolesBAL();
            RolesBO objRolesBO = objRolesBAL.EditRole(iRoleId);
            return PartialView("AddRole", objRolesBO);
        }

        [HttpPost]
        public JsonResult deleteRole(int iRoleId)
        {
            RolesBAL objRolesBAL = new RolesBAL();
            string strResult = objRolesBAL.deleteRole(iRoleId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

    }


}