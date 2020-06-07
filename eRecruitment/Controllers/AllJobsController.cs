using Models;
using System.Web.Mvc;
using System.Collections.Generic;
using BusinessLayer;
using System;
using eRecruitment.CustomFilters;
using System.Configuration;
using System.IO;
using Utils;



namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class AllJobsController : BaseController
    {
        string strFileUploadPath = ConfigurationManager.AppSettings["JobDescription"].ToString();
        string strSenderEmailAddress = ConfigurationManager.AppSettings["SenderEmailAddress"].ToString();
        public ActionResult Index()
        {
            ViewBag.MainTitle = "All Jobs";
            ViewBag.Title = "Jobs";
            ViewBag.Icon = "fa fa-graduation";
            return View();
        }


        [HttpGet]
        public ActionResult getAllJobsList()
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            List<PostJobBO> objJobsBOList = null;
            if (ViewData["LoginRoleName"].ToString().ToUpper() == "HR OFFICE")
            {
                objJobsBOList = objApprovedJobsBAL.getApprovedJobsList(Convert.ToInt32(ViewData["LoginUserId"]), Convert.ToInt32(ViewData["LoginRoleId"]), 1);
            }
            else if (ViewData["LoginRoleName"].ToString().ToUpper() == "HAF")
            {
                objJobsBOList = objApprovedJobsBAL.getApprovedJobsList(Convert.ToInt32(ViewData["LoginUserId"]), Convert.ToInt32(ViewData["LoginRoleId"]), 4);
            }
            else if (ViewData["LoginRoleName"].ToString().ToUpper() == "ED")
            {
                objJobsBOList = objApprovedJobsBAL.getApprovedJobsList(Convert.ToInt32(ViewData["LoginUserId"]), Convert.ToInt32(ViewData["LoginRoleId"]), 5);
            }
            return PartialView("_GetAllJobsList", objJobsBOList);
        }


        [HttpGet]
        public ActionResult EditAllJobs(int iJobPostingId)
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            AllJobsBAL objAllJobsBAL = new AllJobsBAL();
            ApprovedJobsBO objJobsBO = objApprovedJobsBAL.DisplayApprovedJob(iJobPostingId);
            objJobsBO.DonorProgramList = objAllJobsBAL.DonorProgramList(Convert.ToInt32(ViewData["LoginUserId"]));
            return PartialView("EditJob", objJobsBO);
        }


        [HttpPost]
        public JsonResult SaveApprovedJob(AllJobsBO Data)
        {
            AllJobsBAL objAllJobsBAL = new AllJobsBAL();
            int iRoleId = Convert.ToInt32(ViewData["LoginRoleId"]);
            string strResult = objAllJobsBAL.SaveApprovedJob(Data, Convert.ToInt32(ViewData["LoginUserId"]), iRoleId);
            if (ViewData["LoginRoleName"].ToString().ToUpper() == "HR OFFICE")
            {
                List<string> usersList = objAllJobsBAL.GetHOPPMHAFUsersList();
                string strEmailBody = "";
                if (usersList.Count > 0)
                {
                    strEmailBody = getHROfficeEmailBodyforJobPosted();
                    CommonUtils.SendEmail(strSenderEmailAddress, usersList, "New Job Approval Request", strEmailBody);
                }
            }
            else if (ViewData["LoginRoleName"].ToString().ToUpper() == "HAF")
            {
                List<string> usersList = objAllJobsBAL.GetEDUsersList();
                string strEmailBody = "";
                if (usersList.Count > 0)
                {
                    strEmailBody = getHAFEmailBodyforJobPosted();
                    CommonUtils.SendEmail(strSenderEmailAddress, usersList, "New Job Approval Request", strEmailBody);
                }
            }
            else if (ViewData["LoginRoleName"].ToString().ToUpper() == "ED")
            {
                List<string> usersList = objAllJobsBAL.GetMarketerUsersList();
                string strEmailBody = "";
                if (usersList.Count > 0)
                {
                    strEmailBody = getEDEmailBodyforJobPosted();
                    CommonUtils.SendEmail(strSenderEmailAddress, usersList, "New Job Approval Request", strEmailBody);
                }
            }
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        public string getHROfficeEmailBodyforJobPosted()
        {
            string strResult = "<table>";
            strResult = strResult + "<tr><td>Dear HOP, PM, HAF  </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td>Welcome to WIK Job Portal.</td></tr>";
            strResult = strResult + "<tr><td> New Job is Posted by HR Office .</td></tr>";
            strResult = strResult + "<tr><td> Please <a href = https://eRecruitmentwik.org/> Click Here!</a> to review the post and approve / Reject the job </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr></table>";
            strResult = strResult + "<tr><td>Thank You</td><td></td></tr>";
            strResult = strResult + "</table>";

            return strResult;
        }
        public string getHROfficeEmailBodyforRejectedJob()
        {
            string strResult = "<table>";
            strResult = strResult + "<tr><td>Dear HOP, PM, HAF  </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td>Welcome to WIK Job Portal.</td></tr>";
            strResult = strResult + "<tr><td> Rejected Job is Posted by HR Office .</td></tr>";
            strResult = strResult + "<tr><td> Please <a href = https://eRecruitmentwik.org/> Click Here!</a> to review the job </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr></table>";
            strResult = strResult + "<tr><td>Thank You</td><td></td></tr>";
            strResult = strResult + "</table>";

            return strResult;
        }
        public string getHAFEmailBodyforJobPosted()
        {
            string strResult = "<table>";
            strResult = strResult + "<tr><td>Dear ED, </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td>Welcome to WIK Job Portal.</td></tr>";
            strResult = strResult + "<tr><td> New Job is Posted by HAF....</td></tr>";
            strResult = strResult + "<tr><td> Please <a href = https://eRecruitmentwik.org/> Click Here!</a> to review the post and approve / Reject the job </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr></table>";
            strResult = strResult + "<tr><td>Thank You</td><td></td></tr>";
            strResult = strResult + "</table>";

            return strResult;
        }
        public string getHAFEmailBodyforRejectedJob()
        {
            string strResult = "<table>";
            strResult = strResult + "<tr><td>Dear ED, </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td>Welcome to WIK Job Portal.</td></tr>";
            strResult = strResult + "<tr><td> Rejected Job  is Posted by HAF....</td></tr>";
            strResult = strResult + "<tr><td> Please <a href = https://eRecruitmentwik.org/> Click Here!</a> to review the job </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr></table>";
            strResult = strResult + "<tr><td>Thank You</td><td></td></tr>";
            strResult = strResult + "</table>";

            return strResult;
        }
        public string getEDEmailBodyforJobPosted()
        {
            string strResult = "<table>";
            strResult = strResult + "<tr><td>Dear Marketer, </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td>Welcome to WIK Job Portal.</td></tr>";
            strResult = strResult + "<tr><td> New Job is Posted by ED....</td></tr>";
            strResult = strResult + "<tr><td> Please <a href = https://eRecruitmentwik.org/> Click Here!</a> to review the job </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr></table>";
            strResult = strResult + "<tr><td>Thank You</td><td></td></tr>";
            strResult = strResult + "</table>";

            return strResult;
        }
        public string getEDEmailBodyforRejectedJob()
        {
            string strResult = "<table>";
            strResult = strResult + "<tr><td>Dear Marketer, </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td>Welcome to WIK Job Portal.</td></tr>";
            strResult = strResult + "<tr><td>  Rejected Job  is Posted by ED....</td></tr>";
            strResult = strResult + "<tr><td> Please <a href = https://eRecruitmentwik.org/> Click Here!</a> to review the job </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr></table>";
            strResult = strResult + "<tr><td>Thank You</td><td></td></tr>";
            strResult = strResult + "</table>";

            return strResult;
        }

        [HttpPost]
        public JsonResult SaveRejectedJob(AllJobsBO Data)
        {
            AllJobsBAL objAllJobsBAL = new AllJobsBAL();
            int iRoleId = Convert.ToInt32(ViewData["LoginRoleId"]);
            string strResult = objAllJobsBAL.SaveRejectedJob(Data, Convert.ToInt32(ViewData["LoginUserId"]), iRoleId);

            if (ViewData["LoginRoleName"].ToString().ToUpper() == "HR OFFICE")
            {
                List<string> usersList = objAllJobsBAL.GetHOPPMHAFUsersList();
                string strEmailBody = "";
                if (usersList.Count > 0)
                {
                    strEmailBody = getHROfficeEmailBodyforRejectedJob();
                    CommonUtils.SendEmail(strSenderEmailAddress, usersList, "Rejected Job", strEmailBody);
                }
            }
            else if (ViewData["LoginRoleName"].ToString().ToUpper() == "HAF")
            {
                List<string> usersList = objAllJobsBAL.GetEDUsersList();
                string strEmailBody = "";
                if (usersList.Count > 0)
                {
                    strEmailBody = getHAFEmailBodyforRejectedJob();
                    CommonUtils.SendEmail(strSenderEmailAddress, usersList, "Rejected Job", strEmailBody);
                }
            }
            else if (ViewData["LoginRoleName"].ToString().ToUpper() == "ED")
            {
                List<string> usersList = objAllJobsBAL.GetMarketerUsersList();
                string strEmailBody = "";
                if (usersList.Count > 0)
                {
                    strEmailBody = getEDEmailBodyforRejectedJob();
                    CommonUtils.SendEmail(strSenderEmailAddress, usersList, "Rejected Job", strEmailBody);
                }
            }
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveOnHoldJob(AllJobsBO Data)
        {
            AllJobsBAL objAllJobsBAL = new AllJobsBAL();
            string strRoleName = ViewData["LoginRoleName"].ToString().ToUpper();
            string strResult = objAllJobsBAL.SaveOnHoldJob(Data, Convert.ToInt32(ViewData["LoginUserId"]), strRoleName);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteAllJobs(int iJobPostingId)
        {
            AllJobsBAL objAllJobsBAL = new AllJobsBAL();
            string strResult = objAllJobsBAL.deleteAllJobs(iJobPostingId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewAllJob(int iJobPostingId)
        {
            ApprovedJobsBAL objApprovedJobsBAL = new ApprovedJobsBAL();
            ApprovedJobsBO objJobsBO = objApprovedJobsBAL.DisplayApprovedJob(iJobPostingId);
            return PartialView("ViewAllJobsList", objJobsBO);
        }

        public ActionResult DownloadAttachment(string FileSavedName, string fileActualName)
        {
            string strFilePath = Path.Combine(strFileUploadPath, FileSavedName);
            if (!System.IO.File.Exists(strFilePath))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(strFilePath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = fileActualName
            };
            return response;
        }



    }
}