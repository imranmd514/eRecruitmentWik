using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class RejectedApplicantsListDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcJobTypeList = "usp_SCH_DropDownJobList";
        public List<CommonDropDownBO> GetJobTypeList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcJobTypeList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objCommonDropDownBO = new CommonDropDownBO();
                        objCommonDropDownBO.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objCommonDropDownBO.Value = objDataSet.Tables[0].Rows[i][1].ToString();
                        objCommonDropDownBOList.Add(objCommonDropDownBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetJobTypeList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }


        public static string ProcGetRejectedApplicantsList = "usp_rpt_RejectedApplicantsOnJobCondition";
        public List<RejectedApplicantsListBO> getRejectedApplicantsList(int iJobId)
        {
            DataSet objDataSet = null;
            RejectedApplicantsListBO objRejectedApplicantsListBO = null;
            List<RejectedApplicantsListBO> objRejectedApplicantsBOList = new List<RejectedApplicantsListBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcGetRejectedApplicantsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objRejectedApplicantsListBO = new RejectedApplicantsListBO();
                        objRejectedApplicantsListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objRejectedApplicantsListBO.FullName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objRejectedApplicantsListBO.AcademicQualification = objDataSet.Tables[0].Rows[i][2].ToString();
                        objRejectedApplicantsListBO.MobileNumber = objDataSet.Tables[0].Rows[i][3].ToString();
                        objRejectedApplicantsListBO.EmailAddress = objDataSet.Tables[0].Rows[i][4].ToString();
                        objRejectedApplicantsListBO.MotherTongue = objDataSet.Tables[0].Rows[i][5].ToString();
                        objRejectedApplicantsListBO.DateOfBirth = objDataSet.Tables[0].Rows[i][6].ToString();
                        objRejectedApplicantsListBO.Gender = objDataSet.Tables[0].Rows[i][7].ToString();
                        objRejectedApplicantsListBO.DonorProgram = objDataSet.Tables[0].Rows[i][8].ToString();
                        objRejectedApplicantsListBO.ProfessionalBodyName = objDataSet.Tables[0].Rows[i][9].ToString();
                        objRejectedApplicantsListBO.MembershipNumber = objDataSet.Tables[0].Rows[i][10].ToString();
                        objRejectedApplicantsListBO.Validity = objDataSet.Tables[0].Rows[i][11].ToString();
                        objRejectedApplicantsListBO.Subject = objDataSet.Tables[0].Rows[i][12].ToString();
                        objRejectedApplicantsListBO.Status = objDataSet.Tables[0].Rows[i][13].ToString();
                        objRejectedApplicantsBOList.Add(objRejectedApplicantsListBO);


                        //objRejectedApplicantsListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        //objRejectedApplicantsListBO.FullName = objDataSet.Tables[0].Rows[i][1].ToString();
                        //objRejectedApplicantsListBO.MobileNumber = objDataSet.Tables[0].Rows[i][2].ToString();
                        //objRejectedApplicantsListBO.EmailAddress = objDataSet.Tables[0].Rows[i][3].ToString();
                        //objRejectedApplicantsListBO.Address = objDataSet.Tables[0].Rows[i][4].ToString();
                        //objRejectedApplicantsListBO.Status = objDataSet.Tables[0].Rows[i][5].ToString();
                        //objRejectedApplicantsListBO.DonorProgram = objDataSet.Tables[0].Rows[i][6].ToString();
                        //objRejectedApplicantsListBO.RequiredStaffLevel = objDataSet.Tables[0].Rows[i][7].ToString();
                        //objRejectedApplicantsListBO.CurrentStaffLevel = objDataSet.Tables[0].Rows[i][8].ToString();
                        //objRejectedApplicantsListBO.Gaps = objDataSet.Tables[0].Rows[i][9].ToString();
                        //objRejectedApplicantsListBO.HOD_Comments = objDataSet.Tables[0].Rows[i][10].ToString();
                        //objRejectedApplicantsListBO.JobLocation = objDataSet.Tables[0].Rows[i][11].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getRejectedApplicantsList");
                throw ex;
            }
            return objRejectedApplicantsBOList;
        }
    }
}
