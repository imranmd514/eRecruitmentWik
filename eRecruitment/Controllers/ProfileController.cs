using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using BusinessLayer;
using System.Web.Mvc;
using eRecruitment.CustomFilters;
using System.Configuration;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class ProfileController : BaseController
    {
        string strViewUploadPhotoPath = ConfigurationManager.AppSettings["ViewPhoto"].ToString();
        public ActionResult Index()
        {
            ViewBag.Title = "Profile";
            ViewBag.MainTitle = "User Profile";
            ViewBag.Icon = "fa fa-user";
            ProfileBAL objProfileBAL = new ProfileBAL();
            ProfileBO objProfileBO = objProfileBAL.DisplayUser(Convert.ToInt32(ViewData["LoginUserId"]));
           // @ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            if (objProfileBO.ActualFileName == "" || objProfileBO.ActualFileName == null)
            {
                ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            }
            else
            {
                ViewBag.ImagePath = Url.Content(strViewUploadPhotoPath + objProfileBO.ActualFileName);
            }

            return View(objProfileBO);
        }
    }
}