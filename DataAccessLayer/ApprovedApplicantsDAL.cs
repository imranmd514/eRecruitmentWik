using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlTypes;
using System.Xml.Linq;
using Utils;


namespace DataAccessLayer
{
    public class ApprovedApplicantsDAL
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

        public static string ProcCommunicationList = "usp_SCH_DropDownCommunicationSkill";
        public List<CommonDropDownBO> CommunicationSkillList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcCommunicationList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "CommunicationSkillList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }


        public static string ProcExperienceList = "usp_SCH_DropDownApplicantExperience";
        public List<CommonDropDownBO> ExperienceList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcExperienceList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "ExperienceList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }


        public static string ProcRatingnList = "usp_SCH_DropDownApplicantRating";
        public List<CommonDropDownBO> RatingList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcRatingnList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "RatingList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }



        public static string ProcMonthsList = "usp_SCH_DropDownMonths";
        public List<CommonDropDownBO> getMonthsList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                //ProcParameterBO objParameterBO = new ProcParameterBO();
                //objParameterBO.Direction = ParameterDirection.Input;
                //objParameterBO.ParameterName = "@iApplicantExperienceId";
                //objParameterBO.dbType = DbType.Int32;
                //objParameterBO.ParameterValue = iApplicantExperienceId;
                //objProcParameterBOList.Add(objParameterBO);

