using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BusinessLayer;
using eRecruitment.CustomFilters;

namespace eRecruitment.Controllers
{

    [CustExceptionFilter]
    [CustActionFilter]
    [CustAuthorizationFilter]
    public class DonorProgramController : BaseController
    {
        // GET: DonorProgram
        public ActionResult Index()
        {
            ViewBag.MainTitle = "Security";
            ViewBag.Title = "Donor Program";
            ViewBag.Icon = "fa fa-user";
            DonorProgramBO objDonorProgramBO = new DonorProgramBO();
            return View(objDonorProgramBO);
        }

        [HttpGet]
        public ActionResult GetDonorList()
        {
            DonorProgramBAL objDonorProgramBAL = new DonorProgramBAL();
            List<DonorProgramBO> objDonorProgramBOList = objDonorProgramBAL.GetDonorList();
            return PartialView("GetDonorList", objDonorProgramBOList);
        }

        [HttpGet]
        public ActionResult AddDonor()
        {
            DonorProgramBO objDonorProgramBO = new DonorProgramBO();
            return PartialView("AddDonor", objDonorProgramBO);
        }

        [HttpPost]
        public JsonResult SaveDonor(DonorProgramBO Data)
        {
            DonorProgramBAL objDonorProgramBAL = new DonorProgramBAL();
            Data.IsActive = true;
            string strResult = objDonorProgramBAL.SaveorUpdateDonor(Data, Convert.ToInt32(ViewData["LoginUserId"]));
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditDonor(int iDonorProgramId)
        {
            DonorProgramBAL objDonorProgramBAL = new DonorProgramBAL();
            DonorProgramBO objDonorProgramBO = objDonorProgramBAL.EditDonor(iDonorProgramId);
            return PartialView("AddDonor", objDonorProgramBO);
        }


        [HttpPost]
        public JsonResult deleteDonor(int iDonorProgramId)
        {
            DonorProgramBAL objDonorProgramBAL = new DonorProgramBAL();
            string strResult = objDonorProgramBAL.deleteDonor(iDonorProgramId);
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

    }
}