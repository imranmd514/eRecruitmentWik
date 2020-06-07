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
    public class MenuMasterController : BaseController
    {

        public ActionResult Index()
        {
            ViewBag.MainTitle = "MenuMaster";
            ViewBag.Title = "My Pages";
            ViewBag.Icon = "fa fa-user";
            MenuMasterBO objMenuMasterBO = new MenuMasterBO();
            return View(objMenuMasterBO);
        }

        [HttpGet]
        public ActionResult getMenuList()
        {
            MenuMasterBAL objMenuMasterBAL = new MenuMasterBAL();
            List<MenuMasterBO> objMenuMasterBOList = objMenuMasterBAL.getMenuList();
            return PartialView("GetMenuList", objMenuMasterBOList);
        }
        [HttpGet]
        public ActionResult CreateMenu()
        {
            ViewBag.MainTitle = "Menu Master";
            ViewBag.Title = "Menu";
            ViewBag.ControllerName = "Menu Master";
            ViewBag.Icon = "fa fa-align Justify";
            MenuMasterBO objMenuMasterBO = new MenuMasterBO();
            return PartialView("AddMenu", objMenuMasterBO);
        }

        [HttpPost]
        public JsonResult saveMenuMaster(MenuMasterBO Data)
        {
            MenuMasterBAL objMenuMasterBAL = new MenuMasterBAL();
            Data.IsActive = true;
            string strResult = objMenuMasterBAL.SaveorUpdateMenuMaster(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]

        public ActionResult EditMenuMaster(int iMenuId)
        {
            MenuMasterBAL objMenuMasterBAL = new MenuMasterBAL();
            MenuMasterBO objMenuMasterBO = objMenuMasterBAL.EditMenuMaster(iMenuId);
            return PartialView("AddMenu", objMenuMasterBO);
        }

        [HttpGet]
        public ActionResult ViewMenuMaster(int iMenuId)
        {
            MenuMasterBAL objMenuMasterBAL = new MenuMasterBAL();
            MenuMasterBO objMenuMasterBO = objMenuMasterBAL.ViewMenuMaster(iMenuId);
            return PartialView("ViewMenuMaster", objMenuMasterBO);
        }

        [HttpPost]
        
        public JsonResult deleteMenuMaster(int iMenuId)
        {
            MenuMasterBAL objMenuMasterBAL = new MenuMasterBAL();
            string strResult = objMenuMasterBAL.deleteMenuMaster(iMenuId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

    }
}