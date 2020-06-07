using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class SelectedListDAL
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

        public static string ProcgetSelectedList = "usp_SCH_getSelectedApplicantsList";
        public List<SelectedListBO> getSelectedList(int iJobId)
        {
            DataSet objDataSet = null;
            SelectedListBO objSelectedListBO = null;
            List<SelectedListBO> objSelectedListBOList = new List<SelectedListBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcgetSelectedList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objSelectedListBO = new SelectedListBO();
                        objSelectedListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objSelectedListBO.ApplicantName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objSelectedListBO.PhoneNumber = objDataSet.Tables[0].Rows[i][2].ToString();
                        objSelectedListBO.EmailAddress = objDataSet.Tables[0].Rows[i][3].ToString();
                        objSelectedListBO.Address = objDataSet.Tables[0].Rows[i][4].ToString();
                        objSelectedListBO.Status = objDataSet.Tables[0].Rows[i][5].ToString();
                       // objSelectedListBO.Comments = objDataSet.Tables[0].Rows[i][6].ToString();
                        objSelectedListBO.JobId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][6].ToString());
                        objSelectedListBOList.Add(objSelectedListBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getSelectedList");
                throw ex;
            }
            return objSelectedListBOList;
        }

        public static string ProcViewSelectedApplicant = "usp_SCH_ViewSelectedList";
        public SelectedListBO ViewSelectedApplicant(int iApplicantId, int iJobPostingId)
        {
            DataSet objDataSet = null;
            SelectedListBO objSelectedListBO = null;
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

                objDataSet = objDBAccess.execuitDataSet(ProcViewSelectedApplicant, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objSelectedListBO = new SelectedListBO();
                    objSelectedListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objSelectedListBO.Title = objDataSet.Tables[0].Rows[0][1].ToString();
                    objSelectedListBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objSelectedListBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objSelectedListBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
                    objSelectedListBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
                    objSelectedListBO.Gender = objDataSet.Tables[0].Rows[0][6].ToString();
                    objSelectedListBO.IdType = objDataSet.Tables[0].Rows[0][7].ToString();
                    objSelectedListBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
                    objSelectedListBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();
                    objSelectedListBO.Country = objDataSet.Tables[0].Rows[0][10].ToString();
                    objSelectedListBO.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
                    objSelectedListBO.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
                    objSelectedListBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
                    objSelectedListBO.MotherTongue = objDataSet.Tables[0].Rows[0][14].ToString();
                    objSelectedListBO.Nationality = objDataSet.Tables[0].Rows[0][15].ToString();
                    objSelectedListBO.County = objDataSet.Tables[0].Rows[0][16].ToString();
                    objSelectedListBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][17].ToString();
                    objSelectedListBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][18].ToString();
                    objSelectedListBO.CV = objDataSet.Tables[0].Rows[0][19].ToString();
                    objSelectedListBO.CVSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
                    objSelectedListBO.SpecialNeed = objDataSet.Tables[0].Rows[0][21].ToString();
                    objSelectedListBO.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][22].ToString();
                    objSelectedListBO.Address = objDataSet.Tables[0].Rows[0][23].ToString();
                    objSelectedListBO.Photo = objDataSet.Tables[0].Rows[0][24].ToString();
                    objSelectedListBO.PhotoSavedName = objDataSet.Tables[0].Rows[0][25].ToString();

                    if (objDataSet != null && objDataSet.Tables[1].Rows.Count > 0)
                    {
                        objSelectedListBO.ApplicantRelationList = new List<ApplicantRelationBO>();
                        for (int i = 0; i < objDataSet.Tables[1].Rows.Count; i++)
                        {
                            objApplicantRelationBO = new ApplicantRelationBO();
                            objApplicantRelationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[1].Rows[i][0].ToString());
                            objApplicantRelationBO.RelationId = Convert.ToInt32(objDataSet.Tables[1].Rows[i][1].ToString());
                            objApplicantRelationBO.AnyoneWorkinWIK = objDataSet.Tables[1].Rows[i][2].ToString();
                            objApplicantRelationBO.RelativeName = objDataSet.Tables[1].Rows[i][3].ToString();
                            objApplicantRelationBO.Relationship = objDataSet.Tables[1].Rows[i][4].ToString();
                            objSelectedListBO.ApplicantRelationList.Add(objApplicantRelationBO);
                        }
                    }

                    if (objDataSet != null && objDataSet.Tables[2].Rows.Count > 0)
                    {
                        objSelectedListBO.ApplicantLanguageList = new List<LanguageSpokenBO>();
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
                            objSelectedListBO.ApplicantLanguageList.Add(objLanguageSpokenBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[3].Rows.Count > 0)
                    {
                        objSelectedListBO.ApplicantQualificationList = new List<ApplicantQualificationBO>();
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
                            objSelectedListBO.ApplicantQualificationList.Add(objApplicantQualificationBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[4].Rows.Count > 0)
                    {
                        objSelectedListBO.ApplicantEmploymentList = new List<ApplicantEmploymentHistoryBO>();
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
                            objSelectedListBO.ApplicantEmploymentList.Add(objApplicantEmploymentHistoryBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[5].Rows.Count > 0)
                    {
                        objSelectedListBO.ApplicantRefereesList = new List<ApplicantRefereesBO>();
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
                            objSelectedListBO.ApplicantRefereesList.Add(objApplicantRefereesBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[6].Rows.Count > 0)
                    {
                        objSelectedListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[6].Rows[0][0].ToString());
                        objSelectedListBO.ApplicantMotivationId = Convert.ToInt32(objDataSet.Tables[6].Rows[0][1].ToString());
                        objSelectedListBO.MembershipData = objDataSet.Tables[6].Rows[0][2].ToString();
                        objSelectedListBO.NameofProfessionalBody = objDataSet.Tables[6].Rows[0][3].ToString();
                        objSelectedListBO.MembershipNumber = objDataSet.Tables[6].Rows[0][4].ToString();
                        objSelectedListBO.ValidityData = objDataSet.Tables[6].Rows[0][5].ToString();
                        objSelectedListBO.JobDescription = objDataSet.Tables[6].Rows[0][6].ToString();
                        objSelectedListBO.Referer = objDataSet.Tables[6].Rows[0][7].ToString();
                        objSelectedListBO.ApplicationNote = objDataSet.Tables[6].Rows[0][8].ToString();
                    }

                    if (objDataSet != null && objDataSet.Tables[7].Rows.Count > 0)
                    {
                        objSelectedListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[7].Rows[0][0].ToString());
                        objSelectedListBO.TerminatedId = objDataSet.Tables[7].Rows[0][1].ToString();
                        objSelectedListBO.Terminatation = objDataSet.Tables[7].Rows[0][2].ToString();
                        objSelectedListBO.MisconductId = objDataSet.Tables[7].Rows[0][3].ToString();
                        objSelectedListBO.Misconduct = objDataSet.Tables[7].Rows[0][4].ToString();
                        objSelectedListBO.ManagementId = objDataSet.Tables[7].Rows[0][5].ToString();
                        objSelectedListBO.Management = objDataSet.Tables[7].Rows[0][6].ToString();
                        objSelectedListBO.InvestigationId = objDataSet.Tables[7].Rows[0][7].ToString();
                        objSelectedListBO.Investigation = objDataSet.Tables[7].Rows[0][8].ToString();


                        objSelectedListBO.CriminalOffenceId = objDataSet.Tables[7].Rows[0][9].ToString();
                        objSelectedListBO.CriminalOffence = objDataSet.Tables[7].Rows[0][10].ToString();
                        objSelectedListBO.ConvictionsId = objDataSet.Tables[7].Rows[0][11].ToString();
                        objSelectedListBO.Convictions = objDataSet.Tables[7].Rows[0][12].ToString();
                        objSelectedListBO.CorruptionId = objDataSet.Tables[7].Rows[0][13].ToString();
                        objSelectedListBO.Corruption = objDataSet.Tables[7].Rows[0][14].ToString();
                        objSelectedListBO.DisciplinaryId = objDataSet.Tables[7].Rows[0][15].ToString();
                        objSelectedListBO.Disciplinary = objDataSet.Tables[7].Rows[0][16].ToString();
                        objSelectedListBO.RelationToChildId = objDataSet.Tables[7].Rows[0][17].ToString();
                        objSelectedListBO.RelationToChild = objDataSet.Tables[7].Rows[0][18].ToString();
                        objSelectedListBO.RelationToAdultId = objDataSet.Tables[7].Rows[0][19].ToString();
                        objSelectedListBO.RelationToAdult = objDataSet.Tables[7].Rows[0][20].ToString();
                        objSelectedListBO.RelativeId = objDataSet.Tables[7].Rows[0][21].ToString();
                        objSelectedListBO.DealingsWithWIKId = objDataSet.Tables[7].Rows[0][22].ToString();
                        objSelectedListBO.DealingsWithWIK = objDataSet.Tables[7].Rows[0][23].ToString();
                        objSelectedListBO.Declarationinfo = Convert.ToBoolean(objDataSet.Tables[7].Rows[0][24].ToString());
                        objSelectedListBO.Statement = Convert.ToBoolean(objDataSet.Tables[7].Rows[0][25].ToString());

                        objSelectedListBO.DeclarationID = Convert.ToInt32(objDataSet.Tables[7].Rows[0][26].ToString());
                    }


                    if (objDataSet != null && objDataSet.Tables[8].Rows.Count > 0)
                    {
                        objSelectedListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[8].Rows[0][0].ToString());
                        objSelectedListBO.CommunicationSkills = objDataSet.Tables[8].Rows[0][1].ToString();
                        objSelectedListBO.Experience = objDataSet.Tables[8].Rows[0][2].ToString();
                        objSelectedListBO.Year = objDataSet.Tables[8].Rows[0][3].ToString();
                        objSelectedListBO.Month = objDataSet.Tables[8].Rows[0][4].ToString();
                    }
                    if (objDataSet != null && objDataSet.Tables[9].Rows.Count > 0)
                    {
                        objSelectedListBO.SkillsList = new List<ApplicantSkillsDetailsBO>();
                        for (int i = 0; i < objDataSet.Tables[9].Rows.Count; i++)
                        {
                            objApplicantSkillsDetailsBO = new ApplicantSkillsDetailsBO();
                            objApplicantSkillsDetailsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[9].Rows[i][0].ToString());
                            objApplicantSkillsDetailsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[9].Rows[i][1].ToString());
                            objApplicantSkillsDetailsBO.Skill = objDataSet.Tables[9].Rows[i][2].ToString();
                            objApplicantSkillsDetailsBO.RatingId = Convert.ToInt32(objDataSet.Tables[9].Rows[i][3].ToString());
                            objApplicantSkillsDetailsBO.EvaluationComments = objDataSet.Tables[9].Rows[i][4].ToString();
                            objSelectedListBO.SkillsList.Add(objApplicantSkillsDetailsBO);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "ViewSelectedApplicant");
                throw ex;
            }
            return objSelectedListBO; ;
        }


        //public static string ProcViewSelectedApplicant = "usp_SCH_ViewSelectedList";
        //public SelectedListBO ViewSelectedApplicant(int iApplicantId, int iJobPostingId)
        //{
        //    DataSet objDataSet = null;
        //    SelectedListBO objSelectedListBO = null;
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

        //        objDataSet = objDBAccess.execuitDataSet(ProcViewSelectedApplicant, ref ObjProcParameterBOList);
        //        if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            objSelectedListBO = new SelectedListBO();
        //            objSelectedListBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
        //            objSelectedListBO.Title = objDataSet.Tables[0].Rows[0][1].ToString();
        //            objSelectedListBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
        //            objSelectedListBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
        //            objSelectedListBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
        //            objSelectedListBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
        //            objSelectedListBO.Gender = objDataSet.Tables[0].Rows[0][6].ToString();
        //            objSelectedListBO.IdType = objDataSet.Tables[0].Rows[0][7].ToString();
        //            objSelectedListBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
        //            objSelectedListBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();
        //            objSelectedListBO.Country = objDataSet.Tables[0].Rows[0][10].ToString();
        //            objSelectedListBO.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
        //            objSelectedListBO.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
        //            objSelectedListBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
        //            objSelectedListBO.English = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][14].ToString());
        //            objSelectedListBO.Kiswahili = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][15].ToString());
        //            objSelectedListBO.MotherTongue = objDataSet.Tables[0].Rows[0][16].ToString();
        //            objSelectedListBO.OtherLanguages = objDataSet.Tables[0].Rows[0][17].ToString();
        //            objSelectedListBO.Nationality = objDataSet.Tables[0].Rows[0][18].ToString();
        //            objSelectedListBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][19].ToString();
        //            objSelectedListBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
        //            objSelectedListBO.CV = objDataSet.Tables[0].Rows[0][21].ToString();
        //            objSelectedListBO.CVSavedName = objDataSet.Tables[0].Rows[0][22].ToString();
        //            objSelectedListBO.Address = objDataSet.Tables[0].Rows[0][23].ToString();
        //            objSelectedListBO.Photo = objDataSet.Tables[0].Rows[0][24].ToString();
        //            objSelectedListBO.PhotoSavedName = objDataSet.Tables[0].Rows[0][25].ToString();



        //            objSelectedListBO.Bachelors = objDataSet.Tables[0].Rows[0][26].ToString();
        //            objSelectedListBO.BachelorsSavedName = objDataSet.Tables[0].Rows[0][27].ToString();
        //            objSelectedListBO.Diploma = objDataSet.Tables[0].Rows[0][28].ToString();
        //            objSelectedListBO.DiplomaSavedName = objDataSet.Tables[0].Rows[0][29].ToString();
        //            objSelectedListBO.MSC = objDataSet.Tables[0].Rows[0][30].ToString();
        //            objSelectedListBO.MSCSavedName = objDataSet.Tables[0].Rows[0][31].ToString();
        //            objSelectedListBO.PHD = objDataSet.Tables[0].Rows[0][32].ToString();
        //            objSelectedListBO.PHDSavedName = objDataSet.Tables[0].Rows[0][33].ToString();
        //            objSelectedListBO.QuaStartDate = objDataSet.Tables[0].Rows[0][34].ToString();
        //            objSelectedListBO.QuaEndDate = objDataSet.Tables[0].Rows[0][35].ToString();
        //            objSelectedListBO.Discipline = objDataSet.Tables[0].Rows[0][36].ToString();
        //            objSelectedListBO.University = objDataSet.Tables[0].Rows[0][37].ToString();
        //            objSelectedListBO.QuaNationality = objDataSet.Tables[0].Rows[0][38].ToString();
        //            objSelectedListBO.Degree = objDataSet.Tables[0].Rows[0][39].ToString();
        //            objSelectedListBO.Class = objDataSet.Tables[0].Rows[0][40].ToString();



        //            objSelectedListBO.EmployerName = objDataSet.Tables[0].Rows[0][41].ToString();
        //            objSelectedListBO.TypeOfIndustry = objDataSet.Tables[0].Rows[0][42].ToString();
        //            objSelectedListBO.TelephoneNo = objDataSet.Tables[0].Rows[0][43].ToString();
        //            objSelectedListBO.TitleOfSupervisor = objDataSet.Tables[0].Rows[0][44].ToString();
        //            objSelectedListBO.JobTitle = objDataSet.Tables[0].Rows[0][45].ToString();
        //            objSelectedListBO.City = objDataSet.Tables[0].Rows[0][46].ToString();
        //            objSelectedListBO.EmpStartDate = objDataSet.Tables[0].Rows[0][47].ToString();
        //            objSelectedListBO.EmpEndDate = objDataSet.Tables[0].Rows[0][48].ToString();
        //            objSelectedListBO.Responsibility = objDataSet.Tables[0].Rows[0][49].ToString();
        //            objSelectedListBO.MonthlySalary = objDataSet.Tables[0].Rows[0][50].ToString();
        //            objSelectedListBO.NoticePeriod = objDataSet.Tables[0].Rows[0][51].ToString();
        //            objSelectedListBO.EmpAddress = objDataSet.Tables[0].Rows[0][52].ToString();
        //            objSelectedListBO.EmpFirstName = objDataSet.Tables[0].Rows[0][53].ToString();
        //            objSelectedListBO.SecondName = objDataSet.Tables[0].Rows[0][54].ToString();
        //            objSelectedListBO.Position = objDataSet.Tables[0].Rows[0][55].ToString();
        //            objSelectedListBO.RelationshipTOApplicant = objDataSet.Tables[0].Rows[0][56].ToString();
        //            objSelectedListBO.NameOfTheOrganization = objDataSet.Tables[0].Rows[0][57].ToString();
        //            objSelectedListBO.TelephoneContact = objDataSet.Tables[0].Rows[0][58].ToString();
        //            objSelectedListBO.EmpEmailAddress = objDataSet.Tables[0].Rows[0][59].ToString();

        //            objSelectedListBO.JobDescription = objDataSet.Tables[0].Rows[0][60].ToString();
        //            objSelectedListBO.Referer = objDataSet.Tables[0].Rows[0][61].ToString();

        //            objSelectedListBO.SpecialNeed = objDataSet.Tables[0].Rows[0][62].ToString();
        //            objSelectedListBO.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][63].ToString();
        //        }
        //        if (objDataSet != null && objDataSet.Tables[1].Rows.Count > 0)
        //        {
        //            objSelectedListBO.CommunicationSkills = objDataSet.Tables[1].Rows[0][0].ToString();
        //            objSelectedListBO.Experience = objDataSet.Tables[1].Rows[0][1].ToString();
        //            objSelectedListBO.Year = objDataSet.Tables[1].Rows[0][2].ToString();
        //            objSelectedListBO.Month = objDataSet.Tables[1].Rows[0][3].ToString();
        //        }
        //        if (objDataSet != null && objDataSet.Tables[2].Rows.Count > 0)
        //        {
        //            objSelectedListBO.SkillsList = new List<ApplicantSkillsDetailsBO>();
        //            for (int i = 0; i < objDataSet.Tables[2].Rows.Count; i++)
        //            {
        //                objApplicantSkillsDetailsBO = new ApplicantSkillsDetailsBO();
        //                objApplicantSkillsDetailsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[2].Rows[i][0].ToString());
        //                objApplicantSkillsDetailsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[2].Rows[i][1].ToString());
        //                objApplicantSkillsDetailsBO.Skill = objDataSet.Tables[2].Rows[i][2].ToString();
        //                objApplicantSkillsDetailsBO.RatingId = Convert.ToInt32(objDataSet.Tables[2].Rows[i][3].ToString());
        //                objApplicantSkillsDetailsBO.EvaluationComments = objDataSet.Tables[2].Rows[i][4].ToString();
        //                objSelectedListBO.SkillsList.Add(objApplicantSkillsDetailsBO);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objSelectedListBO; ;
        //}

        //public string ProcGetSkillsInfoList = "usp_SCH_getSkillsInfoList";
        //public List<SelectedListBO> getSkillsInfoList(int iApplicantId, int iJobPostingId)
        //{
        //    DataSet objDataSet = null;
        //    SelectedListBO objSelectedListBO = null;
        //    ProcParameterBO objProcParameter = null;
        //    List<SelectedListBO> objSelectedListBOList = new List<SelectedListBO>();
        //    List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
        //    try
        //    {

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
        //                objSelectedListBO = new SelectedListBO();
        //                objSelectedListBO.ApplicantSkillId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
        //                objSelectedListBO.Skill = objDataSet.Tables[0].Rows[i][1].ToString();
        //                objSelectedListBO.RatingId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][2].ToString());
        //                objSelectedListBO.EvaluationComments = objDataSet.Tables[0].Rows[i][3].ToString();
        //                objSelectedListBOList.Add(objSelectedListBO);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objSelectedListBOList;
        //}
    }

}

