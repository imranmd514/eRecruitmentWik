using eRecruitment.Controllers;
using eRecruitment.Security;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Westwind.Utilities.Logging;

namespace eRecruitment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Create a log manager based on setting in config file
            LogManager.Create();

        }



        protected void Application_Error()
        {
            try
            {
                Exception serverException = Server.GetLastError();

                //WebErrorHandler errorHandler;

                //// Try to log the inner Exception since that's what
                //// contains the 'real' error.
                //if (serverException.InnerException != null)
                //    serverException = serverException.InnerException;

                //errorHandler = new WebErrorHandler(serverException);

                //// MUST clear out any previous response in case error occurred in a view
                //// that already started rendering
                //Response.Clear();


                // Log the error if specified
                if (LogManagerConfiguration.Current.LogErrors)
                {
                    //errorHandler.Parse();

                    //try
                    //{
                    WebLogEntry entry = new WebLogEntry(serverException, this.Context);
                    //entry.Details = errorHandler.ToString();

                    LogManager.Current.WriteEntry(entry);
                    //}
                    //catch {  /* Log Error shouldn't kill the error handler */ }
                }

                // Retrieve the detailed String information of the Error
                string ErrorDetail = ""; //errorHandler.ToString();

                // Optionally email it to the Admin contacts set up in WebStoreConfig
                if (!string.IsNullOrEmpty(AppSecurity.Configuration.ErrorEmailAddress))
                    AppWebUtils.SendAdminEmail(AppSecurity.Configuration.ApplicationTitle + "Error: " + Request.RawUrl, ErrorDetail, "",
                                               AppSecurity.Configuration.ErrorEmailAddress);


                // Debug modes handle different error display mechanisms
                // Default  - default ASP.Net - depends on web.config settings
                // Developer  - display a generic application error message with no error info
                // User  - display a detailed error message with full error info independent of web.config setting
                if (AppSecurity.Configuration.DebugMode == DebugModes.DeveloperErrorMessage)
                {

                    Server.ClearError();
                    Response.TrySkipIisCustomErrors = true;
                    ErrorController.ShowErrorPage("Application Error", "<div class='codedisplay'><pre id='Code'>" + HttpUtility.HtmlEncode(ErrorDetail) + "</pre></div>");
                    return;
                }

                else if (AppSecurity.Configuration.DebugMode == DebugModes.ApplicationErrorMessage)
                {
                    string StockMessage =
                            "The Server Administrator has been notified and the error logged.<p>" +
                            "Please continue by either clicking the back button or by returning to the home page.</p>" +
                            "<p><b><a href='" + Request.ApplicationPath + "'>Click here to continue...</a></b></p>";

                    // Handle some stock errors that may require special error pages
                    HttpException httpException = serverException as HttpException;
                    if (httpException != null)
                    {
                        int HttpCode = httpException.GetHttpCode();
                        Server.ClearError();

                        if (HttpCode == 404) // Page Not Found 
                        {
                            Response.StatusCode = 404;
                            ErrorController.ShowErrorPage("Page not found",
                                "You've accessed an invalid page on this Web server. " +
                                StockMessage, null);
                            return;
                        }
                        if (HttpCode == 401) // Access Denied 
                        {
                            Response.StatusCode = 401;
                            ErrorController.ShowErrorPage("Access Denied",
                                "You've accessed a resource that requires a valid login. " +
                                StockMessage);
                            return;
                        }
                    }

                    // Display a generic error message
                    Server.ClearError();
                    Response.StatusCode = 500;

                    Response.TrySkipIisCustomErrors = true;

                    ErrorController.ShowErrorPage("Application Error",
                        "We're sorry, but an unhandled error occurred on the server. " +
                        StockMessage);

                    return;
                }

                return;
            }
            catch (Exception ex)
            {
                // Failure in the attempt to report failure - try to email
                if (!string.IsNullOrEmpty(AppSecurity.Configuration.ErrorEmailAddress))
                {
                    AppWebUtils.SendAdminEmail(AppSecurity.Configuration.ApplicationTitle + "Error: " + Request.RawUrl,
                            "Application_Error failed!\r\n\r\n" +
                            ex.ToString(), "", AppSecurity.Configuration.ErrorEmailAddress);
                }

                // and display an error message
                Server.ClearError();
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;

                ErrorController.ShowErrorPage("Application Error Handler Failed",
                        "The application Error Handler failed with an exception." +
                        (AppSecurity.Configuration.DebugMode == DebugModes.DeveloperErrorMessage ? "<pre>" + ex.ToString() + "</pre>" : ""), null);

            }
        }


        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            // Request Logging
            if (LogManagerConfiguration.Current.LogWebRequests)
            {
                try
                {
                    WebLogEntry entry = new WebLogEntry()
                    {
                        ErrorLevel = ErrorLevels.Info,
                        Message = this.Context.Request.FilePath,
                        RequestDuration = (decimal)DateTime.Now.Subtract(Context.Timestamp).TotalMilliseconds
                    };
                    entry.UpdateFromRequest(this.Context);
                    LogManager.Current.WriteEntry(entry);
                }
                catch {; }
            }
        }
    }
}
