using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRecruitment.CustomFilters
{
    public class CustActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // need to log infomation
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // need to log infomation
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            // need to log infomation
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //filterContext.Controller.ViewBag.CustomActionMessage4 = "Custom Action Filter: Message from OnResultExecuted method.";
        }
    }
}