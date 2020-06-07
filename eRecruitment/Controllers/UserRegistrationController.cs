using BusinessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Web;
using eRecruitment.CustomFilters;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class UserRegistrationController : BaseController
    {
        string strFileUploadPath = ConfigurationManager.AppSettings["ImageUpload"].ToString();
        string strImageDisplayPath = ConfigurationManager.AppSettings["ImageDisplayPath"].ToString();
       
        public ActionResult Index()
        {
            ViewBag.MainTitle = "UserRegistration";
            ViewBag.Title = "Users";
            ViewBag.Icon = "fa fa-user";
            UserRegistrationBO objUserRegistrationBO = new UserRegistrationBO();
            return View(objUserRegistrationBO);
        }


        [HttpGet]
        public ActionResult CreateUser()
        {
            ViewBag.MainTitle = "UserRegistration";
            ViewBag.Title = "Users";
            ViewBag.Icon = "fa fa-user";
            UserRegistrationBO objUserRegistrationBO = new UserRegistrationBO();
            UserRegistrationBAL objUserRegistrationBAL = new UserRegistrationBAL();
            objUserRegistrationBO.CountriesList = objUserRegistrationBAL.CountriesList();
            objUserRegistrationBO.RolesList = objUserRegistrationBAL.RolesList();
            objUserRegistrationBO.GenderList = objUserRegistrationBAL.GenderList();
            objUserRegistrationBO.LocationList = objUserRegistrationBAL.LocationList();
            objUserRegistrationBO.DonorProgramList = objUserRegistrationBAL.getDonorProgramList(Convert.ToInt32(ViewData["LoginUserId"]));
            @ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            return PartialView("AddUser", objUserRegistrationBO);
        }

        [HttpGet]
        public JsonResult getDonorProgramList(int iUserId)
        {
            UserRegistrationBAL objUserRegistrationBAL = new UserRegistrationBAL();
            List<CommonDropDownBO> objDonorProgramList = objUserRegistrationBAL.getDonorProgramList(Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(objDonorProgramList, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult stateList(int A_iCountryId)
        {
            UserRegistrationBAL objUserRegistrationBAL = new UserRegistrationBAL();
            List<CommonDropDownBO> objCommonDropDownBOList = objUserRegistrationBAL.StatesList(A_iCountryId);
            return Json(objCommonDropDownBOList, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult SaveUserRegistration(UserRegistrationBO Data)
        {
            if (Request.Files.Count > 0)
            {
                string strFileName = "";
                string strExtention = "";
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    strExtention = Path.GetExtension(file.FileName);
                    strFileName = ViewData["LoginUserId"].ToString() + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) + strExtention;
                    Data.FileSavedName = strFileName;
                    strFileName = Path.Combine(strFileUploadPath, strFileName);
                    file.SaveAs(strFileName);
                }
            }
            UserRegistrationBAL objUserRegistrationBAL = new UserRegistrationBAL();
            //Data.IsActive = true;
            string strResult = objUserRegistrationBAL.SaveorUpdateUserRegistration(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUsersList()
        {
            UserRegistrationBAL objUserRegistrationBAL = new UserRegistrationBAL();
            List<UserRegistrationBO> objUserRegistrationBOList = objUserRegistrationBAL.getUsersList();
            return PartialView("GetUsersList", objUserRegistrationBOList);
        }

        [HttpGet]
        public ActionResult EditUser(int iUserId)
        {
            UserRegistrationBAL objUserRegistrationBAL = new UserRegistrationBAL();
            UserRegistrationBO objUserRegistrationBO = objUserRegistrationBAL.EditUserDetails(iUserId);
            objUserRegistrationBO.CountriesList = objUserRegistrationBAL.CountriesList();
            objUserRegistrationBO.GenderList = objUserRegistrationBAL.GenderList();
            objUserRegistrationBO.RolesList = objUserRegistrationBAL.RolesList();
            objUserRegistrationBO.LocationList = objUserRegistrationBAL.LocationList();
            objUserRegistrationBO.DonorProgramList = objUserRegistrationBAL.getDonorProgramList(iUserId);

            if (objUserRegistrationBO.FileSavedName == "" || objUserRegistrationBO.FileSavedName == null)
            {
                ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            }
            else
            {
                ViewBag.ImagePath = Url.Content(strImageDisplayPath + objUserRegistrationBO.FileSavedName);
            }

            return PartialView("EditUserView", objUserRegistrationBO);
        }

        [HttpGet]
        public ActionResult ViewUser(int iUserId)
        {
            UserRegistrationBAL objUserRegistrationBAL = new UserRegistrationBAL();
            UserRegistrationBO objUserRegistrationBO = objUserRegistrationBAL.DisplayUser(iUserId);
            objUserRegistrationBO.GenderList = objUserRegistrationBAL.GenderList();
            if (objUserRegistrationBO.FileSavedName == "")
            {
                ViewBag.ImagePath = Url.Content("../assets/images/user-1.png");
            }
            else
            {
                ViewBag.ImagePath = Url.Content(strImageDisplayPath + objUserRegistrationBO.FileSavedName);
            }
            return PartialView("ViewUser", objUserRegistrationBO);
        }

        [HttpPost]
        public JsonResult DeleteUser(int iUserId)
        {
            UserRegistrationBAL objUserRegistrationBAL = new UserRegistrationBAL();
            string strResult = objUserRegistrationBAL.deleteUser(iUserId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
    }
}

