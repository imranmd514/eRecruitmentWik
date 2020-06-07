using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eRecruitment.CustomFilters
{
    public class CustAuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsAuthenticated)
            {
                // need to check from Database 
                return true;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();

            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            { controller = "Accounts", action = "LogOn" }));
        }


        private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        {
            validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
            {
                // If a child action cache block is active, we need to fail immediately, 
                // even if authorization would have succeeded. 
                // The reason is that there's no way to hook a callback to rerun
                // authorization before the fragment is served from the cache, 
                // so we can't guarantee that this
                // filter will be re-run on subsequent requests.
                throw new InvalidOperationException("AuthorizeAttribute_CannotUseWithinChildActionCache");
            }

            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            else
            {
                if (AuthorizeCore(filterContext.HttpContext))
                {
                    // ** IMPORTANT **
                    // Since we're performing authorization at the action level, 
                    // the authorization code runs after the output caching module. 
                    // In the worst case, this could allow an authorized user to cause the page 
                    // to be cached, then an unauthorized user would later be served the
                    // cached page. We work around this by telling proxies not to cache 
                    // the sensitive page, then we hook our custom authorization code into 
                    // the caching mechanism so that we have
                    // the final say on whether a page should be served from the cache.

                    HttpCachePolicyBase cachePolicy = filterContext.HttpContext.Response.Cache;
                    cachePolicy.SetProxyMaxAge(new TimeSpan(0));
                    cachePolicy.AddValidationCallback(CacheValidateHandler, null /* data */);
                }
                else
                {
                    HandleUnauthorizedRequest(filterContext);
                }
            }

        }
        // This method must be thread-safe since it is called by the caching module.
        protected virtual HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            bool isAuthorized = AuthorizeCore(httpContext);
            return (isAuthorized) ? HttpValidationStatus.Valid :
                                   HttpValidationStatus.IgnoreThisRequest;
        }
    }
}

