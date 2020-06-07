using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class RejectedApplicantsDAL
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

        public static string ProcRejectedApplicantsList = "usp_getRejectedApplicantList";
        public List<RejectedApplicantsBO> getRejectedApplicantsList(int iJobId)
        {
            DataSet objDataSet = null;
            RejectedApplicantsBO objRejectedApplicantsBO = null;
            List<RejectedApplicantsBO> objRejectedApplicantsBOList = new List<RejectedApplicantsBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcRejectedApplicantsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objRejectedApplicantsBO = new RejectedApplicantsBO();
                        objRejectedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objRejectedApplicantsBO.ApplicantName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objRejectedApplicantsBO.PhoneNumber = objDataSet.Tables[0].Rows[i][2].ToString();
                        objRejectedApplicantsBO.EmailAddress = objDataSet.Tables[0].Rows[i][3].ToString();
                        objRejectedApplicantsBO.Address = objDataSet.Tables[0].Rows[i][4].ToString();
                        objRejectedApplicantsBO.Status = objDataSet.Tables[0].Rows[i][5].ToString();
                        objRejectedApplicantsBO.JobWiseComments = objDataSet.Tables[0].Rows[i][6].ToString();
                        objRejectedApplicantsBOList.Add(objRejectedApplicantsBO);
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

        public static string ProcViewRejectedApplicant = "usp_ViewRejectedApplicant";
        public RejectedApplicantsBO DisplayRejectedApplicant(int iApplicantId, int iJobPostingId)
        {
            DataSet objDataSet = null;
            RejectedApplicantsBO objRejectedApplicantsBO = null;
            ApplicantRelationBO objApplicantRelationBO = null;
            LanguageSpokenBO objLanguageSpokenBO = null;
            ApplicantQualificationBO objApplicantQualificationBO = null;
            ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO = null;
            ApplicantRefereesBO objApplicantRefereesBO = null;
            ApplicantSkillsDetailsBO objApplicantSkillsDetailsBO = null;
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
                objDbParameter.ParameterName = "@iJobPostingId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobPostingId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewRejectedApplicant, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objRejectedApplicantsBO = new RejectedApplicantsBO();
                    objRejectedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objRejectedApplicantsBO.Title = objDataSet.Tables[0].Rows[0][1].ToString();
                    objRejectedApplicantsBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objRejectedApplicantsBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objRejectedApplicantsBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
                    objRejectedApplicantsBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
                    objRejectedApplicantsBO.Gender = objDataSet.Tables[0].Rows[0][6].ToString();
                    objRejectedApplicantsBO.IdType = objDataSet.Tables[0].Rows[0][7].ToString();
                    objRejectedApplicantsBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
                    objRejectedApplicantsBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();
                    objRejectedApplicantsBO.Country = objDataSet.Tables[0].Rows[0][10].ToString();
                    objRejectedApplicantsBO.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
                    objRejectedApplicantsBO.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
                    objRejectedApplicantsBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
                    objRejectedApplicantsBO.MotherTongue = objDataSet.Tables[0].Rows[0][14].ToString();
                    objRejectedApplicantsBO.Nationality = objDataSet.Tables[0].Rows[0][15].ToString();
                    objRejectedApplicantsBO.County = objDataSet.Tables[0].Rows[0][16].ToString();
                    objRejectedApplicantsBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][17].ToString();
                    objRejectedApplicantsBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][18].ToString();
                    objRejectedApplicantsBO.CV = objDataSet.Tables[0].Rows[0][19].ToString();
                    objRejectedApplicantsBO.CVSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
                    objRejectedApplicantsBO.SpecialNeed = objDataSet.Tables[0].Rows[0][21].ToString();
                    objRejectedApplicantsBO.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][22].ToString();
                    objRejectedApplicantsBO.Address = objDataSet.Tables[0].Rows[0][23].ToString();
                    objRejectedApplicantsBO.Photo = objDataSet.Tables[0].Rows[0][24].ToString();
                    objRejectedApplicantsBO.PhotoSavedName = objDataSet.Tables[0].Rows[0][25].ToString();

                    if (objDataSet != null && objDataSet.Tables[1].Rows.Count > 0)
                    {
                        objRejectedApplicantsBO.ApplicantRelationList = new List<ApplicantRelationBO>();
                        for (int i = 0; i < objDataSet.Tables[1].Rows.Count; i++)
                        {
                            objApplicantRelationBO = new ApplicantRelationBO();
                            objApplicantRelationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[1].Rows[i][0].ToString());
                            objApplicantRelationBO.RelationId = Convert.ToInt32(objDataSet.Tables[1].Rows[i][1].ToString());
                            objApplicantRelationBO.AnyoneWorkinWIK = objDataSet.Tables[1].Rows[i][2].ToString();
                            objApplicantRelationBO.RelativeName = objDataSet.Tables[1].Rows[i][3].ToString();
                            objApplicantRelationBO.Relationship = objDataSet.Tables[1].Rows[i][4].ToString();
                            objRejectedApplicantsBO.ApplicantRelationList.Add(objApplicantRelationBO);
                        }
                    }

                    if (objDataSet != null && objDataSet.Tables[2].Rows.Count > 0)
                    {
                        objRejectedApplicantsBO.ApplicantLanguageList = new List<LanguageSpokenBO>();
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
                            objRejectedApplicantsBO.ApplicantLanguageList.Add(objLanguageSpokenBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[3].Rows.Count > 0)
                    {
                        objRejectedApplicantsBO.ApplicantQualificationList = new List<ApplicantQualificationBO>();
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
                            objRejectedApplicantsBO.ApplicantQualificationList.Add(objApplicantQualificationBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[4].Rows.Count > 0)
                    {
                        objRejectedApplicantsBO.ApplicantEmploymentList = new List<ApplicantEmploymentHistoryBO>();
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
                            objRejectedApplicantsBO.ApplicantEmploymentList.Add(objApplicantEmploymentHistoryBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[5].Rows.Count > 0)
                    {
                        objRejectedApplicantsBO.ApplicantRefereesList = new List<ApplicantRefereesBO>();
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
                            objRejectedApplicantsBO.ApplicantRefereesList.Add(objApplicantRefereesBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[6].Rows.Count > 0)
                    {
                        objRejectedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[6].Rows[0][0].ToString());
                        objRejectedApplicantsBO.ApplicantMotivationId = Convert.ToInt32(objDataSet.Tables[6].Rows[0][1].ToString());
                        objRejectedApplicantsBO.MembershipData = objDataSet.Tables[6].Rows[0][2].ToString();
                        objRejectedApplicantsBO.NameofProfessionalBody = objDataSet.Tables[6].Rows[0][3].ToString();
                        objRejectedApplicantsBO.MembershipNumber = objDataSet.Tables[6].Rows[0][4].ToString();
                        objRejectedApplicantsBO.ValidityData = objDataSet.Tables[6].Rows[0][5].ToString();
                        objRejectedApplicantsBO.JobDescription = objDataSet.Tables[6].Rows[0][6].ToString();
                        objRejectedApplicantsBO.Referer = objDataSet.Tables[6].Rows[0][7].ToString();
                        objRejectedApplicantsBO.ApplicationNote = objDataSet.Tables[6].Rows[0][8].ToString();
                    }
                    if (objDataSet != null && objDataSet.Tables[7].Rows.Count > 0)
                    {
                        objRejectedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[7].Rows[0][0].ToString());
                        objRejectedApplicantsBO.TerminatedId = objDataSet.Tables[7].Rows[0][1].ToString();
                        objRejectedApplicantsBO.Terminatation = objDataSet.Tables[7].Rows[0][2].ToString();
                        objRejectedApplicantsBO.MisconductId = objDataSet.Tables[7].Rows[0][3].ToString();
                        objRejectedApplicantsBO.Misconduct = objDataSet.Tables[7].Rows[0][4].ToString();
                        objRejectedApplicantsBO.ManagementId = objDataSet.Tables[7].Rows[0][5].ToString();
                        objRejectedApplicantsBO.Management = objDataSet.Tables[7].Rows[0][6].ToString();
                        objRejectedApplicantsBO.InvestigationId = objDataSet.Tables[7].Rows[0][7].ToString();
                        objRejectedApplicantsBO.Investigation = objDataSet.Tables[7].Rows[0][8].ToString();


                        objRejectedApplicantsBO.CriminalOffenceId = objDataSet.Tables[7].Rows[0][9].ToString();
                        objRejectedApplicantsBO.CriminalOffence = objDataSet.Tables[7].Rows[0][10].ToString();
                        objRejectedApplicantsBO.ConvictionsId = objDataSet.Tables[7].Rows[0][11].ToString();
                        objRejectedApplicantsBO.Convictions = objDataSet.Tables[7].Rows[0][12].ToString();
                        objRejectedApplicantsBO.CorruptionId = objDataSet.Tables[7].Rows[0][13].ToString();
                        objRejectedApplicantsBO.Corruption = objDataSet.Tables[7].Rows[0][14].ToString();
                        objRejectedApplicantsBO.DisciplinaryId = objDataSet.Tables[7].Rows[0][15].ToString();
                        objRejectedApplicantsBO.Disciplinary = objDataSet.Tables[7].Rows[0][16].ToString();
                        objRejectedApplicantsBO.RelationToChildId = objDataSet.Tables[7].Rows[0][17].ToString();
                        objRejectedApplicantsBO.RelationToChild = objDataSet.Tables[7].Rows[0][18].ToString();
                        objRejectedApplicantsBO.RelationToAdultId = objDataSet.Tables[7].Rows[0][19].ToString();
                        objRejectedApplicantsBO.RelationToAdult = objDataSet.Tables[7].Rows[0][20].ToString();
                        objRejectedApplicantsBO.RelativeId = objDataSet.Tables[7].Rows[0][21].ToString();
                        objRejectedApplicantsBO.DealingsWithWIKId = objDataSet.Tables[7].Rows[0][22].ToString();
                        objRejectedApplicantsBO.DealingsWithWIK = objDataSet.Tables[7].Rows[0][23].ToString();
                        objRejectedApplicantsBO.Declarationinfo = Convert.ToBoolean(objDataSet.Tables[7].Rows[0][24].ToString());
                        objRejectedApplicantsBO.Statement = Convert.ToBoolean(objDataSet.Tables[7].Rows[0][25].ToString());

                        objRejectedApplicantsBO.DeclarationID = Convert.ToInt32(objDataSet.Tables[7].Rows[0][26].ToString());
                    }


                    if (objDataSet != null && objDataSet.Tables[8].Rows.Count > 0)
                    {
                        objRejectedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[8].Rows[0][0].ToString());
                        objRejectedApplicantsBO.CommunicationSkills = objDataSet.Tables[8].Rows[0][1].ToString();
                        objRejectedApplicantsBO.Experience = objDataSet.Tables[8].Rows[0][2].ToString();
                        objRejectedApplicantsBO.Year = objDataSet.Tables[8].Rows[0][3].ToString();
                        objRejectedApplicantsBO.Month = objDataSet.Tables[8].Rows[0][4].ToString();
                    }
                    if (objDataSet != null && objDataSet.Tables[9].Rows.Count > 0)
                    {
                        objRejectedApplicantsBO.SkillsList = new List<ApplicantSkillsDetailsBO>();
                        for (int i = 0; i < objDataSet.Tables[9].Rows.Count; i++)
                        {
                            objApplicantSkillsDetailsBO = new ApplicantSkillsDetailsBO();
                            objApplicantSkillsDetailsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[9].Rows[i][0].ToString());
                            objApplicantSkillsDetailsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[9].Rows[i][1].ToString());
                            objApplicantSkillsDetailsBO.Skill = objDataSet.Tables[9].Rows[i][2].ToString();
                            objApplicantSkillsDetailsBO.RatingId = Convert.ToInt32(objDataSet.Tables[9].Rows[i][3].ToString());
                            objApplicantSkillsDetailsBO.EvaluationComments = objDataSet.Tables[9].Rows[i][4].ToString();
                            objRejectedApplicantsBO.SkillsList.Add(objApplicantSkillsDetailsBO);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DisplayRejectedApplicant");
                throw ex;
            }
            return objRejectedApplicantsBO;
        }


        //public static string ProcViewRejectedApplicant = "usp_ViewRejectedApplicant";
        //public RejectedApplicantsBO DisplayRejectedApplicant(int iApplicantId, int iJobPostingId)
        //{
        //    DataSet objDataSet = null;
        //    RejectedApplicantsBO objRejectedApplicantsBO = null;
        //    ApplicantSkillsDetailsBO objApplicantSkillsDetailsBO = null;
        //    List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
        //    try
        //    {
        //        ProcParameterBO objDbParameter = new ProcParameterBO();
        //        objDbParameter.Direction = ParameterDirection.Input;
        //        objDbParameter.ParameterName = "@iApplicantId";
        //        objDbParameter.dbType = DbType.Int32;
        //        objDbParameter.ParameterValue = iApplicantId;
        //        ObjProcParameterBOList.Add(objDbParameter);

        //        objDbParameter = new ProcParameterBO();
        //        objDbParameter.Direction = ParameterDirection.Input;
        //        objDbParameter.ParameterName = "@iJobPostingId";
        //        objDbParameter.dbType = DbType.Int32;
        //        objDbParameter.ParameterValue = iJobPostingId;
        //        ObjProcParameterBOList.Add(objDbParameter);

        //        objDataSet = objDBAccess.execuitDataSet(ProcViewRejectedApplicant, ref ObjProcParameterBOList);
        //        if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            objRejectedApplicantsBO = new RejectedApplicantsBO();
        //            objRejectedApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
        //            objRejectedApplicantsBO.Title = objDataSet.Tables[0].Rows[0][1].ToString();
        //            objRejectedApplicantsBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
        //            objRejectedApplicantsBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
        //            objRejectedApplicantsBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
        //            objRejectedApplicantsBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
        //            objRejectedApplicantsBO.Gender = objDataSet.Tables[0].Rows[0][6].ToString();
        //            objRejectedApplicantsBO.IdType = objDataSet.Tables[0].Rows[0][7].ToString();
        //            objRejectedApplicantsBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
        //            objRejectedApplicantsBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();
        //            objRejectedApplicantsBO.Country = objDataSet.Tables[0].Rows[0][10].ToString();
        //            objRejectedApplicantsBO.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
        //            objRejectedApplicantsBO.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
        //            objRejectedApplicantsBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
        //            objRejectedApplicantsBO.English = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][14].ToString());
        //            objRejectedApplicantsBO.Kiswahili = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][15].ToString());
        //            objRejectedApplicantsBO.MotherTongue = objDataSet.Tables[0].Rows[0][16].ToString();
        //            objRejectedApplicantsBO.OtherLanguages = objDataSet.Tables[0].Rows[0][17].ToString();
        //            objRejectedApplicantsBO.Nationality = objDataSet.Tables[0].Rows[0][18].ToString();
        //            objRejectedApplicantsBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][19].ToString();
        //            objRejectedApplicantsBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
        //            objRejectedApplicantsBO.CV = objDataSet.Tables[0].Rows[0][21].ToString();
        //            objRejectedApplicantsBO.CVSavedName = objDataSet.Tables[0].Rows[0][22].ToString();
        //            objRejectedApplicantsBO.Address = objDataSet.Tables[0].Rows[0][23].ToString();
        //            objRejectedApplicantsBO.Photo = objDataSet.Tables[0].Rows[0][24].ToString();
        //            objRejectedApplicantsBO.PhotoSavedName = objDataSet.Tables[0].Rows[0][25].ToString();



        //            objRejectedApplicantsBO.Bachelors = objDataSet.Tables[0].Rows[0][26].ToString();
        //            objRejectedApplicantsBO.BachelorsSavedName = objDataSet.Tables[0].Rows[0][27].ToString();
        //            objRejectedApplicantsBO.Diploma = objDataSet.Tables[0].Rows[0][28].ToString();
        //            objRejectedApplicantsBO.DiplomaSavedName = objDataSet.Tables[0].Rows[0][29].ToString();
        //            objRejectedApplicantsBO.MSC = objDataSet.Tables[0].Rows[0][30].ToString();
        //            objRejectedApplicantsBO.MSCSavedName = objDataSet.Tables[0].Rows[0][31].ToString();
        //            objRejectedApplicantsBO.PHD = objDataSet.Tables[0].Rows[0][32].ToString();
        //            objRejectedApplicantsBO.PHDSavedName = objDataSet.Tables[0].Rows[0][33].ToString();
        //            objRejectedApplicantsBO.QuaStartDate = objDataSet.Tables[0].Rows[0][34].ToString();
        //            objRejectedApplicantsBO.QuaEndDate = objDataSet.Tables[0].Rows[0][35].ToString();
        //            objRejectedApplicantsBO.Discipline = objDataSet.Tables[0].Rows[0][36].ToString();
        //            objRejectedApplicantsBO.University = objDataSet.Tables[0].Rows[0][37].ToString();
        //            objRejectedApplicantsBO.QuaNationality = objDataSet.Tables[0].Rows[0][38].ToString();
        //            objRejectedApplicantsBO.Degree = objDataSet.Tables[0].Rows[0][39].ToString();
        //            objRejectedApplicantsBO.Class = objDataSet.Tables[0].Rows[0][40].ToString();



        //            objRejectedApplicantsBO.EmployerName = objDataSet.Tables[0].Rows[0][41].ToString();
        //            objRejectedApplicantsBO.TypeOfIndustry = objDataSet.Tables[0].Rows[0][42].ToString();
        //            objRejectedApplicantsBO.TelephoneNo = objDataSet.Tables[0].Rows[0][43].ToString();
        //            objRejectedApplicantsBO.TitleOfSupervisor = objDataSet.Tables[0].Rows[0][44].ToString();
        //            objRejectedApplicantsBO.JobTitle = objDataSet.Tables[0].Rows[0][45].ToString();
        //            objRejectedApplicantsBO.City = objDataSet.Tables[0].Rows[0][46].ToString();
        //            objRejectedApplicantsBO.EmpStartDate = objDataSet.Tables[0].Rows[0][47].ToString();
        //            objRejectedApplicantsBO.EmpEndDate = objDataSet.Tables[0].Rows[0][48].ToString();
        //            objRejectedApplicantsBO.Responsibility = objDataSet.Tables[0].Rows[0][49].ToString();
        //            objRejectedApplicantsBO.MonthlySalary = objDataSet.Tables[0].Rows[0][50].ToString();
        //            objRejectedApplicantsBO.NoticePeriod = objDataSet.Tables[0].Rows[0][51].ToString();
        //            objRejectedApplicantsBO.EmpAddress = objDataSet.Tables[0].Rows[0][52].ToString();
        //            objRejectedApplicantsBO.EmpFirstName = objDataSet.Tables[0].Rows[0][53].ToString();
        //            objRejectedApplicantsBO.SecondName = objDataSet.Tables[0].Rows[0][54].ToString();
        //            objRejectedApplicantsBO.Position = objDataSet.Tables[0].Rows[0][55].ToString();
        //            objRejectedApplicantsBO.RelationshipTOApplicant = objDataSet.Tables[0].Rows[0][56].ToString();
        //            objRejectedApplicantsBO.NameOfTheOrganization = objDataSet.Tables[0].Rows[0][57].ToString();
        //            objRejectedApplicantsBO.TelephoneContact = objDataSet.Tables[0].Rows[0][58].ToString();
        //            objRejectedApplicantsBO.EmpEmailAddress = objDataSet.Tables[0].Rows[0][59].ToString();

        //            objRejectedApplicantsBO.JobDescription = objDataSet.Tables[0].Rows[0][60].ToString();
        //            objRejectedApplicantsBO.Referer = objDataSet.Tables[0].Rows[0][61].ToString();

        //            objRejectedApplicantsBO.SpecialNeed = objDataSet.Tables[0].Rows[0][62].ToString();
        //            objRejectedApplicantsBO.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][63].ToString();
        //        }
        //        if (objDataSet != null && objDataSet.Tables[1].Rows.Count > 0)
        //        {
        //            objRejectedApplicantsBO.CommunicationSkills = objDataSet.Tables[1].Rows[0][0].ToString();
        //            objRejectedApplicantsBO.Experience = objDataSet.Tables[1].Rows[0][1].ToString();
        //            objRejectedApplicantsBO.Year = objDataSet.Tables[1].Rows[0][2].ToString();
        //            objRejectedApplicantsBO.Month = objDataSet.Tables[1].Rows[0][3].ToString();
        //        }
        //        if (objDataSet != null && objDataSet.Tables[2].Rows.Count > 0)
        //        {
        //            objRejectedApplicantsBO.SkillsList = new List<ApplicantSkillsDetailsBO>();
        //            for (int i = 0; i < objDataSet.Tables[2].Rows.Count; i++)
        //            {
        //                objApplicantSkillsDetailsBO = new ApplicantSkillsDetailsBO();
        //                objApplicantSkillsDetailsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[2].Rows[i][0].ToString());
        //                objApplicantSkillsDetailsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[2].Rows[i][1].ToString());
        //                objApplicantSkillsDetailsBO.Skill = objDataSet.Tables[2].Rows[i][2].ToString();
        //                objApplicantSkillsDetailsBO.RatingId = Convert.ToInt32(objDataSet.Tables[2].Rows[i][3].ToString());
        //                objApplicantSkillsDetailsBO.EvaluationComments = objDataSet.Tables[2].Rows[i][4].ToString();
        //                objRejectedApplicantsBO.SkillsList.Add(objApplicantSkillsDetailsBO);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objRejectedApplicantsBO;
        //}


        //public string ProcGetSkillsInfoList = "usp_SCH_getSkillsInfoList";
        //public List<RejectedApplicantsBO> getSkillsInfoList(int iApplicantId, int iJobPostingId)
        //{
        //    DataSet objDataSet = null;
        //    RejectedApplicantsBO objRejectedApplicantsBO = null;
        //    List<RejectedApplicantsBO> objRejectedApplicantsBOList = new List<RejectedApplicantsBO>();
        //    List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
        //    try
        //    {
        //        ProcParameterBO objProcParameter = new ProcParameterBO();
        //        objProcParameter = new ProcParameterBO();
        //        objProcParameter.Direction = ParameterDirection.Input;
        //        objProcParameter.ParameterName = "@iApplicantId";
        //        objProcParameter.dbType = DbType.Int32;
        //        objProcParameter.ParameterValue = iApplicantId;
        //        objProcParameterBOList.Add(objProcParameter);

        //        objProcParameter = new ProcParameterBO();
        //        objProcParameter.Direction = ParameterDirection.Input;
        //        objProcParameter.ParameterName = "@iJobPostingId";
        //        objProcParameter.dbType = DbType.Int32;
        //        objProcParameter.ParameterValue = iJobPostingId;
        //        objProcParameterBOList.Add(objProcParameter);


        //        objDataSet = objDBAccess.execuitDataSet(ProcGetSkillsInfoList, ref objProcParameterBOList);
        //        if (objDataSet != null && objDataSet.Tables.Count > 0)
        //        {
        //            for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
        //            {
        //                objRejectedApplicantsBO = new RejectedApplicantsBO();
        //                objRejectedApplicantsBO.ApplicantSkillId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
        //                objRejectedApplicantsBO.Skill = objDataSet.Tables[0].Rows[i][1].ToString();
        //                objRejectedApplicantsBO.RatingId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][2].ToString());
        //                objRejectedApplicantsBO.EvaluationComments = objDataSet.Tables[0].Rows[i][3].ToString();
        //                objRejectedApplicantsBOList.Add(objRejectedApplicantsBO);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objRejectedApplicantsBOList;
        //}

    }
}

