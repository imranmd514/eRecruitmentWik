using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CommonDB;
using Models;
using Utils;

namespace DataAccessLayer
{
    public class HOPUpdateDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetDonorProgramList = "usp_getDonorProgram";
        public List<CommonDropDownBO> GetDropDownDonorProgramList(int iUserId)
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDrodownBo = null;
            List<CommonDropDownBO> objDropdownListBO = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iUserId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iUserId;
                objProcParameterBOList.Add(objDbParameter);


                objDataSet = objDBAccess.execuitDataSet(ProcGetDonorProgramList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objCommonDrodownBo = new CommonDropDownBO();

                        objCommonDrodownBo.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objCommonDrodownBo.Value = objDataSet.Tables[0].Rows[i][1].ToString();
                        objDropdownListBO.Add(objCommonDrodownBo);
                    }
                }

            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetDropDownDonorProgramList");
                throw ex;
            }
            return objDropdownListBO;

        }

        public static string ProHOPUpdateGrid = "usp_SCH_HOPUpdateGrid";
        public List<AllJobsBO> getHOPUpdateGridList()
        {
            DataSet objDataSet = null;
            AllJobsBO objAllJobsBO = null;
            List<AllJobsBO> objAllJobsBOList = new List<AllJobsBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProHOPUpdateGrid, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objAllJobsBO = new AllJobsBO();
                        objAllJobsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objAllJobsBO.JobName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objAllJobsBO.JobDescription = objDataSet.Tables[0].Rows[i][2].ToString();
                        objAllJobsBO.JobLocation = objDataSet.Tables[0].Rows[i][3].ToString();
                        objAllJobsBO.NoOfPositions = objDataSet.Tables[0].Rows[i][4].ToString();
                        objAllJobsBO.Status = objDataSet.Tables[0].Rows[i][5].ToString();
                        objAllJobsBO.ApprovedBy = Convert.ToInt32(objDataSet.Tables[0].Rows[i][6].ToString());
                        objAllJobsBO.RejectedBy = Convert.ToInt32(objDataSet.Tables[0].Rows[i][7].ToString());
                        objAllJobsBO.HROffice_Comments = objDataSet.Tables[0].Rows[i][8].ToString();
                        objAllJobsBOList.Add(objAllJobsBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getHOPUpdateGridList");
                throw ex;
            }
            return objAllJobsBOList;
        }

        public static string ProcSaveHOPApprovedJob = "usp_SCH_SaveHOPJobApproved";
        public string SaveHOPApprovedJob(AllJobsBO objAllJobsBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iJobPostingId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllJobsBO.JobPostingId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strHOP_Comments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.HOP_Comments;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objAllJobsBO.IsActive;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iUserId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = iUserId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Output;
                objDBparameter.ParameterName = "@strResult";
                objDBparameter.dbType = DbType.String;
                objDBparameter.Size = 100;
                objProcParameterBOList.Add(objDBparameter);


                objDBAccess.executeNonQuery(ProcSaveHOPApprovedJob, ref objProcParameterBOList);

                for (int i = 0; i < objProcParameterBOList.Count; i++)
                {
                    if (objProcParameterBOList[i].Direction == ParameterDirection.Output)
                    {
                        strResult = objProcParameterBOList[i].ParameterValue.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "SaveHOPApprovedJob");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcEditHOPJob = "usp_SCH_HOPEditJob";
        public AllJobsBO EditHOPGrid(int iJobPostingId)
        {
            DataSet objDataSet = null;
            AllJobsBO objAllJobsBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobPostingId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobPostingId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditHOPJob, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objAllJobsBO = new AllJobsBO();
                    objAllJobsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objAllJobsBO.JobName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objAllJobsBO.JobCode = objDataSet.Tables[0].Rows[0][2].ToString();
                    objAllJobsBO.JobDescription = objDataSet.Tables[0].Rows[0][3].ToString();
                    objAllJobsBO.NoOfPositions = objDataSet.Tables[0].Rows[0][4].ToString();
                    objAllJobsBO.JobLocation = objDataSet.Tables[0].Rows[0][5].ToString();
                    objAllJobsBO.JobTimings = objDataSet.Tables[0].Rows[0][6].ToString();
                    objAllJobsBO.JobDuration = objDataSet.Tables[0].Rows[0][7].ToString();
                    objAllJobsBO.Qualification = objDataSet.Tables[0].Rows[0][8].ToString();
                    objAllJobsBO.Experience = objDataSet.Tables[0].Rows[0][9].ToString();
                    objAllJobsBO.Skills = objDataSet.Tables[0].Rows[0][10].ToString();
                    objAllJobsBO.Status = objDataSet.Tables[0].Rows[0][11].ToString();
                    objAllJobsBO.ApprovedById = objDataSet.Tables[0].Rows[0][12].ToString();
                    objAllJobsBO.ApprovedDate = objDataSet.Tables[0].Rows[0][13].ToString();
                    objAllJobsBO.RejectedById = objDataSet.Tables[0].Rows[0][14].ToString();
                    objAllJobsBO.RejectedDate = objDataSet.Tables[0].Rows[0][15].ToString();
                    objAllJobsBO.MarketedBy = objDataSet.Tables[0].Rows[0][16].ToString();
                    objAllJobsBO.MarketedDate = objDataSet.Tables[0].Rows[0][17].ToString();
                    objAllJobsBO.HROffice_Comments = objDataSet.Tables[0].Rows[0][18].ToString();
                    objAllJobsBO.HOP_Comments = objDataSet.Tables[0].Rows[0][19].ToString();
                    objAllJobsBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][20].ToString());
                    objAllJobsBO.DonorProgramId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][21].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditHOPGrid");
                throw ex;
            }
            return objAllJobsBO;
        }

        public static string ProcHOPViewAllJob = "usp_HOPViewAllJobs";
        public AllJobsBO DisplayHOPAllJob(int iJobPostingId)
        {
            DataSet objDataSet = null;
            AllJobsBO objAllJobsBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobPostingId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobPostingId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcHOPViewAllJob, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objAllJobsBO = new AllJobsBO();
                    objAllJobsBO.JobName = objDataSet.Tables[0].Rows[0][0].ToString();
                    objAllJobsBO.JobCode = objDataSet.Tables[0].Rows[0][1].ToString();
                    objAllJobsBO.JobDescription = objDataSet.Tables[0].Rows[0][2].ToString();
                    objAllJobsBO.NoOfPositions = objDataSet.Tables[0].Rows[0][3].ToString();
                    objAllJobsBO.JobLocation = objDataSet.Tables[0].Rows[0][4].ToString();
                    objAllJobsBO.JobTimings = objDataSet.Tables[0].Rows[0][5].ToString();
                    objAllJobsBO.JobDuration = objDataSet.Tables[0].Rows[0][6].ToString();
                    objAllJobsBO.DonorProgramName = objDataSet.Tables[0].Rows[0][7].ToString();
                    objAllJobsBO.Qualification = objDataSet.Tables[0].Rows[0][8].ToString();
                    objAllJobsBO.Experience = objDataSet.Tables[0].Rows[0][9].ToString();
                    objAllJobsBO.Skills = objDataSet.Tables[0].Rows[0][10].ToString();
                    objAllJobsBO.Status = objDataSet.Tables[0].Rows[0][11].ToString();
                    objAllJobsBO.HROffice_Comments = objDataSet.Tables[0].Rows[0][12].ToString();
                    objAllJobsBO.HOP_Comments = objDataSet.Tables[0].Rows[0][13].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DisplayHOPAllJob");
                throw ex;
            }
            return objAllJobsBO;
        }
    }
}