                objDataSet = objDBAccess.execuitDataSet(ProcMonthsList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "getMonthsList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }



        public static string ProcYearList = "usp_SCH_DropDownYear";
        public List<CommonDropDownBO> getYearList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                //ProcParameterBO objParameterBO = new ProcParameterBO();
                //objParameterBO.Direction = ParameterDirection.Input;
                //objParameterBO.ParameterName = "@iApplicantExperienceId";
                //objParameterBO.dbType = DbType.Int32;
                //objParameterBO.ParameterValue = iApplicantExperienceId;
                //objProcParameterBOList.Add(objParameterBO);

                objDataSet = objDBAccess.execuitDataSet(ProcYearList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "getYearList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }


        public static string ProcShortListApplicantsList = "usp_SCH_ShortlistedApplicantsList";
        public List<ApprovedApplicantsBO> getApprovedApplicants(int iJobId)
        {
            DataSet objDataSet = null;
            ApprovedApplicantsBO objApprovedApplicantsBO = null;
            List<ApprovedApplicantsBO> objApprovedApplicantsBOList = new List<ApprovedApplicantsBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objParameterBO = new ProcParameterBO();
                objParameterBO.Direction = ParameterDirection.Input;
                objParameterBO.ParameterName = "@iJobId";
                objParameterBO.dbType = DbType.Int32;
                objParameterBO.ParameterValue = iJobId;
                objProcParameterBOList.Add(objParameterBO);

                objDataSet = objDBAccess.execuitDataSet(ProcShortListApplicantsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApprovedApplicantsBO = new ApprovedApplicantsBO();
                        objApprovedApplicantsBO.AppliedJobId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApprovedApplicantsBO.FirstName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objApprovedApplicantsBO.Gender = objDataSet.Tables[0].Rows[i][2].ToString();
                        objApprovedApplicantsBO.DateOfBirth = objDataSet.Tables[0].Rows[i][3].ToString();
                        objApprovedApplicantsBO.PhoneNumber = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApprovedApplicantsBO.JobName = objDataSet.Tables[0].Rows[i][5].ToString();
                        objApprovedApplicantsBO.Status = objDataSet.Tables[0].Rows[i][6].ToString();
                        objApprovedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][7].ToString());
                        //objApprovedApplicantsBO.JobId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][8].ToString());
                        objApprovedApplicantsBOList.Add(objApprovedApplicantsBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getApprovedApplicants");
                throw ex;
            }
            return objApprovedApplicantsBOList;
        }

        public static string ProcSaveSelectedApplicant = "usp_SCH_saveSelectedApplicantEvaluationForm";
        public string saveSelectedApplicant(EvaluationFormBO objEvaluationFormBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantEvaluationId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.ApplicantEvaluationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iJobCodeId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.JobPostingId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iProgramNameId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.DonorProgramId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strHighestQualification";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objEvaluationFormBO.HighestQualification;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iCommunicationSkillsId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.CommunicationSkillsId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iExperienceId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.ExperienceId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iYearId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.YearId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iMonthId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.MonthId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strStatus";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objEvaluationFormBO.Status;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objEvaluationFormBO.IsActive;
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

                objDBAccess.executeNonQuery(ProcSaveSelectedApplicant, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "saveSelectedApplicant");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcSaveRejectedApplicant = "usp_SCH_saveRejectedApplicantEvaluationForm";
        public string saveRejectedApplicant(EvaluationFormBO objEvaluationFormBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantEvaluationId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.ApplicantEvaluationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iJobCodeId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.JobPostingId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iProgramNameId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.DonorProgramId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strHighestQualification";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objEvaluationFormBO.HighestQualification;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iCommunicationSkillsId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.CommunicationSkillsId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iExperienceId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.ExperienceId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iYearId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.YearId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iMonthId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.MonthId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strStatus";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objEvaluationFormBO.Status;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objEvaluationFormBO.IsActive;
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

                objDBAccess.executeNonQuery(ProcSaveRejectedApplicant, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "saveRejectedApplicant");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        public static string ProcEditShortListedApplicant = "usp_EditShortListApplicantList";
        public ApprovedApplicantsBO EditShortList(int iAppliedJobId, int iApplicantId)
        {
            DataSet objDataSet = null;
            ApprovedApplicantsBO objApprovedApplicantsBO = null;
            ApplicantRelationBO objApplicantRelationBO = null;
            LanguageSpokenBO objLanguageSpokenBO = null;
            ApplicantQualificationBO objApplicantQualificationBO = null;
            ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO = null;
            ApplicantRefereesBO objApplicantRefereesBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iAppliedJobId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iAppliedJobId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditShortListedApplicant, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objApprovedApplicantsBO = new ApprovedApplicantsBO();
                    objApprovedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objApprovedApplicantsBO.Title = objDataSet.Tables[0].Rows[0][1].ToString();
                    objApprovedApplicantsBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objApprovedApplicantsBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objApprovedApplicantsBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
                    objApprovedApplicantsBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
                    objApprovedApplicantsBO.Gender = objDataSet.Tables[0].Rows[0][6].ToString();
                    objApprovedApplicantsBO.IdType = objDataSet.Tables[0].Rows[0][7].ToString();
                    objApprovedApplicantsBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
                    objApprovedApplicantsBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();
                    objApprovedApplicantsBO.Country = objDataSet.Tables[0].Rows[0][10].ToString();
                    objApprovedApplicantsBO.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
                    objApprovedApplicantsBO.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
                    objApprovedApplicantsBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
                    objApprovedApplicantsBO.MotherTongue = objDataSet.Tables[0].Rows[0][14].ToString();
                    objApprovedApplicantsBO.Nationality = objDataSet.Tables[0].Rows[0][15].ToString();
                    objApprovedApplicantsBO.County = objDataSet.Tables[0].Rows[0][16].ToString();
                    objApprovedApplicantsBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][17].ToString();
                    objApprovedApplicantsBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][18].ToString();
                    objApprovedApplicantsBO.CV = objDataSet.Tables[0].Rows[0][19].ToString();
                    objApprovedApplicantsBO.CVSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
                    objApprovedApplicantsBO.SpecialNeed = objDataSet.Tables[0].Rows[0][21].ToString();
                    objApprovedApplicantsBO.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][22].ToString();
                    objApprovedApplicantsBO.Address = objDataSet.Tables[0].Rows[0][23].ToString();
                    objApprovedApplicantsBO.Photo = objDataSet.Tables[0].Rows[0][24].ToString();
                    objApprovedApplicantsBO.PhotoSavedName = objDataSet.Tables[0].Rows[0][25].ToString();
                    objApprovedApplicantsBO.JobId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][26].ToString());
                    objApprovedApplicantsBO.AppliedJobId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][27].ToString());


                    if (objDataSet != null && objDataSet.Tables[1].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantRelationList = new List<ApplicantRelationBO>();
                        for (int i = 0; i < objDataSet.Tables[1].Rows.Count; i++)
                        {
                            objApplicantRelationBO = new ApplicantRelationBO();
                            objApplicantRelationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[1].Rows[i][0].ToString());
                            objApplicantRelationBO.RelationId = Convert.ToInt32(objDataSet.Tables[1].Rows[i][1].ToString());
                            objApplicantRelationBO.AnyoneWorkinWIK = objDataSet.Tables[1].Rows[i][2].ToString();
                            objApplicantRelationBO.RelativeName = objDataSet.Tables[1].Rows[i][3].ToString();
                            objApplicantRelationBO.Relationship = objDataSet.Tables[1].Rows[i][4].ToString();
                            objApprovedApplicantsBO.ApplicantRelationList.Add(objApplicantRelationBO);
                        }
                    }

                    if (objDataSet != null && objDataSet.Tables[2].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantLanguageList = new List<LanguageSpokenBO>();
                        for (int i = 0; i < objDataSet.Tables[2].Rows.Count; i++)
                        {
                            objLanguageSpokenBO = new LanguageSpokenBO();
                            objLanguageSpokenBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[2].Rows[i][0].ToString());
                            objLanguageSpokenBO.LanguageSpokenId = Convert.ToInt32(objDataSet.Tables[2].Rows[i][1].ToString());
                            objLanguageSpokenBO.Language = objDataSet.Tables[2].Rows[i][2].ToString();
                            objLanguageSpokenBO.LanguageRead = objDataSet.Tables[2].Rows[i][3].ToString();
                            objLanguageSpokenBO.Write = objDataSet.Tables[2].Rows[i][4].ToString();
                            objLanguageSpokenBO.Speak = objDataSet.Tables[2].Rows[i][5].ToString();
                            objLanguageSpokenBO.Understand = objDataSet.Tables[2].Rows[i][6].ToString();
                            objApprovedApplicantsBO.ApplicantLanguageList.Add(objLanguageSpokenBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[3].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantQualificationList = new List<ApplicantQualificationBO>();
                        for (int i = 0; i < objDataSet.Tables[3].Rows.Count; i++)
                        {
                            objApplicantQualificationBO = new ApplicantQualificationBO();
                            objApplicantQualificationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[3].Rows[i][0].ToString());
                            objApplicantQualificationBO.ApplicantQualificationId = Convert.ToInt32(objDataSet.Tables[3].Rows[i][1].ToString());
                            objApplicantQualificationBO.AcademicQualification = objDataSet.Tables[3].Rows[i][2].ToString();
                            objApplicantQualificationBO.AcademicQualificationAttachment = objDataSet.Tables[3].Rows[i][3].ToString();
                            objApplicantQualificationBO.AttachmentSavedName = objDataSet.Tables[3].Rows[i][4].ToString();
                            objApplicantQualificationBO.StartDate = objDataSet.Tables[3].Rows[i][5].ToString();
                            objApplicantQualificationBO.EndDate = objDataSet.Tables[3].Rows[i][6].ToString();
                            objApplicantQualificationBO.Discipline = objDataSet.Tables[3].Rows[i][7].ToString();
                            objApplicantQualificationBO.University = objDataSet.Tables[3].Rows[i][8].ToString();
                            objApplicantQualificationBO.CreditScoreClass = objDataSet.Tables[3].Rows[i][9].ToString();
                            objApprovedApplicantsBO.ApplicantQualificationList.Add(objApplicantQualificationBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[4].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantEmploymentList = new List<ApplicantEmploymentHistoryBO>();
                        for (int i = 0; i < objDataSet.Tables[4].Rows.Count; i++)
                        {
                            objApplicantEmploymentHistoryBO = new ApplicantEmploymentHistoryBO();
                            objApplicantEmploymentHistoryBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[4].Rows[i][0].ToString());
                            objApplicantEmploymentHistoryBO.EmploymentHistoryId = Convert.ToInt32(objDataSet.Tables[4].Rows[i][1].ToString());
                            objApplicantEmploymentHistoryBO.EmployerName = objDataSet.Tables[4].Rows[i][2].ToString();
                            objApplicantEmploymentHistoryBO.TypeOfIndustry = objDataSet.Tables[4].Rows[i][3].ToString();
                            objApplicantEmploymentHistoryBO.JobTitle = objDataSet.Tables[4].Rows[i][4].ToString();
                            objApplicantEmploymentHistoryBO.EmpStartDate = objDataSet.Tables[4].Rows[i][5].ToString();
                            objApplicantEmploymentHistoryBO.EmpEndDate = objDataSet.Tables[4].Rows[i][6].ToString();
                            objApplicantEmploymentHistoryBO.Responsibility = objDataSet.Tables[4].Rows[i][7].ToString();
                            objApplicantEmploymentHistoryBO.NoticePeriod = objDataSet.Tables[4].Rows[i][8].ToString();
                            objApplicantEmploymentHistoryBO.Reasonforleaving = objDataSet.Tables[4].Rows[i][9].ToString();
                            objApprovedApplicantsBO.ApplicantEmploymentList.Add(objApplicantEmploymentHistoryBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[5].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantRefereesList = new List<ApplicantRefereesBO>();
                        for (int i = 0; i < objDataSet.Tables[5].Rows.Count; i++)
                        {
                            objApplicantRefereesBO = new ApplicantRefereesBO();
                            objApplicantRefereesBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[5].Rows[i][0].ToString());
                            objApplicantRefereesBO.RefereesId = Convert.ToInt32(objDataSet.Tables[5].Rows[i][1].ToString());
                            objApplicantRefereesBO.EmpFirstName = objDataSet.Tables[5].Rows[i][2].ToString();
                            objApplicantRefereesBO.SecondName = objDataSet.Tables[5].Rows[i][3].ToString();
                            objApplicantRefereesBO.Position = objDataSet.Tables[5].Rows[i][4].ToString();
                            objApplicantRefereesBO.RelationshipTOApplicant = objDataSet.Tables[5].Rows[i][5].ToString();
                            objApplicantRefereesBO.NameOfTheOrganization = objDataSet.Tables[5].Rows[i][6].ToString();
                            objApplicantRefereesBO.TelephoneContact = objDataSet.Tables[5].Rows[i][7].ToString();
                            objApplicantRefereesBO.EmpEmailAddress = objDataSet.Tables[5].Rows[i][8].ToString();
                            objApprovedApplicantsBO.ApplicantRefereesList.Add(objApplicantRefereesBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[6].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[6].Rows[0][0].ToString());
                        objApprovedApplicantsBO.ApplicantMotivationId = Convert.ToInt32(objDataSet.Tables[6].Rows[0][1].ToString());
                        objApprovedApplicantsBO.MembershipData = objDataSet.Tables[6].Rows[0][2].ToString();
                        objApprovedApplicantsBO.NameofProfessionalBody = objDataSet.Tables[6].Rows[0][3].ToString();
                        objApprovedApplicantsBO.MembershipNumber = objDataSet.Tables[6].Rows[0][4].ToString();
                        objApprovedApplicantsBO.ValidityData = objDataSet.Tables[6].Rows[0][5].ToString();
                        objApprovedApplicantsBO.JobDescription = objDataSet.Tables[6].Rows[0][6].ToString();
                        objApprovedApplicantsBO.Referer = objDataSet.Tables[6].Rows[0][7].ToString();
                        objApprovedApplicantsBO.ApplicationNote = objDataSet.Tables[6].Rows[0][8].ToString();
                    }
                    if (objDataSet != null && objDataSet.Tables[7].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[7].Rows[0][0].ToString());
                        objApprovedApplicantsBO.TerminatedId = objDataSet.Tables[7].Rows[0][1].ToString();
                        objApprovedApplicantsBO.Terminatation = objDataSet.Tables[7].Rows[0][2].ToString();
                        objApprovedApplicantsBO.MisconductId = objDataSet.Tables[7].Rows[0][3].ToString();
                        objApprovedApplicantsBO.Misconduct = objDataSet.Tables[7].Rows[0][4].ToString();
                        objApprovedApplicantsBO.ManagementId = objDataSet.Tables[7].Rows[0][5].ToString();
                        objApprovedApplicantsBO.Management = objDataSet.Tables[7].Rows[0][6].ToString();
                        objApprovedApplicantsBO.InvestigationId = objDataSet.Tables[7].Rows[0][7].ToString();
                        objApprovedApplicantsBO.Investigation = objDataSet.Tables[7].Rows[0][8].ToString();


                        objApprovedApplicantsBO.CriminalOffenceId = objDataSet.Tables[7].Rows[0][9].ToString();
                        objApprovedApplicantsBO.CriminalOffence = objDataSet.Tables[7].Rows[0][10].ToString();
                        objApprovedApplicantsBO.ConvictionsId = objDataSet.Tables[7].Rows[0][11].ToString();
                        objApprovedApplicantsBO.Convictions = objDataSet.Tables[7].Rows[0][12].ToString();
                        objApprovedApplicantsBO.CorruptionId = objDataSet.Tables[7].Rows[0][13].ToString();
                        objApprovedApplicantsBO.Corruption = objDataSet.Tables[7].Rows[0][14].ToString();
                        objApprovedApplicantsBO.DisciplinaryId = objDataSet.Tables[7].Rows[0][15].ToString();
                        objApprovedApplicantsBO.Disciplinary = objDataSet.Tables[7].Rows[0][16].ToString();
                        objApprovedApplicantsBO.RelationToChildId = objDataSet.Tables[7].Rows[0][17].ToString();
                        objApprovedApplicantsBO.RelationToChild = objDataSet.Tables[7].Rows[0][18].ToString();
                        objApprovedApplicantsBO.RelationToAdultId = objDataSet.Tables[7].Rows[0][19].ToString();
                        objApprovedApplicantsBO.RelationToAdult = objDataSet.Tables[7].Rows[0][20].ToString();
                        objApprovedApplicantsBO.RelativeId = objDataSet.Tables[7].Rows[0][21].ToString();
                        objApprovedApplicantsBO.DealingsWithWIKId = objDataSet.Tables[7].Rows[0][22].ToString();
                        objApprovedApplicantsBO.DealingsWithWIK = objDataSet.Tables[7].Rows[0][23].ToString();
                        objApprovedApplicantsBO.Declarationinfo = Convert.ToBoolean(objDataSet.Tables[7].Rows[0][24].ToString());
                        objApprovedApplicantsBO.Statement = Convert.ToBoolean(objDataSet.Tables[7].Rows[0][25].ToString());
                        objApprovedApplicantsBO.DeclarationID = Convert.ToInt32(objDataSet.Tables[7].Rows[0][26].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditShortList");
                throw ex;
            }
            return objApprovedApplicantsBO;
        }


        //public static string ProcEditShortListApplicant = "usp_EditShortListApplicantList";
        //public ApprovedApplicantsBO EditShortList(int iAppliedJobId, int A_iApplicantId)
        //{
        //    DataSet objDataSet = null;
        //    ApprovedApplicantsBO objApprovedApplicantsBO = null;
        //    List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

        //    try
        //    {
        //        ProcParameterBO objDbParameter = new ProcParameterBO();
        //        objDbParameter.Direction = ParameterDirection.Input;
        //        objDbParameter.ParameterName = "@iAppliedJobId";
        //        objDbParameter.dbType = DbType.Int32;
        //        objDbParameter.ParameterValue = iAppliedJobId;
        //        objProcParameterBOList.Add(objDbParameter);

        //        objDbParameter = new ProcParameterBO();
        //        objDbParameter.Direction = ParameterDirection.Input;
        //        objDbParameter.ParameterName = "@iApplicantId";
        //        objDbParameter.dbType = DbType.Int32;
        //        objDbParameter.ParameterValue = A_iApplicantId;
        //        objProcParameterBOList.Add(objDbParameter);


        //        objDataSet = objDBAccess.execuitDataSet(ProcEditShortListApplicant, ref objProcParameterBOList);
        //        if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            objApprovedApplicantsBO = new ApprovedApplicantsBO();
        //            objApprovedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
        //            objApprovedApplicantsBO.FirstName = objDataSet.Tables[0].Rows[0][1].ToString();
        //            objApprovedApplicantsBO.MiddleName = objDataSet.Tables[0].Rows[0][2].ToString();
        //            objApprovedApplicantsBO.LastName = objDataSet.Tables[0].Rows[0][3].ToString();
        //            objApprovedApplicantsBO.PhoneNumber = objDataSet.Tables[0].Rows[0][4].ToString();
        //            objApprovedApplicantsBO.EmailAddress = objDataSet.Tables[0].Rows[0][5].ToString();
        //            objApprovedApplicantsBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][6].ToString();
        //            objApprovedApplicantsBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][7].ToString();
        //            objApprovedApplicantsBO.Address = objDataSet.Tables[0].Rows[0][8].ToString();
        //            objApprovedApplicantsBO.CV = objDataSet.Tables[0].Rows[0][9].ToString();
        //            objApprovedApplicantsBO.CVSavedName = objDataSet.Tables[0].Rows[0][10].ToString();
        //            objApprovedApplicantsBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][11].ToString();
        //            objApprovedApplicantsBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][12].ToString();
        //            objApprovedApplicantsBO.Comments = objDataSet.Tables[0].Rows[0][13].ToString();
        //            objApprovedApplicantsBO.Bachelors = objDataSet.Tables[0].Rows[0][14].ToString();
        //            objApprovedApplicantsBO.BachelorsSavedName = objDataSet.Tables[0].Rows[0][15].ToString();
        //            objApprovedApplicantsBO.Diploma = objDataSet.Tables[0].Rows[0][16].ToString();
        //            objApprovedApplicantsBO.DiplomaSavedName = objDataSet.Tables[0].Rows[0][17].ToString();
        //            objApprovedApplicantsBO.MSC = objDataSet.Tables[0].Rows[0][18].ToString();
        //            objApprovedApplicantsBO.MSCSavedName = objDataSet.Tables[0].Rows[0][19].ToString();
        //            objApprovedApplicantsBO.PHD = objDataSet.Tables[0].Rows[0][20].ToString();
        //            objApprovedApplicantsBO.PHDSavedName = objDataSet.Tables[0].Rows[0][21].ToString();
        //            objApprovedApplicantsBO.QuaStartDate = objDataSet.Tables[0].Rows[0][22].ToString();
        //            objApprovedApplicantsBO.QuaEndDate = objDataSet.Tables[0].Rows[0][23].ToString();
        //            objApprovedApplicantsBO.Discipline = objDataSet.Tables[0].Rows[0][24].ToString();
        //            objApprovedApplicantsBO.University = objDataSet.Tables[0].Rows[0][25].ToString();
        //            objApprovedApplicantsBO.QuaNationality = objDataSet.Tables[0].Rows[0][26].ToString();
        //            objApprovedApplicantsBO.Degree = objDataSet.Tables[0].Rows[0][27].ToString();
        //            objApprovedApplicantsBO.Class = objDataSet.Tables[0].Rows[0][28].ToString();
        //            objApprovedApplicantsBO.EmployerName = objDataSet.Tables[0].Rows[0][29].ToString();
        //            objApprovedApplicantsBO.TypeOfIndustry = objDataSet.Tables[0].Rows[0][30].ToString();
        //            objApprovedApplicantsBO.TelephoneContact = objDataSet.Tables[0].Rows[0][31].ToString();
        //            objApprovedApplicantsBO.JobTitle = objDataSet.Tables[0].Rows[0][32].ToString();
        //            objApprovedApplicantsBO.City = objDataSet.Tables[0].Rows[0][33].ToString();
        //            objApprovedApplicantsBO.EmpStartDate = objDataSet.Tables[0].Rows[0][34].ToString();
        //            objApprovedApplicantsBO.EmpEndDate = objDataSet.Tables[0].Rows[0][35].ToString();
        //            objApprovedApplicantsBO.Responsibility = objDataSet.Tables[0].Rows[0][36].ToString();
        //            objApprovedApplicantsBO.MonthlySalary = objDataSet.Tables[0].Rows[0][37].ToString();
        //            objApprovedApplicantsBO.NoticePeriod = objDataSet.Tables[0].Rows[0][38].ToString();
        //            objApprovedApplicantsBO.JobId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][39].ToString());
        //            objApprovedApplicantsBO.AppliedJobId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][40].ToString());

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionError.Error_Log(ex, "EditShortList");
        //        throw ex;
        //    }
        //    return objApprovedApplicantsBO;
        //}


        public static string ProcViewShortListedApplicant = "usp_SCH_ViewApprovedApplicantDetailsList";
        public ApprovedApplicantsBO DisplayApprovedApplicant(int iAppliedJobId , int iApplicantId)
        {
            DataSet objDataSet = null;
            ApprovedApplicantsBO objApprovedApplicantsBO = null;
            ApplicantRelationBO objApplicantRelationBO = null;
            LanguageSpokenBO objLanguageSpokenBO = null;
            ApplicantQualificationBO objApplicantQualificationBO = null;
            ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO = null;
            ApplicantRefereesBO objApplicantRefereesBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iAppliedJobId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iAppliedJobId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewShortListedApplicant, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objApprovedApplicantsBO = new ApprovedApplicantsBO();
                    objApprovedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objApprovedApplicantsBO.Title = objDataSet.Tables[0].Rows[0][1].ToString();
                    objApprovedApplicantsBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objApprovedApplicantsBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objApprovedApplicantsBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
                    objApprovedApplicantsBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
                    objApprovedApplicantsBO.Gender = objDataSet.Tables[0].Rows[0][6].ToString();
                    objApprovedApplicantsBO.IdType = objDataSet.Tables[0].Rows[0][7].ToString();
                    objApprovedApplicantsBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
                    objApprovedApplicantsBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();
                    objApprovedApplicantsBO.Country = objDataSet.Tables[0].Rows[0][10].ToString();
                    objApprovedApplicantsBO.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
                    objApprovedApplicantsBO.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
                    objApprovedApplicantsBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
                    objApprovedApplicantsBO.MotherTongue = objDataSet.Tables[0].Rows[0][14].ToString();
                    objApprovedApplicantsBO.Nationality = objDataSet.Tables[0].Rows[0][15].ToString();
                    objApprovedApplicantsBO.County = objDataSet.Tables[0].Rows[0][16].ToString();
                    objApprovedApplicantsBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][17].ToString();
                    objApprovedApplicantsBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][18].ToString();
                    objApprovedApplicantsBO.CV = objDataSet.Tables[0].Rows[0][19].ToString();
                    objApprovedApplicantsBO.CVSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
                    objApprovedApplicantsBO.SpecialNeed = objDataSet.Tables[0].Rows[0][21].ToString();
                    objApprovedApplicantsBO.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][22].ToString();
                    objApprovedApplicantsBO.Address = objDataSet.Tables[0].Rows[0][23].ToString();
                    objApprovedApplicantsBO.Photo = objDataSet.Tables[0].Rows[0][24].ToString();
                    objApprovedApplicantsBO.PhotoSavedName = objDataSet.Tables[0].Rows[0][25].ToString();

                    if (objDataSet != null && objDataSet.Tables[1].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantRelationList = new List<ApplicantRelationBO>();
                        for (int i = 0; i < objDataSet.Tables[1].Rows.Count; i++)
                        {
                            objApplicantRelationBO = new ApplicantRelationBO();
                            objApplicantRelationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[1].Rows[i][0].ToString());
                            objApplicantRelationBO.RelationId = Convert.ToInt32(objDataSet.Tables[1].Rows[i][1].ToString());
                            objApplicantRelationBO.AnyoneWorkinWIK = objDataSet.Tables[1].Rows[i][2].ToString();
                            objApplicantRelationBO.RelativeName = objDataSet.Tables[1].Rows[i][3].ToString();
                            objApplicantRelationBO.Relationship = objDataSet.Tables[1].Rows[i][4].ToString();
                            objApprovedApplicantsBO.ApplicantRelationList.Add(objApplicantRelationBO);
                        }
                    }

                    if (objDataSet != null && objDataSet.Tables[2].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantLanguageList = new List<LanguageSpokenBO>();
                        for (int i = 0; i < objDataSet.Tables[2].Rows.Count; i++)
                        {
                            objLanguageSpokenBO = new LanguageSpokenBO();
                            objLanguageSpokenBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[2].Rows[i][0].ToString());
                            objLanguageSpokenBO.LanguageSpokenId = Convert.ToInt32(objDataSet.Tables[2].Rows[i][1].ToString());
                            objLanguageSpokenBO.Language = objDataSet.Tables[2].Rows[i][2].ToString();
                            objLanguageSpokenBO.LanguageRead = objDataSet.Tables[2].Rows[i][3].ToString();
                            objLanguageSpokenBO.Write = objDataSet.Tables[2].Rows[i][4].ToString();
                            objLanguageSpokenBO.Speak = objDataSet.Tables[2].Rows[i][5].ToString();
                            objLanguageSpokenBO.Understand = objDataSet.Tables[2].Rows[i][6].ToString();
                            objApprovedApplicantsBO.ApplicantLanguageList.Add(objLanguageSpokenBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[3].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantQualificationList = new List<ApplicantQualificationBO>();
                        for (int i = 0; i < objDataSet.Tables[3].Rows.Count; i++)
                        {
                            objApplicantQualificationBO = new ApplicantQualificationBO();
                            objApplicantQualificationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[3].Rows[i][0].ToString());
                            objApplicantQualificationBO.ApplicantQualificationId = Convert.ToInt32(objDataSet.Tables[3].Rows[i][1].ToString());
                            objApplicantQualificationBO.AcademicQualification = objDataSet.Tables[3].Rows[i][2].ToString();
                            objApplicantQualificationBO.AcademicQualificationAttachment = objDataSet.Tables[3].Rows[i][3].ToString();
                            objApplicantQualificationBO.AttachmentSavedName = objDataSet.Tables[3].Rows[i][4].ToString();
                            objApplicantQualificationBO.StartDate = objDataSet.Tables[3].Rows[i][5].ToString();
                            objApplicantQualificationBO.EndDate = objDataSet.Tables[3].Rows[i][6].ToString();
                            objApplicantQualificationBO.Discipline = objDataSet.Tables[3].Rows[i][7].ToString();
                            objApplicantQualificationBO.University = objDataSet.Tables[3].Rows[i][8].ToString();
                            objApplicantQualificationBO.CreditScoreClass = objDataSet.Tables[3].Rows[i][9].ToString();
                            objApprovedApplicantsBO.ApplicantQualificationList.Add(objApplicantQualificationBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[4].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantEmploymentList = new List<ApplicantEmploymentHistoryBO>();
                        for (int i = 0; i < objDataSet.Tables[4].Rows.Count; i++)
                        {
                            objApplicantEmploymentHistoryBO = new ApplicantEmploymentHistoryBO();
                            objApplicantEmploymentHistoryBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[4].Rows[i][0].ToString());
                            objApplicantEmploymentHistoryBO.EmploymentHistoryId = Convert.ToInt32(objDataSet.Tables[4].Rows[i][1].ToString());
                            objApplicantEmploymentHistoryBO.EmployerName = objDataSet.Tables[4].Rows[i][2].ToString();
                            objApplicantEmploymentHistoryBO.TypeOfIndustry = objDataSet.Tables[4].Rows[i][3].ToString();
                            objApplicantEmploymentHistoryBO.JobTitle = objDataSet.Tables[4].Rows[i][4].ToString();
                            objApplicantEmploymentHistoryBO.EmpStartDate = objDataSet.Tables[4].Rows[i][5].ToString();
                            objApplicantEmploymentHistoryBO.EmpEndDate = objDataSet.Tables[4].Rows[i][6].ToString();
                            objApplicantEmploymentHistoryBO.Responsibility = objDataSet.Tables[4].Rows[i][7].ToString();
                            objApplicantEmploymentHistoryBO.NoticePeriod = objDataSet.Tables[4].Rows[i][8].ToString();
                            objApplicantEmploymentHistoryBO.Reasonforleaving = objDataSet.Tables[4].Rows[i][9].ToString();
                            objApprovedApplicantsBO.ApplicantEmploymentList.Add(objApplicantEmploymentHistoryBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[5].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantRefereesList = new List<ApplicantRefereesBO>();
                        for (int i = 0; i < objDataSet.Tables[5].Rows.Count; i++)
                        {
                            objApplicantRefereesBO = new ApplicantRefereesBO();
                            objApplicantRefereesBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[5].Rows[i][0].ToString());
                            objApplicantRefereesBO.RefereesId = Convert.ToInt32(objDataSet.Tables[5].Rows[i][1].ToString());
                            objApplicantRefereesBO.EmpFirstName = objDataSet.Tables[5].Rows[i][2].ToString();
                            objApplicantRefereesBO.SecondName = objDataSet.Tables[5].Rows[i][3].ToString();
                            objApplicantRefereesBO.Position = objDataSet.Tables[5].Rows[i][4].ToString();
                            objApplicantRefereesBO.RelationshipTOApplicant = objDataSet.Tables[5].Rows[i][5].ToString();
                            objApplicantRefereesBO.NameOfTheOrganization = objDataSet.Tables[5].Rows[i][6].ToString();
                            objApplicantRefereesBO.TelephoneContact = objDataSet.Tables[5].Rows[i][7].ToString();
                            objApplicantRefereesBO.EmpEmailAddress = objDataSet.Tables[5].Rows[i][8].ToString();
                            objApprovedApplicantsBO.ApplicantRefereesList.Add(objApplicantRefereesBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[6].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[6].Rows[0][0].ToString());
                        objApprovedApplicantsBO.ApplicantMotivationId = Convert.ToInt32(objDataSet.Tables[6].Rows[0][1].ToString());
                        objApprovedApplicantsBO.MembershipData = objDataSet.Tables[6].Rows[0][2].ToString();
                        objApprovedApplicantsBO.NameofProfessionalBody = objDataSet.Tables[6].Rows[0][3].ToString();
                        objApprovedApplicantsBO.MembershipNumber = objDataSet.Tables[6].Rows[0][4].ToString();
                        objApprovedApplicantsBO.ValidityData = objDataSet.Tables[6].Rows[0][5].ToString();
                        objApprovedApplicantsBO.JobDescription = objDataSet.Tables[6].Rows[0][6].ToString();
                        objApprovedApplicantsBO.Referer = objDataSet.Tables[6].Rows[0][7].ToString();
                        objApprovedApplicantsBO.ApplicationNote = objDataSet.Tables[6].Rows[0][8].ToString();
                    }
                    if (objDataSet != null && objDataSet.Tables[7].Rows.Count > 0)
                    {
                        objApprovedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[7].Rows[0][0].ToString());
                        objApprovedApplicantsBO.TerminatedId = objDataSet.Tables[7].Rows[0][1].ToString();
                        objApprovedApplicantsBO.Terminatation = objDataSet.Tables[7].Rows[0][2].ToString();
                        objApprovedApplicantsBO.MisconductId = objDataSet.Tables[7].Rows[0][3].ToString();
                        objApprovedApplicantsBO.Misconduct = objDataSet.Tables[7].Rows[0][4].ToString();
                        objApprovedApplicantsBO.ManagementId = objDataSet.Tables[7].Rows[0][5].ToString();
                        objApprovedApplicantsBO.Management = objDataSet.Tables[7].Rows[0][6].ToString();
                        objApprovedApplicantsBO.InvestigationId = objDataSet.Tables[7].Rows[0][7].ToString();
                        objApprovedApplicantsBO.Investigation = objDataSet.Tables[7].Rows[0][8].ToString();


                        objApprovedApplicantsBO.CriminalOffenceId = objDataSet.Tables[7].Rows[0][9].ToString();
                        objApprovedApplicantsBO.CriminalOffence = objDataSet.Tables[7].Rows[0][10].ToString();
                        objApprovedApplicantsBO.ConvictionsId = objDataSet.Tables[7].Rows[0][11].ToString();
                        objApprovedApplicantsBO.Convictions = objDataSet.Tables[7].Rows[0][12].ToString();
                        objApprovedApplicantsBO.CorruptionId = objDataSet.Tables[7].Rows[0][13].ToString();
                        objApprovedApplicantsBO.Corruption = objDataSet.Tables[7].Rows[0][14].ToString();
                        objApprovedApplicantsBO.DisciplinaryId = objDataSet.Tables[7].Rows[0][15].ToString();
                        objApprovedApplicantsBO.Disciplinary = objDataSet.Tables[7].Rows[0][16].ToString();
                        objApprovedApplicantsBO.RelationToChildId = objDataSet.Tables[7].Rows[0][17].ToString();
                        objApprovedApplicantsBO.RelationToChild = objDataSet.Tables[7].Rows[0][18].ToString();
                        objApprovedApplicantsBO.RelationToAdultId = objDataSet.Tables[7].Rows[0][19].ToString();
                        objApprovedApplicantsBO.RelationToAdult = objDataSet.Tables[7].Rows[0][20].ToString();
                        objApprovedApplicantsBO.RelativeId = objDataSet.Tables[7].Rows[0][21].ToString();
                        objApprovedApplicantsBO.DealingsWithWIKId = objDataSet.Tables[7].Rows[0][22].ToString();
                        objApprovedApplicantsBO.DealingsWithWIK = objDataSet.Tables[7].Rows[0][23].ToString();
                        objApprovedApplicantsBO.Declarationinfo = Convert.ToBoolean(objDataSet.Tables[7].Rows[0][24].ToString());
                        objApprovedApplicantsBO.Statement = Convert.ToBoolean(objDataSet.Tables[7].Rows[0][25].ToString());

                        objApprovedApplicantsBO.DeclarationID = Convert.ToInt32(objDataSet.Tables[7].Rows[0][26].ToString());
                    }


                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DisplayApprovedApplicant");
                throw ex;
            }
            return objApprovedApplicantsBO;
        }

        public static string ProcGetEvaluationApplicantDetails = "usp_EvaluationApplicantDetails";
        public EvaluationFormBO GetEvaluationApplicantDetails(int iApplicantId, int iJobId)
        {
            DataSet objDataSet = null;
            EvaluationFormBO objEvaluationFormBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcGetEvaluationApplicantDetails, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objEvaluationFormBO = new EvaluationFormBO();
                    objEvaluationFormBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objEvaluationFormBO.ApplicantName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objEvaluationFormBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][2].ToString());
                    objEvaluationFormBO.JobCode = objDataSet.Tables[0].Rows[0][3].ToString();
                    objEvaluationFormBO.DonorProgramId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][4].ToString());
                    objEvaluationFormBO.ProgramName = objDataSet.Tables[0].Rows[0][5].ToString();
                    objEvaluationFormBO.AcademicQualificationId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][6].ToString());
                    objEvaluationFormBO.HighestQualification = objDataSet.Tables[0].Rows[0][7].ToString();
                }

            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetEvaluationApplicantDetails");
                throw ex;
            }
            return objEvaluationFormBO;
        }

        public static string ProcSaveSkillInfo = "usp_SCH_saveApplicantSkillList";
        public string saveSkillInfo(EvaluationFormBO objEvaluationFormBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantSkillId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.ApplicantSkillId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iJobPostingId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.JobPostingId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSkills";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objEvaluationFormBO.Skill;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRating";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEvaluationFormBO.RatingId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEvaluationComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objEvaluationFormBO.EvaluationComments;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objEvaluationFormBO.IsActive;
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

                objDBAccess.executeNonQuery(ProcSaveSkillInfo, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "saveSkillInfo");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public string ProcGetSkillsInfoList = "usp_SCH_getSkillsInfoList";
        public List<EvaluationFormBO> getSkillsInfoList(int iApplicantId,int iJobPostingId)
        {
            DataSet objDataSet = null;
            EvaluationFormBO objEvaluationFormBO = null;
            ProcParameterBO objProcParameter = null;
            List<EvaluationFormBO> objEvaluationFormBOList = new List<EvaluationFormBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objProcParameter = new ProcParameterBO();
                objProcParameter.Direction = ParameterDirection.Input;
                objProcParameter.ParameterName = "@iApplicantId";
                objProcParameter.dbType = DbType.Int32;
                objProcParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objProcParameter);

                objProcParameter = new ProcParameterBO();
                objProcParameter.Direction = ParameterDirection.Input;
                objProcParameter.ParameterName = "@iJobPostingId";
                objProcParameter.dbType = DbType.Int32;
                objProcParameter.ParameterValue = iJobPostingId;
                objProcParameterBOList.Add(objProcParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcGetSkillsInfoList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objEvaluationFormBO = new EvaluationFormBO();
                        objEvaluationFormBO.ApplicantSkillId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objEvaluationFormBO.Skill = objDataSet.Tables[0].Rows[i][1].ToString();
                        objEvaluationFormBO.RatingId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][2].ToString());
                        objEvaluationFormBO.EvaluationComments = objDataSet.Tables[0].Rows[i][3].ToString();
                        objEvaluationFormBOList.Add(objEvaluationFormBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getSkillsInfoList");
                throw ex;
            }
            return objEvaluationFormBOList;
        }

        public static string ProcDeleteSkillsList = "usp_SCH_DeleteSkills";
        public string DeleteSkillsList(int iApplicantSkillId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantSkillId";
                objDbParameter.dbType = DbType.String;
                objDbParameter.ParameterValue = iApplicantSkillId;
                objList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteSkillsList, ref objList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DeleteSkillsList");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        //public static string ProcViewShortListedApplicant = "usp_SCH_ViewApprovedApplicantDetailsList";
        //public ApprovedApplicantsBO DisplayApprovedApplicant(int iAppliedJobId, int iApplicantId)
        //{
        //    DataSet objDataSet = null;
        //    ApprovedApplicantsBO objApprovedApplicantsBO = null;
        //    List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
        //    try
        //    {
        //        ProcParameterBO objDbParameter = new ProcParameterBO();
        //        objDbParameter.Direction = ParameterDirection.Input;
        //        objDbParameter.ParameterName = "@iAppliedJobId";
        //        objDbParameter.dbType = DbType.Int32;
        //        objDbParameter.ParameterValue = iAppliedJobId;
        //        ObjProcParameterBOList.Add(objDbParameter);

        //        objDbParameter = new ProcParameterBO();
        //        objDbParameter.Direction = ParameterDirection.Input;
        //        objDbParameter.ParameterName = "@iApplicantId";
        //        objDbParameter.dbType = DbType.Int32;
        //        objDbParameter.ParameterValue = iApplicantId;
        //        ObjProcParameterBOList.Add(objDbParameter);

        //        objDataSet = objDBAccess.execuitDataSet(ProcViewShortListedApplicant, ref ObjProcParameterBOList);
        //        if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            objApprovedApplicantsBO = new ApprovedApplicantsBO();
        //            objApprovedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
        //            objApprovedApplicantsBO.Title = objDataSet.Tables[0].Rows[0][1].ToString();
        //            objApprovedApplicantsBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
        //            objApprovedApplicantsBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
        //            objApprovedApplicantsBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
        //            objApprovedApplicantsBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
        //            objApprovedApplicantsBO.Gender = objDataSet.Tables[0].Rows[0][6].ToString();
        //            objApprovedApplicantsBO.IdType = objDataSet.Tables[0].Rows[0][7].ToString();
        //            objApprovedApplicantsBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
        //            objApprovedApplicantsBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();
        //            objApprovedApplicantsBO.Country = objDataSet.Tables[0].Rows[0][10].ToString();
        //            objApprovedApplicantsBO.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
        //            objApprovedApplicantsBO.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
        //            objApprovedApplicantsBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
        //            objApprovedApplicantsBO.English = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][14].ToString());
        //            objApprovedApplicantsBO.Kiswahili = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][15].ToString());
        //            objApprovedApplicantsBO.MotherTongue = objDataSet.Tables[0].Rows[0][16].ToString();
        //            objApprovedApplicantsBO.OtherLanguages = objDataSet.Tables[0].Rows[0][17].ToString();
        //            objApprovedApplicantsBO.Nationality = objDataSet.Tables[0].Rows[0][18].ToString();
        //            objApprovedApplicantsBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][19].ToString();
        //            objApprovedApplicantsBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
        //            objApprovedApplicantsBO.CV = objDataSet.Tables[0].Rows[0][21].ToString();
        //            objApprovedApplicantsBO.CVSavedName = objDataSet.Tables[0].Rows[0][22].ToString();
        //            objApprovedApplicantsBO.Address = objDataSet.Tables[0].Rows[0][23].ToString();
        //            objApprovedApplicantsBO.Photo = objDataSet.Tables[0].Rows[0][24].ToString();
        //            objApprovedApplicantsBO.PhotoSavedName = objDataSet.Tables[0].Rows[0][25].ToString();



        //            objApprovedApplicantsBO.Bachelors = objDataSet.Tables[0].Rows[0][26].ToString();
        //            objApprovedApplicantsBO.BachelorsSavedName = objDataSet.Tables[0].Rows[0][27].ToString();
        //            objApprovedApplicantsBO.Diploma = objDataSet.Tables[0].Rows[0][28].ToString();
        //            objApprovedApplicantsBO.DiplomaSavedName = objDataSet.Tables[0].Rows[0][29].ToString();
        //            objApprovedApplicantsBO.MSC = objDataSet.Tables[0].Rows[0][30].ToString();
        //            objApprovedApplicantsBO.MSCSavedName = objDataSet.Tables[0].Rows[0][31].ToString();
        //            objApprovedApplicantsBO.PHD = objDataSet.Tables[0].Rows[0][32].ToString();
        //            objApprovedApplicantsBO.PHDSavedName = objDataSet.Tables[0].Rows[0][33].ToString();
        //            objApprovedApplicantsBO.QuaStartDate = objDataSet.Tables[0].Rows[0][34].ToString();
        //            objApprovedApplicantsBO.QuaEndDate = objDataSet.Tables[0].Rows[0][35].ToString();
        //            objApprovedApplicantsBO.Discipline = objDataSet.Tables[0].Rows[0][36].ToString();
        //            objApprovedApplicantsBO.University = objDataSet.Tables[0].Rows[0][37].ToString();
        //            objApprovedApplicantsBO.QuaNationality = objDataSet.Tables[0].Rows[0][38].ToString();
        //            objApprovedApplicantsBO.Degree = objDataSet.Tables[0].Rows[0][39].ToString();
        //            objApprovedApplicantsBO.Class = objDataSet.Tables[0].Rows[0][40].ToString();



        //            objApprovedApplicantsBO.EmployerName = objDataSet.Tables[0].Rows[0][41].ToString();
        //            objApprovedApplicantsBO.TypeOfIndustry = objDataSet.Tables[0].Rows[0][42].ToString();
        //            objApprovedApplicantsBO.TelephoneNo = objDataSet.Tables[0].Rows[0][43].ToString();
        //            objApprovedApplicantsBO.TitleOfSupervisor = objDataSet.Tables[0].Rows[0][44].ToString();
        //            objApprovedApplicantsBO.JobTitle = objDataSet.Tables[0].Rows[0][45].ToString();
        //            objApprovedApplicantsBO.City = objDataSet.Tables[0].Rows[0][46].ToString();
        //            objApprovedApplicantsBO.EmpStartDate = objDataSet.Tables[0].Rows[0][47].ToString();
        //            objApprovedApplicantsBO.EmpEndDate = objDataSet.Tables[0].Rows[0][48].ToString();
        //            objApprovedApplicantsBO.Responsibility = objDataSet.Tables[0].Rows[0][49].ToString();
        //            objApprovedApplicantsBO.MonthlySalary = objDataSet.Tables[0].Rows[0][50].ToString();
        //            objApprovedApplicantsBO.NoticePeriod = objDataSet.Tables[0].Rows[0][51].ToString();
        //            objApprovedApplicantsBO.EmpAddress = objDataSet.Tables[0].Rows[0][52].ToString();
        //            objApprovedApplicantsBO.EmpFirstName = objDataSet.Tables[0].Rows[0][53].ToString();
        //            objApprovedApplicantsBO.SecondName = objDataSet.Tables[0].Rows[0][54].ToString();
        //            objApprovedApplicantsBO.Position = objDataSet.Tables[0].Rows[0][55].ToString();
        //            objApprovedApplicantsBO.RelationshipTOApplicant = objDataSet.Tables[0].Rows[0][56].ToString();
        //            objApprovedApplicantsBO.NameOfTheOrganization = objDataSet.Tables[0].Rows[0][57].ToString();
        //            objApprovedApplicantsBO.TelephoneContact = objDataSet.Tables[0].Rows[0][58].ToString();
        //            objApprovedApplicantsBO.EmpEmailAddress = objDataSet.Tables[0].Rows[0][59].ToString();

        //            objApprovedApplicantsBO.JobDescription = objDataSet.Tables[0].Rows[0][60].ToString();
        //            objApprovedApplicantsBO.Referer = objDataSet.Tables[0].Rows[0][61].ToString();

        //            objApprovedApplicantsBO.SpecialNeed = objDataSet.Tables[0].Rows[0][62].ToString();
        //            objApprovedApplicantsBO.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][63].ToString();


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objApprovedApplicantsBO;
        //}

        //public static string ProcSaveSelectedApplicant = "usp_SCH_SaveSelectedEvaluation";
        //public string saveSelectedApplicant(EvaluationFormBO objEvaluationFormBO, int iUserId)
        //{
        //    List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
        //    ProcParameterBO objDBparameter = null;
        //    string strResult = "";
        //    try
        //    {
        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@iApplicantEvaluationId";
        //        objDBparameter.dbType = DbType.Int32;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.ApplicantEvaluationId;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@iApplicantId";
        //        objDBparameter.dbType = DbType.Int32;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.ApplicantId;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strCommunicationSkill";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.CommunicationSkills;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strApplicantExperience";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.ExperienceId;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strYears";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.Year;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strMonths";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.Month;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strYearsOfExperience";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.YearsOfExperience;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@iStatusId";
        //        objDBparameter.dbType = DbType.Int32;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.StatusId;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@iApplicantSkillId";
        //        objDBparameter.dbType = DbType.Int32;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.ApplicantSkillId;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strSkills";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.Skill;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strRating";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.Rating;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strEvaluationComments";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.EvaluationComments;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@bIsActive";
        //        objDBparameter.dbType = DbType.Boolean;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.IsActive;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@iUserId";
        //        objDBparameter.dbType = DbType.Int32;
        //        objDBparameter.ParameterValue = iUserId;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Output;
        //        objDBparameter.ParameterName = "@strResult";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.Size = 100;
        //        objProcParameterBOList.Add(objDBparameter);

        //        if (objEvaluationFormBO.ApplicantSkillDetails != null && objEvaluationFormBO.ApplicantSkillDetails.Count > 0)
        //        {
        //            objDBparameter = new ProcParameterBO();
        //            objDBparameter.Direction = ParameterDirection.Input;
        //            objDBparameter.ParameterName = "@xmlApplicantSkills";
        //            objDBparameter.dbType = DbType.Xml;
        //            objDBparameter.ParameterValue = new SqlXml(new XElement("ApplicantSkill",
        //            from ApplicantSkill in objEvaluationFormBO.ApplicantSkillDetails
        //            select new XElement("Skill",
        //                           new XAttribute("Skill", (ApplicantSkill.Skill == null) ? "" : ApplicantSkill.Skill),
        //                           new XElement("RatingId", (ApplicantSkill.RatingId == null) ? "" : ApplicantSkill.RatingId),
        //                           new XElement("Rating", (ApplicantSkill.Rating == null) ? "" : ApplicantSkill.Rating),
        //                           new XElement("EvaluationComments", (ApplicantSkill.EvaluationComments == null) ? "" : ApplicantSkill.EvaluationComments)
        //                       )).CreateReader());
        //            objProcParameterBOList.Add(objDBparameter);
        //        }

        //        objDBAccess.executeNonQuery(ProcSaveSelectedApplicant, ref objProcParameterBOList);

        //        for (int i = 0; i < objProcParameterBOList.Count; i++)
        //        {
        //            if (objProcParameterBOList[i].Direction == ParameterDirection.Output)
        //            {
        //                strResult = objProcParameterBOList[i].ParameterValue.ToString();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        strResult = "FAILED";
        //        throw ex;
        //    }
        //    return strResult;
        //}



        //public static string ProcSaveRejectedApplicant = "usp_SCH_SaveRejectedEvaluation";
        //public string saveRejectedApplicant(EvaluationFormBO objEvaluationFormBO, int iUserId)
        //{
        //    List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
        //    ProcParameterBO objDBparameter = null;
        //    string strResult = "";
        //    try
        //    {
        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@iApplicantEvaluationId";
        //        objDBparameter.dbType = DbType.Int32;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.ApplicantEvaluationId;
        //        objProcParameterBOList.Add(objDBparameter);


        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@iApplicantId";
        //        objDBparameter.dbType = DbType.Int32;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.ApplicantId;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strCommunicationSkill";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.CommunicationSkills;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strApplicantExperience";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.ExperienceId;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strYears";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.Year;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strMonths";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.Month;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strYearsOfExperience";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.YearsOfExperience;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@iStatusId";
        //        objDBparameter.dbType = DbType.Int32;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.StatusId;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@iApplicantSkillId";
        //        objDBparameter.dbType = DbType.Int32;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.ApplicantSkillId;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strSkills";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.Skill;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strRating";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.Rating;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@strEvaluationComments";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.EvaluationComments;
        //        objProcParameterBOList.Add(objDBparameter);


        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@bIsActive";
        //        objDBparameter.dbType = DbType.Boolean;
        //        objDBparameter.ParameterValue = objEvaluationFormBO.IsActive;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@iUserId";
        //        objDBparameter.dbType = DbType.Int32;
        //        objDBparameter.ParameterValue = iUserId;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Output;
        //        objDBparameter.ParameterName = "@strResult";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.Size = 100;
        //        objProcParameterBOList.Add(objDBparameter);

        //         if (objEvaluationFormBO.ApplicantSkillDetails != null && objEvaluationFormBO.ApplicantSkillDetails.Count > 0)
        //        {
        //            objDBparameter = new ProcParameterBO();
        //            objDBparameter.Direction = ParameterDirection.Input;
        //            objDBparameter.ParameterName = "@xmlApplicantSkills";
        //            objDBparameter.dbType = DbType.Xml;
        //            objDBparameter.ParameterValue = new SqlXml(new XElement("ApplicantSkill",
        //            from ApplicantSkillDetails in objEvaluationFormBO.ApplicantSkillDetails
        //            select new XElement("Skill",
        //                           new XAttribute("Skill", (ApplicantSkillDetails.Skill == null) ? "" : ApplicantSkillDetails.Skill),
        //                           new XElement("RatingId", (ApplicantSkillDetails.RatingId == null) ? "" : ApplicantSkillDetails.RatingId),
        //                           new XElement("Rating", (ApplicantSkillDetails.Rating == null) ? "" : ApplicantSkillDetails.Rating),
        //                           new XElement("EvaluationComments", (ApplicantSkillDetails.EvaluationComments == null) ? "" : ApplicantSkillDetails.EvaluationComments)
        //                       )).CreateReader());
        //            objProcParameterBOList.Add(objDBparameter);
        //        }


        //        objDBAccess.executeNonQuery(ProcSaveRejectedApplicant, ref objProcParameterBOList);

        //        for (int i = 0; i < objProcParameterBOList.Count; i++)
        //        {
        //            if (objProcParameterBOList[i].Direction == ParameterDirection.Output)
        //            {
        //                strResult = objProcParameterBOList[i].ParameterValue.ToString();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        strResult = "FAILED";
        //        throw ex;
        //    }
        //    return strResult;
        //}

    }

}

