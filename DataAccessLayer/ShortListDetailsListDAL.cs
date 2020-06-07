using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class ShortListDetailsListDAL
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

        public static string ProcGetShortListDetailsList = "usp_rpt_ShortListdetailsOnJobCondition";
        public List<ShortListDetailsListBO> getShortListDetailsList(int iJobId)
        {
            DataSet objDataSet = null;
            ShortListDetailsListBO objShortListDetailsListBO = null;
            List<ShortListDetailsListBO> objShortListDetailsBOList = new List<ShortListDetailsListBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcGetShortListDetailsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objShortListDetailsListBO = new ShortListDetailsListBO();
                        objShortListDetailsListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objShortListDetailsListBO.FullName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objShortListDetailsListBO.AcademicQualification = objDataSet.Tables[0].Rows[i][2].ToString();
                        objShortListDetailsListBO.PhoneNumber = objDataSet.Tables[0].Rows[i][3].ToString();
                        objShortListDetailsListBO.EmailAddress = objDataSet.Tables[0].Rows[i][4].ToString();
                        objShortListDetailsListBO.MotherTongue = objDataSet.Tables[0].Rows[i][5].ToString();
                        objShortListDetailsListBO.DateOfBirth = objDataSet.Tables[0].Rows[i][6].ToString();
                        objShortListDetailsListBO.Gender = objDataSet.Tables[0].Rows[i][7].ToString();
                        objShortListDetailsListBO.DonorProgram = objDataSet.Tables[0].Rows[i][8].ToString();
                        objShortListDetailsListBO.ProfessionalBodyName = objDataSet.Tables[0].Rows[i][9].ToString();
                        objShortListDetailsListBO.MembershipNumber = objDataSet.Tables[0].Rows[i][10].ToString();
                        objShortListDetailsListBO.Validity = objDataSet.Tables[0].Rows[i][11].ToString();
                        objShortListDetailsListBO.Subject = objDataSet.Tables[0].Rows[i][12].ToString();
                        objShortListDetailsListBO.Status = objDataSet.Tables[0].Rows[i][13].ToString();
                        objShortListDetailsBOList.Add(objShortListDetailsListBO);




                        //objShortListDetailsListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        //objShortListDetailsListBO.FullName = objDataSet.Tables[0].Rows[i][1].ToString();
                        //objShortListDetailsListBO.PhoneNumber = objDataSet.Tables[0].Rows[i][2].ToString();
                        //objShortListDetailsListBO.EmailAddress = objDataSet.Tables[0].Rows[i][3].ToString();
                        //objShortListDetailsListBO.Address = objDataSet.Tables[0].Rows[i][4].ToString();
                        //objShortListDetailsListBO.Status = objDataSet.Tables[0].Rows[i][5].ToString();
                        //objShortListDetailsListBO.DonorProgram = objDataSet.Tables[0].Rows[i][6].ToString();
                        //objShortListDetailsListBO.RequiredStaffLevel = objDataSet.Tables[0].Rows[i][7].ToString();
                        //objShortListDetailsListBO.CurrentStaffLevel = objDataSet.Tables[0].Rows[i][8].ToString();
                        //objShortListDetailsListBO.Gaps = objDataSet.Tables[0].Rows[i][9].ToString();
                        //objShortListDetailsListBO.HOD_Comments = objDataSet.Tables[0].Rows[i][10].ToString();
                        //objShortListDetailsListBO.JobLocation = objDataSet.Tables[0].Rows[i][11].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getShortListDetailsList");
                throw ex;
            }
            return objShortListDetailsBOList;
        }
    }
}
