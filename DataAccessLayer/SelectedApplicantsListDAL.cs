using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;


namespace DataAccessLayer
{
    public class SelectedApplicantsListDAL
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


        public static string ProcGetSelectedApplicantsDetailsList = "usp_rpt_SelectedApplicantsdetailsOnJobCondition";
        public List<SelectedApplicantsListBO> getSelectedApplicantsList(int iJobId)
        {
            DataSet objDataSet = null;
            SelectedApplicantsListBO objSelectedApplicantsListBO = null;
            List<SelectedApplicantsListBO> objSelectedApplicantsBOList = new List<SelectedApplicantsListBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcGetSelectedApplicantsDetailsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objSelectedApplicantsListBO = new SelectedApplicantsListBO();
                        objSelectedApplicantsListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objSelectedApplicantsListBO.FullName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objSelectedApplicantsListBO.AcademicQualification = objDataSet.Tables[0].Rows[i][2].ToString();
                        objSelectedApplicantsListBO.PhoneNumber = objDataSet.Tables[0].Rows[i][3].ToString();
                        objSelectedApplicantsListBO.EmailAddress = objDataSet.Tables[0].Rows[i][4].ToString();
                        objSelectedApplicantsListBO.MotherTongue = objDataSet.Tables[0].Rows[i][5].ToString();
                        objSelectedApplicantsListBO.DateOfBirth = objDataSet.Tables[0].Rows[i][6].ToString();
                        objSelectedApplicantsListBO.Gender = objDataSet.Tables[0].Rows[i][7].ToString();
                        objSelectedApplicantsListBO.DonorProgram = objDataSet.Tables[0].Rows[i][8].ToString();
                        objSelectedApplicantsListBO.ProfessionalBodyName = objDataSet.Tables[0].Rows[i][9].ToString();
                        objSelectedApplicantsListBO.MembershipNumber = objDataSet.Tables[0].Rows[i][10].ToString();
                        objSelectedApplicantsListBO.Validity = objDataSet.Tables[0].Rows[i][11].ToString();
                        objSelectedApplicantsListBO.Subject = objDataSet.Tables[0].Rows[i][12].ToString();
                        objSelectedApplicantsListBO.Status = objDataSet.Tables[0].Rows[i][13].ToString();
                        objSelectedApplicantsBOList.Add(objSelectedApplicantsListBO);



                        //objSelectedApplicantsListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        //objSelectedApplicantsListBO.FullName = objDataSet.Tables[0].Rows[i][1].ToString();
                        //objSelectedApplicantsListBO.PhoneNumber = objDataSet.Tables[0].Rows[i][2].ToString();
                        //objSelectedApplicantsListBO.EmailAddress = objDataSet.Tables[0].Rows[i][3].ToString();
                        //objSelectedApplicantsListBO.Address = objDataSet.Tables[0].Rows[i][4].ToString();
                        //objSelectedApplicantsListBO.Status = objDataSet.Tables[0].Rows[i][5].ToString();
                        //objSelectedApplicantsListBO.DonorProgram = objDataSet.Tables[0].Rows[i][6].ToString();
                        //objSelectedApplicantsListBO.RequiredStaffLevel = objDataSet.Tables[0].Rows[i][7].ToString();
                        //objSelectedApplicantsListBO.CurrentStaffLevel = objDataSet.Tables[0].Rows[i][8].ToString();
                        //objSelectedApplicantsListBO.Gaps = objDataSet.Tables[0].Rows[i][9].ToString();
                        //objSelectedApplicantsListBO.HOD_Comments = objDataSet.Tables[0].Rows[i][10].ToString();
                        //objSelectedApplicantsListBO.JobLocation = objDataSet.Tables[0].Rows[i][11].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getSelectedApplicantsList");
                throw ex;
            }
            return objSelectedApplicantsBOList;
        }
    }
}
