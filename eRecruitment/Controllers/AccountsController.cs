using eRecruitment.Controllers.ViewModels;
using eRecruitment.Security;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using eRecruitment.CustomFilters;
using BusinessLayer;



namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [AllowAnonymous]
    public class AccountsController : BaseController
    {
        private AccountViewModel ViewModel = new AccountViewModel();
        public UserBO busUser = null;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            busUser = new UserBO();
            ViewModel.busUser = busUser;
            ViewModel.ErrorDisplay = ErrorDisplay;
            ViewModel.AppUserState = F_AppUserState;
            ViewData["UserState"] = F_AppUserState;
        }

        protected override void Dispose(bool disposing)
        {
            if (busUser != null)
            {
                busUser = null;
            }
            base.Dispose(disposing);
        }


        #region Indivdual User Cookie Logins

        // This constructor is used by the MVC framework to instantiate the controller using
        // the default forms authentication and membership providers.
        public ActionResult LogOn(string message = null)
        {
            if (!string.IsNullOrEmpty(message))
                ViewModel.ErrorDisplay.ShowError(message);

            return View("LogOn", ViewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(string UserName, string Password, string returnUrl, bool rememberMe = false)
        {

            UserBO user = busUser.ValidateUserAndLoad(UserName, Password);
            if (user == null)
            {
                return View(ViewModel);
            }

            AppUserState appUserState = new AppUserState()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                EmailId = user.EmailId,
                Gender = user.Gender,
                Address = user.Address,
                PhoneNo = user.PhoneNo,
                IsActive = user.IsActive,
                EmployeeId = user.EmployeeId,
                RoleId = user.RoleId,
                RoleName = user.RoleName
            };

            IdentitySignin(appUserState, user.UserId, rememberMe);

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home", null);
            }

        }

        public ActionResult LogOff()
        {
            IdentitySignout();
            return RedirectToAction("LogOn");
        }

        public ActionResult Register(string id)
        {
            ViewData["IsNew"] = false;

            if (string.IsNullOrEmpty(id))
                id = F_AppUserState.UserId;

            if (string.IsNullOrEmpty(id))
            {
                busUser = new UserBO();
                ViewData["IsNew"] = true;
            }
            else
            {
                if (id != F_AppUserState.UserId)
                    return RedirectToAction("Register", new { id = "" });

                if (busUser.LoadUserByUserId(id) == null)
                    return RedirectToAction("LogOn", "Account", new { returnUrl = Url.Action("Register", "Account") });
            }

            return View("Register", ViewModel);
        }

        public void IdentitySignin(AppUserState appUserState, string providerKey = null, bool isPersistent = false)
        {
            var claims = new List<Claim>();

            // create *required* claims
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUserState.UserId));
            claims.Add(new Claim(ClaimTypes.Name, appUserState.UserName));

            // serialized AppUserState object
            claims.Add(new Claim("userState", appUserState.ToString()));
            claims.Add(new Claim("LoginUserId", appUserState.UserId));
            claims.Add(new Claim("EmployeeId", appUserState.EmployeeId.ToString()));
            claims.Add(new Claim("LoginRoleId", appUserState.RoleId.ToString()));
            claims.Add(new Claim("LoginRoleName", appUserState.RoleName.ToString()));

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            // add to user here!
            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = isPersistent,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
            }, identity);
        }


        public void IdentitySignout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                DefaultAuthenticationTypes.ExternalCookie);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        //[AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ValidateEmail(string id = null)
        {
            var user = busUser.ValidateEmailAddress(id);
            if (user == null)
                throw new ApplicationException("Invalid email validator id.");

            return RedirectToAction("New", "Snippet",
                new { message = "You're ready to post: Your email address is validated." });
        }

        [HttpGet]
        public JsonResult GetPasswordData(string A_strEmailAddress,string A_strPassword)
        {
            AccountsBAL objAccountsBAL = new AccountsBAL();
            string strResult = objAccountsBAL.GetPasswordData(A_strEmailAddress, A_strPassword);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }
    }
}

#endregion