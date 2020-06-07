using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;


namespace DataAccessLayer
{
    public class ApplicantsListDAL
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


        public static string ProcGetApplicantsList = "usp_rpt_ApplicantsListReportOnJobCondition";
        public List<ApplicantsListBO> getApplicantsList(int iJobId)
        {
            DataSet objDataSet = null;
            ApplicantsListBO objApplicantsListBO = null;
            List<ApplicantsListBO> objApplicantsBOList = new List<ApplicantsListBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcGetApplicantsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApplicantsListBO = new ApplicantsListBO();
                        objApplicantsListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApplicantsListBO.FullName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objApplicantsListBO.AcademicQualification = objDataSet.Tables[0].Rows[i][2].ToString();
                        objApplicantsListBO.PhoneNumber = objDataSet.Tables[0].Rows[i][3].ToString();
                        objApplicantsListBO.EmailAddress = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApplicantsListBO.MotherTongue = objDataSet.Tables[0].Rows[i][5].ToString();
                        objApplicantsListBO.DateOfBirth = objDataSet.Tables[0].Rows[i][6].ToString();
                        objApplicantsListBO.Gender = objDataSet.Tables[0].Rows[i][7].ToString();
                        objApplicantsListBO.DonorProgram = objDataSet.Tables[0].Rows[i][8].ToString();
                        objApplicantsListBO.ProfessionalBodyName = objDataSet.Tables[0].Rows[i][9].ToString();
                        objApplicantsListBO.MembershipNumber = objDataSet.Tables[0].Rows[i][10].ToString();
                        objApplicantsListBO.Validity = objDataSet.Tables[0].Rows[i][11].ToString();
                        objApplicantsListBO.Subject = objDataSet.Tables[0].Rows[i][12].ToString();
                        objApplicantsListBO.Status = objDataSet.Tables[0].Rows[i][13].ToString();
                        objApplicantsBOList.Add(objApplicantsListBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getApplicantsList");
                throw ex;
            }
            return objApplicantsBOList;
        }
    }
}
