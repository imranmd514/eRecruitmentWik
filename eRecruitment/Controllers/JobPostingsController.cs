using BusinessLayer;
using eRecruitment.CustomFilters;
using Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.IO;
using System.Globalization;
using System.Web;
using System.Configuration;
using Utils;

namespace eRecruitment.Controllers
{
    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class JobPostingsController : BaseController
    {
        string strFileUploadPath = ConfigurationManager.AppSettings["JobDescription"].ToString();
        string strSenderEmailAddress = ConfigurationManager.AppSettings["SenderEmailAddress"].ToString();
        public ActionResult Index()
        {
            ViewBag.Title = "Jobs";
            ViewBag.MainTitle = "Job Postings";
            JobPostingsBO objJobPostingsBO = new JobPostingsBO();
            return View(objJobPostingsBO);
        }

        [HttpGet]
        public ActionResult CreateJob()
        {
            ViewBag.MainTitle = "JobPosting";
            ViewBag.Title = "Jobs";
            ViewBag.Icon = "fa fa-user";
            JobPostingBAL objJobPostingBAL = new JobPostingBAL();
            PostingJobBO objJobPostingsBO = new PostingJobBO();
            objJobPostingsBO.DonorProgramList = objJobPostingBAL.DonorProgramList(Convert.ToInt32(ViewData["LoginUserId"]));
            return View("AddJobs", objJobPostingsBO);
        }

        [HttpPost]
        public JsonResult SaveJobPosting(PostJobBO Data)
        {
            string strResult = "";
            if (Request.Files.Count > 0)
            {
                string strFileName = "";
                string strExtention = "";
                Random objRandom = new Random();
                string strRandom = objRandom.Next(10000) + "";

                string fileName = "";
                string fileContentType = "";
                byte[] tempFileBytes = null;
                dynamic data = null;
                dynamic types = null;
                bool result = false;

                HttpFileCollectionBase files = Request.Files;
                if (files != null)
                {

                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        if (file.ContentLength == 0)
                        {
                            strResult = "Upload file should not be empty";
                        }
                        else if (file.ContentLength > 0)
                        {
                            strExtention = Path.GetExtension(file.FileName);
                            fileName = file.FileName; // getting File Name
                            fileContentType = file.ContentType; // getting ContentType
                            tempFileBytes = new byte[file.ContentLength]; // getting filebytes
                            data = file.InputStream.Read(tempFileBytes, 0, Convert.ToInt32(file.ContentLength));
                            types = CommonUtils.FileType.Image;  // Setting Image type
                            //if (strExtention.ToUpper() == ".XLS")
                            //{
                            //    types = CommonUtils.FileType.XLS;
                            //}
                            if (strExtention.ToUpper() == ".PDF")
                            {
                                types = CommonUtils.FileType.PDF;
                            }
                            //else if (strExtention.ToUpper() == ".XLSX")
                            //{
                            //    types = CommonUtils.FileType.XLSX;
                            //}
                            else if (strExtention.ToUpper() == ".DOC")
                            {
                                types = CommonUtils.FileType.DOC;
                            }
                            else if (strExtention.ToUpper() == ".DOCX")
                            {
                                types = CommonUtils.FileType.DOCX;
                            }
                            result = CommonUtils.isValidFile(tempFileBytes, types, fileContentType); // Validate Header                                   

                            if (result)
                            {
                                int FileLength = 1024 * 1024 * 3; //FileLength 3 MB
                                if (file.ContentLength > FileLength)
                                {
                                    strResult = "Upload file should not be greater than 3MB";
                                }
                                strFileName = strRandom + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) + strExtention;
                                var strFileType = file.FileName.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                                Data.JobDescriptionFileSavedName = strFileName;
                                strFileName = Path.Combine(strFileUploadPath, strFileName);
                                file.SaveAs(strFileName);

                            }
                            else
                            {
                                strResult = "Upload Valid File";
                            }
                        }
                    }
                }
            }
            JobPostingBAL objJobPostingBAL = new JobPostingBAL();
            Data.StatusId = 1;
            Data.IsActive = true;
                        
            if (strResult == "")
            {
                strResult = objJobPostingBAL.SaveorUpdateJobPosting(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            }

            List<string> usersList = objJobPostingBAL.getHRofficeUsersList();
            string strEmailBody = "";
            if (usersList.Count > 0)
            {
                strEmailBody = getEmailBody();
                CommonUtils.SendEmail(strSenderEmailAddress, usersList, "New Job Approval Request", strEmailBody);
            }

            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        public string getEmailBody()
        {
            string strResult = "<table>";
            strResult = strResult + "<tr><td>Dear HR Office, </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td>Welcome to WIK Job Portal.</td></tr>";
            strResult = strResult + "<tr><td> New Job is Posted by HOD.</td></tr>";
            strResult = strResult + "<tr><td> Please <a href = https://eRecruitmentwik.org/> Click Here!</a> to review the post and approve / Reject the job </td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr>";
            strResult = strResult + "<tr><td><td><br/></td></tr></table>";
            strResult = strResult + "<tr><td>Thank You</td><td></td></tr>";
            strResult = strResult + "</table>";

            return strResult;
        }


        [HttpGet]
        public ActionResult getJobsList()
        {
            JobPostingBAL objJobPostingBAL = new JobPostingBAL();
            List<PostJobBO> objJobPostingsBOList = objJobPostingBAL.getJobsList(Convert.ToInt32(ViewData["LoginUserId"]));
            return PartialView("JobsList", objJobPostingsBOList);
        }

        [HttpGet]
        public ActionResult EditJobPosting(int iJobPostingId)
        {
            JobPostingBAL objJobPostingBAL = new JobPostingBAL();
            PostingJobBO objJobPostingsBO = objJobPostingBAL.EditJobPosting(iJobPostingId);
            objJobPostingsBO.DonorProgramList = objJobPostingBAL.DonorProgramList(Convert.ToInt32(ViewData["LoginUserId"]));
            return View("AddJobs", objJobPostingsBO);
        }

        [HttpGet]
        public ActionResult ViewJobs(int iJobPostingId)
        {
            JobPostingBAL objJobPostingBAL = new JobPostingBAL();
            PostingJobBO objJobPostingsBO = objJobPostingBAL.EditJobPosting(iJobPostingId);
            return PartialView("ViewJobPosting", objJobPostingsBO);
        }

        [HttpPost]
        public JsonResult DeleteJobPosting(int iJobPostingId)
        {
            JobPostingBAL objJobPostingBAL = new JobPostingBAL();
            string strResult = objJobPostingBAL.deleteJobPosting(iJobPostingId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
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