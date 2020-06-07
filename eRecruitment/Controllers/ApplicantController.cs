using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using eRecruitment.CustomFilters;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class ApplicantController : BaseController
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}