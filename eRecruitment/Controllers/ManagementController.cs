using eRecruitment.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class ManagementController : BaseController
    {
        // GET: Management
        public ActionResult Index()
        {
            return View();
        }
    }
}