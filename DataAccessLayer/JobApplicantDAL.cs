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
    public class JobApplicantDAL
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

        public static string ProcGetJobApplicantList = "usp_SCH_GetJobWiseApplicant";
        public List<JobApplicantModelBO> GetJobApplicantList(int iJobId)
        {
            DataSet objDataSet = null;
            JobApplicantModelBO objJobApplicantModelBo = null;
            List<JobApplicantModelBO> objListJobApplicantModelBo = new List<JobApplicantModelBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objProcParameterBo = new ProcParameterBO();
                objProcParameterBo.Direction = ParameterDirection.Input;
                objProcParameterBo.ParameterName = "@iJobId";
                objProcParameterBo.dbType = DbType.Int32;
                objProcParameterBo.ParameterValue = iJobId;
                objProcParameterBOList.Add(objProcParameterBo);

                objDataSet = objDBAccess.execuitDataSet(ProcGetJobApplicantList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objJobApplicantModelBo = new JobApplicantModelBO();
                        objJobApplicantModelBo.ApplicantJobId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objJobApplicantModelBo.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        objJobApplicantModelBo.Applicantname = objDataSet.Tables[0].Rows[i][2].ToString();
                        objJobApplicantModelBo.Gender = objDataSet.Tables[0].Rows[i][3].ToString();
                        objJobApplicantModelBo.DateOfBirth = objDataSet.Tables[0].Rows[i][4].ToString();
                        objJobApplicantModelBo.PhoneNumber = objDataSet.Tables[0].Rows[i][5].ToString();
                        objJobApplicantModelBo.JobName = objDataSet.Tables[0].Rows[i][6].ToString();
                        objJobApplicantModelBo.Status = objDataSet.Tables[0].Rows[i][7].ToString();
                        objListJobApplicantModelBo.Add(objJobApplicantModelBo);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetJobApplicantList");
                throw ex;
            }
            return objListJobApplicantModelBo;
        }

        public static string ProcViewAllApplicants = "usp_ViewJobWiseApplicantDetails";
        public JobApplicantModelBO ViewAllApplicants(int iApplicantJobId)
        {
            DataSet objDataSet = null;
            JobApplicantModelBO objJobApplicantModelBO = null;
            ApplicantRelationBO objApplicantRelationBO = null;
            LanguageSpokenBO objLanguageSpokenBO = null;
            ApplicantQualificationBO objApplicantQualificationBO = null;
            ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO = null;
            ApplicantRefereesBO objApplicantRefereesBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iAppliedJobId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantJobId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewAllApplicants, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objJobApplicantModelBO = new JobApplicantModelBO();
                    objJobApplicantModelBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objJobApplicantModelBO.Title = objDataSet.Tables[0].Rows[0][1].ToString();
                    objJobApplicantModelBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objJobApplicantModelBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objJobApplicantModelBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
                    objJobApplicantModelBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
                    objJobApplicantModelBO.Gender = objDataSet.Tables[0].Rows[0][6].ToString();
                    objJobApplicantModelBO.IdType = objDataSet.Tables[0].Rows[0][7].ToString();
                    objJobApplicantModelBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
                    objJobApplicantModelBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();
                    objJobApplicantModelBO.Country = objDataSet.Tables[0].Rows[0][10].ToString();
                    objJobApplicantModelBO.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
                    objJobApplicantModelBO.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
                    objJobApplicantModelBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
                    objJobApplicantModelBO.MotherTongue = objDataSet.Tables[0].Rows[0][14].ToString();
                    objJobApplicantModelBO.Nationality = objDataSet.Tables[0].Rows[0][15].ToString();
                    objJobApplicantModelBO.County = objDataSet.Tables[0].Rows[0][16].ToString();
                    objJobApplicantModelBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][17].ToString();
                    objJobApplicantModelBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][18].ToString();
                    objJobApplicantModelBO.CV = objDataSet.Tables[0].Rows[0][19].ToString();
                    objJobApplicantModelBO.CVSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
                    objJobApplicantModelBO.SpecialNeed = objDataSet.Tables[0].Rows[0][21].ToString();
                    objJobApplicantModelBO.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][22].ToString();
                    objJobApplicantModelBO.Address = objDataSet.Tables[0].Rows[0][23].ToString();
                    objJobApplicantModelBO.Photo = objDataSet.Tables[0].Rows[0][24].ToString();
                    objJobApplicantModelBO.PhotoSavedName = objDataSet.Tables[0].Rows[0][25].ToString();

                    objJobApplicantModelBO.ApplicantJobId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][26].ToString());
                    objJobApplicantModelBO.Status = objDataSet.Tables[0].Rows[0][27].ToString();

                    if (objDataSet != null && objDataSet.Tables[1].Rows.Count > 0)
                    {
                        objJobApplicantModelBO.ApplicantRelationList = new List<ApplicantRelationBO>();
                        for (int i = 0; i < objDataSet.Tables[1].Rows.Count; i++)
                        {
                            objApplicantRelationBO = new ApplicantRelationBO();
                            objApplicantRelationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[1].Rows[i][0].ToString());
                            objApplicantRelationBO.RelationId = Convert.ToInt32(objDataSet.Tables[1].Rows[i][1].ToString());
                            objApplicantRelationBO.AnyoneWorkinWIK = objDataSet.Tables[1].Rows[i][2].ToString();
                            objApplicantRelationBO.RelativeName = objDataSet.Tables[1].Rows[i][3].ToString();
                            objApplicantRelationBO.Relationship = objDataSet.Tables[1].Rows[i][4].ToString();
                            objJobApplicantModelBO.ApplicantRelationList.Add(objApplicantRelationBO);
                        }
                    }

                    if (objDataSet != null && objDataSet.Tables[2].Rows.Count > 0)
                    {
                        objJobApplicantModelBO.ApplicantLanguageList = new List<LanguageSpokenBO>();
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
                            objJobApplicantModelBO.ApplicantLanguageList.Add(objLanguageSpokenBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[3].Rows.Count > 0)
                    {
                        objJobApplicantModelBO.ApplicantQualificationList = new List<ApplicantQualificationBO>();
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
                            objJobApplicantModelBO.ApplicantQualificationList.Add(objApplicantQualificationBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[4].Rows.Count > 0)
                    {
                        objJobApplicantModelBO.ApplicantEmploymentList = new List<ApplicantEmploymentHistoryBO>();
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
                            objJobApplicantModelBO.ApplicantEmploymentList.Add(objApplicantEmploymentHistoryBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[5].Rows.Count > 0)
                    {
                        objJobApplicantModelBO.ApplicantRefereesList = new List<ApplicantRefereesBO>();
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
                            objJobApplicantModelBO.ApplicantRefereesList.Add(objApplicantRefereesBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[6].Rows.Count > 0)
                    {
                        objJobApplicantModelBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[6].Rows[0][0].ToString());
                        objJobApplicantModelBO.ApplicantMotivationId = Convert.ToInt32(objDataSet.Tables[6].Rows[0][1].ToString());
                        objJobApplicantModelBO.MembershipData = objDataSet.Tables[6].Rows[0][2].ToString();
                        objJobApplicantModelBO.NameofProfessionalBody = objDataSet.Tables[6].Rows[0][3].ToString();
                        objJobApplicantModelBO.MembershipNumber = objDataSet.Tables[6].Rows[0][4].ToString();
                        objJobApplicantModelBO.ValidityData = objDataSet.Tables[6].Rows[0][5].ToString();
                        objJobApplicantModelBO.JobDescription = objDataSet.Tables[6].Rows[0][6].ToString();
                        objJobApplicantModelBO.Referer = objDataSet.Tables[6].Rows[0][7].ToString();
                        objJobApplicantModelBO.ApplicationNote = objDataSet.Tables[6].Rows[0][8].ToString();
                    }
                    if (objDataSet != null && objDataSet.Tables[7].Rows.Count > 0)
                    {
                        objJobApplicantModelBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[7].Rows[0][0].ToString());
                        objJobApplicantModelBO.TerminatedId = objDataSet.Tables[7].Rows[0][1].ToString();
                        objJobApplicantModelBO.Terminatation = objDataSet.Tables[7].Rows[0][2].ToString();
                        objJobApplicantModelBO.MisconductId = objDataSet.Tables[7].Rows[0][3].ToString();
                        objJobApplicantModelBO.Misconduct = objDataSet.Tables[7].Rows[0][4].ToString();
                        objJobApplicantModelBO.ManagementId = objDataSet.Tables[7].Rows[0][5].ToString();
                        objJobApplicantModelBO.Management = objDataSet.Tables[7].Rows[0][6].ToString();
                        objJobApplicantModelBO.InvestigationId = objDataSet.Tables[7].Rows[0][7].ToString();
                        objJobApplicantModelBO.Investigation = objDataSet.Tables[7].Rows[0][8].ToString();


                        objJobApplicantModelBO.CriminalOffenceId = objDataSet.Tables[7].Rows[0][9].ToString();
                        objJobApplicantModelBO.CriminalOffence = objDataSet.Tables[7].Rows[0][10].ToString();
                        objJobApplicantModelBO.ConvictionsId = objDataSet.Tables[7].Rows[0][11].ToString();
                        objJobApplicantModelBO.Convictions = objDataSet.Tables[7].Rows[0][12].ToString();
                        objJobApplicantModelBO.CorruptionId = objDataSet.Tables[7].Rows[0][13].ToString();
                        objJobApplicantModelBO.Corruption = objDataSet.Tables[7].Rows[0][14].ToString();
                        objJobApplicantModelBO.DisciplinaryId = objDataSet.Tables[7].Rows[0][15].ToString();
                        objJobApplicantModelBO.Disciplinary = objDataSet.Tables[7].Rows[0][16].ToString();
                        objJobApplicantModelBO.RelationToChildId = objDataSet.Tables[7].Rows[0][17].ToString();
                        objJobApplicantModelBO.RelationToChild = objDataSet.Tables[7].Rows[0][18].ToString();
                        objJobApplicantModelBO.RelationToAdultId = objDataSet.Tables[7].Rows[0][19].ToString();
                        objJobApplicantModelBO.RelationToAdult = objDataSet.Tables[7].Rows[0][20].ToString();
                        objJobApplicantModelBO.RelativeId = objDataSet.Tables[7].Rows[0][21].ToString();
                        objJobApplicantModelBO.DealingsWithWIKId = objDataSet.Tables[7].Rows[0][22].ToString();
                        objJobApplicantModelBO.DealingsWithWIK = objDataSet.Tables[7].Rows[0][23].ToString();
                        objJobApplicantModelBO.Declarationinfo = Convert.ToBoolean(objDataSet.Tables[7].Rows[0][24].ToString());
                        objJobApplicantModelBO.Statement = Convert.ToBoolean(objDataSet.Tables[7].Rows[0][25].ToString());

                        objJobApplicantModelBO.DeclarationID = Convert.ToInt32(objDataSet.Tables[7].Rows[0][26].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "ViewAllApplicants");
                throw ex;
            }
            return objJobApplicantModelBO;
        }

        public static string ProcUpdateJobApplicant = "usp_ERT_UpdatedAppliedJobs";
        public string UpdateJobWiseApplicant(JobApplicantModelBO objJobApplicantModelBo, int iUserId)
        {
            ProcParameterBO objDbParameter = null;
            List<ProcParameterBO> objListProcParameterBo = new List<ProcParameterBO>();
            string strResult = "";
            try
            {
                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iAppliedJobId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = objJobApplicantModelBo.ApplicantJobId;
                objListProcParameterBo.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = objJobApplicantModelBo.ApplicantId;
                objListProcParameterBo.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@strComments";
                objDbParameter.dbType = DbType.String;
                objDbParameter.ParameterValue = objJobApplicantModelBo.StatusComments;
                objListProcParameterBo.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iUserId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iUserId;
                objListProcParameterBo.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Output;
                objDbParameter.ParameterName = "@strResult";
                objDbParameter.dbType = DbType.String;
                objDbParameter.Size = 100;
                objListProcParameterBo.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcUpdateJobApplicant, ref objListProcParameterBo);

                for (int i = 0; i < objListProcParameterBo.Count; i++)
                {
                    if (objListProcParameterBo[i].Direction == ParameterDirection.Output)
                    {
                        strResult = objListProcParameterBo[i].ParameterValue.ToString();
                    }
                }
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "UpdateJobWiseApplicant");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string PrcoRejectJobApplicant = "usp_ERT_RejectedAppliedJobs";
        public string RejectJobWiseApplicant(JobApplicantModelBO objJobApplicantModelBo, int iUserId)
        {
            ProcParameterBO objDbParameter = null;
            List<ProcParameterBO> objListProcParameterBo = new List<ProcParameterBO>();
            string strResult = "";
            try
            {
                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iAppliedJobId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = objJobApplicantModelBo.ApplicantJobId;
                objListProcParameterBo.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = objJobApplicantModelBo.ApplicantId;
                objListProcParameterBo.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@strComments";
                objDbParameter.dbType = DbType.String;
                objDbParameter.ParameterValue = objJobApplicantModelBo.StatusComments;
                objListProcParameterBo.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iUserId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iUserId;
                objListProcParameterBo.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Output;
                objDbParameter.ParameterName = "@strResult";
                objDbParameter.dbType = DbType.String;
                objDbParameter.Size = 100;
                objListProcParameterBo.Add(objDbParameter);

                objDBAccess.executeNonQuery(PrcoRejectJobApplicant, ref objListProcParameterBo);

                for (int i = 0; i < objListProcParameterBo.Count; i++)
                {
                    if (objListProcParameterBo[i].Direction == ParameterDirection.Output)
                    {
                        strResult = objListProcParameterBo[i].ParameterValue.ToString();
                    }
                }
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "RejectJobWiseApplicant");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        //public static string ProcViewAllApplicants = "usp_ViewJobWiseApplicantDetails";
        //public JobApplicantModelBO ViewAllApplicants(int iApplicantJobId)
        //{
        //    DataSet objDataSet = null;
        //    JobApplicantModelBO objJobApplicantModelBo = null;
        //    List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

        //    try
        //    {
        //        ProcParameterBO objDbParameter = new ProcParameterBO();
        //        objDbParameter.Direction = ParameterDirection.Input;
        //        objDbParameter.ParameterName = "@iAppliedJobId";
        //        objDbParameter.dbType = DbType.Int32;
        //        objDbParameter.ParameterValue = iApplicantJobId;
        //        objProcParameterBOList.Add(objDbParameter);

        //        objDataSet = objDBAccess.execuitDataSet(ProcViewAllApplicants, ref objProcParameterBOList);
        //        if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            objJobApplicantModelBo = new JobApplicantModelBO();
        //            objJobApplicantModelBo.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
        //            objJobApplicantModelBo.Title = objDataSet.Tables[0].Rows[0][1].ToString();
        //            objJobApplicantModelBo.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
        //            objJobApplicantModelBo.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
        //            objJobApplicantModelBo.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
        //            objJobApplicantModelBo.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
        //            objJobApplicantModelBo.Gender = objDataSet.Tables[0].Rows[0][6].ToString();
        //            objJobApplicantModelBo.IdType = objDataSet.Tables[0].Rows[0][7].ToString();
        //            objJobApplicantModelBo.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
        //            objJobApplicantModelBo.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();
        //            objJobApplicantModelBo.Country = objDataSet.Tables[0].Rows[0][10].ToString();
        //            objJobApplicantModelBo.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
        //            objJobApplicantModelBo.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
        //            objJobApplicantModelBo.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
        //            objJobApplicantModelBo.English = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][14].ToString());
        //            objJobApplicantModelBo.Kiswahili = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][15].ToString());
        //            objJobApplicantModelBo.MotherTongue = objDataSet.Tables[0].Rows[0][16].ToString();
        //            objJobApplicantModelBo.OtherLanguages = objDataSet.Tables[0].Rows[0][17].ToString();
        //            objJobApplicantModelBo.Nationality = objDataSet.Tables[0].Rows[0][18].ToString();
        //            objJobApplicantModelBo.ApplicationLetter = objDataSet.Tables[0].Rows[0][19].ToString();
        //            objJobApplicantModelBo.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
        //            objJobApplicantModelBo.CV = objDataSet.Tables[0].Rows[0][21].ToString();
        //            objJobApplicantModelBo.CVSavedName = objDataSet.Tables[0].Rows[0][22].ToString();
        //            objJobApplicantModelBo.Address = objDataSet.Tables[0].Rows[0][23].ToString();
        //            objJobApplicantModelBo.Photo = objDataSet.Tables[0].Rows[0][24].ToString();
        //            objJobApplicantModelBo.PhotoSavedName = objDataSet.Tables[0].Rows[0][25].ToString();



        //            objJobApplicantModelBo.Bachelors = objDataSet.Tables[0].Rows[0][26].ToString();
        //            objJobApplicantModelBo.BachelorsSavedName = objDataSet.Tables[0].Rows[0][27].ToString();
        //            objJobApplicantModelBo.Diploma = objDataSet.Tables[0].Rows[0][28].ToString();
        //            objJobApplicantModelBo.DiplomaSavedName = objDataSet.Tables[0].Rows[0][29].ToString();
        //            objJobApplicantModelBo.MSC = objDataSet.Tables[0].Rows[0][30].ToString();
        //            objJobApplicantModelBo.MSCSavedName = objDataSet.Tables[0].Rows[0][31].ToString();
        //            objJobApplicantModelBo.PHD = objDataSet.Tables[0].Rows[0][32].ToString();
        //            objJobApplicantModelBo.PHDSavedName = objDataSet.Tables[0].Rows[0][33].ToString();
        //            objJobApplicantModelBo.QuaStartDate = objDataSet.Tables[0].Rows[0][34].ToString();
        //            objJobApplicantModelBo.QuaEndDate = objDataSet.Tables[0].Rows[0][35].ToString();
        //            objJobApplicantModelBo.Discipline = objDataSet.Tables[0].Rows[0][36].ToString();
        //            objJobApplicantModelBo.University = objDataSet.Tables[0].Rows[0][37].ToString();
        //            objJobApplicantModelBo.QuaNationality = objDataSet.Tables[0].Rows[0][38].ToString();
        //            objJobApplicantModelBo.Degree = objDataSet.Tables[0].Rows[0][39].ToString();
        //            objJobApplicantModelBo.Class = objDataSet.Tables[0].Rows[0][40].ToString();



        //            objJobApplicantModelBo.EmployerName = objDataSet.Tables[0].Rows[0][41].ToString();
        //            objJobApplicantModelBo.TypeOfIndustry = objDataSet.Tables[0].Rows[0][42].ToString();
        //            objJobApplicantModelBo.TelephoneNo = objDataSet.Tables[0].Rows[0][43].ToString();
        //            objJobApplicantModelBo.TitleOfSupervisor = objDataSet.Tables[0].Rows[0][44].ToString();
        //            objJobApplicantModelBo.JobTitle = objDataSet.Tables[0].Rows[0][45].ToString();
        //            objJobApplicantModelBo.City = objDataSet.Tables[0].Rows[0][46].ToString();
        //            objJobApplicantModelBo.EmpStartDate = objDataSet.Tables[0].Rows[0][47].ToString();
        //            objJobApplicantModelBo.EmpEndDate = objDataSet.Tables[0].Rows[0][48].ToString();
        //            objJobApplicantModelBo.Responsibility = objDataSet.Tables[0].Rows[0][49].ToString();
        //            objJobApplicantModelBo.MonthlySalary = objDataSet.Tables[0].Rows[0][50].ToString();
        //            objJobApplicantModelBo.NoticePeriod = objDataSet.Tables[0].Rows[0][51].ToString();
        //            objJobApplicantModelBo.EmpAddress = objDataSet.Tables[0].Rows[0][52].ToString();
        //            objJobApplicantModelBo.EmpFirstName = objDataSet.Tables[0].Rows[0][53].ToString();
        //            objJobApplicantModelBo.SecondName = objDataSet.Tables[0].Rows[0][54].ToString();
        //            objJobApplicantModelBo.Position = objDataSet.Tables[0].Rows[0][55].ToString();
        //            objJobApplicantModelBo.RelationshipTOApplicant = objDataSet.Tables[0].Rows[0][56].ToString();
        //            objJobApplicantModelBo.NameOfTheOrganization = objDataSet.Tables[0].Rows[0][57].ToString();
        //            objJobApplicantModelBo.TelephoneContact = objDataSet.Tables[0].Rows[0][58].ToString();
        //            objJobApplicantModelBo.EmpEmailAddress = objDataSet.Tables[0].Rows[0][59].ToString();

        //            objJobApplicantModelBo.JobDescription = objDataSet.Tables[0].Rows[0][60].ToString();
        //            objJobApplicantModelBo.Referer = objDataSet.Tables[0].Rows[0][61].ToString();

        //            objJobApplicantModelBo.SpecialNeed = objDataSet.Tables[0].Rows[0][62].ToString();
        //            objJobApplicantModelBo.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][63].ToString();

        //            objJobApplicantModelBo.ApplicantJobId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][64].ToString());
        //            objJobApplicantModelBo.Status = objDataSet.Tables[0].Rows[0][65].ToString();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objJobApplicantModelBo;
        //}
    }
}
