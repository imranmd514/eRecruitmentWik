using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class ApplicantDashboardDAL
    {
        DBAccess objDBAccess = new DBAccess();
        public static string ProcTitleList = "usp_SCH_dropdownTitle";
        public List<CommonDropDownBO> TitleList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcTitleList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "TitleList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }

        public static string ProcCountryList = "usp_SCH_dropdownCountry";
        public List<CommonDropDownBO> CountryList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcCountryList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "CountryList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }

        public static string ProcGenderList = "usp_SCH_DropdownGender";
        public List<CommonDropDownBO> GenderList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGenderList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "GenderList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }

        public static string ProcSavePersonalInformation = "usp_SCH_savePersonalInformation";
        public string SavePersonalInformation(ApplicantPersonalInformationBO objApplicantPersonalInformationBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strTitle";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.Title;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strFirstName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.FirstName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMiddleName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.MiddleName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLastName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.LastName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDateOfBirth";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.DateOfBirth;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCitizenship";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.Citizenship;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strGender";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.Gender;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.Address;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iCountry";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.Country;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmailAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.EmailAddress;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPhoneNumber";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.PhoneNumber;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAlternativePhoneNumber";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.AlternativePhoneNumber;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLanguageSpoken";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.LanguageSpoken;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strNationality";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.Nationality;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strApplicationLetter";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.ApplicationLetter;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSaveApplicationLetter";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.SaveApplicationLetter;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strResume";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.Resume;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strResumeSaved";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.ResumeSaved;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcSavePersonalInformation, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SavePersonalInformation");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcSaveApplicantQualification = "usp_SCH_saveQualification";
        public string SaveApplicantQualification(ApplicantQualificationBO objApplicantQualificationBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantQualificationId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantQualificationBO.ApplicantQualificationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantQualificationBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strBachelors";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.Bachelors;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSaveBachelors";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.SaveBachelors;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDiploma";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.Diploma;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSaveDiploma";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.SaveDiploma;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMSC";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.MSC;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSaveMSC";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.SaveMSC;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPHD";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.PHD;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSavePHD";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.SavePHD;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strQuaStartDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.QuaStartDate;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strQuaEndDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.QuaEndDate;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDiscipline";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.Discipline;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strUniversity";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.University;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strQuaNationality";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.QuaNationality;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDegree";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.Degree;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strClass";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.Class;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objApplicantQualificationBO.IsActive;
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

                objDBAccess.executeNonQuery(ProcSaveApplicantQualification, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveApplicantQualification");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        public static string ProcSaveEmploymentHistory = "usp_SCH_saveEmploymentHistory";
        public string SaveApplicantEmploymentHistory(ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iEmploymentHistoryId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.EmploymentHistoryId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strTypeOfIndustry";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.TypeOfIndustry;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmpAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.EmpAddress;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCity";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.City;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strTelephoneNo";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.TelephoneNo;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobTitle";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.JobTitle;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strTitleOfSupervisor";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.TitleOfSupervisor;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@StartDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.EmpStartDate;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmpEndDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.EmpEndDate;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strResponsibility";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.Responsibility;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMonthlySalary";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.MonthlySalary;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strNoticePeriod";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.NoticePeriod;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmpFirstName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.EmpFirstName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSecondName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.SecondName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPosition";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.Position;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strRelationshipTOApplicant";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.RelationshipTOApplicant;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strNameOfTheOrganization";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.NameOfTheOrganization;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strTelephoneContact";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.TelephoneContact;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmpEmailAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.EmpEmailAddress;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcSaveEmploymentHistory, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveApplicantEmploymentHistory");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        public static string ProcSaveApplicantMotivation = "usp_SCH_saveMotivationSkillsAndExperience";
        public string SaveApplicantMotivation(ApplicantMotivationBO objApplicantMotivationBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantMotivationId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantMotivationBO.ApplicantMotivationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantMotivationBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobDescription";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantMotivationBO.JobDescription;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strFriends";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantMotivationBO.Friends;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strWIKWebsite";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantMotivationBO.WIKWebsite;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSocialMedia";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantMotivationBO.SocialMedia;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objApplicantMotivationBO.IsActive;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iUserId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = iUserId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strResult";
                objDBparameter.dbType = DbType.String;
                objDBparameter.Size = 100;
                objProcParameterBOList.Add(objDBparameter);


                objDBAccess.executeNonQuery(ProcSaveApplicantMotivation, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveApplicantMotivation");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        public static string ProcEditPersonalInformation = "usp_editApplicantPersonalInformation";
        public ApplicantPersonalInformationBO editPersonalInformation(int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantPersonalInformationBO objApplicantPersonalInformationBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditPersonalInformation, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objApplicantPersonalInformationBO = new ApplicantPersonalInformationBO();
                    objApplicantPersonalInformationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objApplicantPersonalInformationBO.Title = objDataSet.Tables[0].Rows[0][1].ToString();
                    objApplicantPersonalInformationBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objApplicantPersonalInformationBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objApplicantPersonalInformationBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
                    objApplicantPersonalInformationBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
                    objApplicantPersonalInformationBO.Citizenship = objDataSet.Tables[0].Rows[0][6].ToString();
                    objApplicantPersonalInformationBO.Gender = objDataSet.Tables[0].Rows[0][7].ToString();
                    objApplicantPersonalInformationBO.Address = objDataSet.Tables[0].Rows[0][8].ToString();
                    objApplicantPersonalInformationBO.Country = Convert.ToInt32(objDataSet.Tables[0].Rows[0][9].ToString());
                    objApplicantPersonalInformationBO.EmailAddress = objDataSet.Tables[0].Rows[0][10].ToString();
                    objApplicantPersonalInformationBO.PhoneNumber = objDataSet.Tables[0].Rows[0][11].ToString();
                    objApplicantPersonalInformationBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
                    objApplicantPersonalInformationBO.LanguageSpoken = objDataSet.Tables[0].Rows[0][13].ToString();
                    objApplicantPersonalInformationBO.Nationality = objDataSet.Tables[0].Rows[0][14].ToString();
                    objApplicantPersonalInformationBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][15].ToString();
                    objApplicantPersonalInformationBO.Resume = objDataSet.Tables[0].Rows[0][16].ToString();
                    objApplicantPersonalInformationBO.Photo = objDataSet.Tables[0].Rows[0][17].ToString();

                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "editPersonalInformation");
                throw ex;
            }
            return objApplicantPersonalInformationBO;
        }

        public static string ProcEditApplicantQualification = "usp_editApplicantQualification";
        public ApplicantQualificationBO editQualification(int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantQualificationBO objApplicantQualificationBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditApplicantQualification, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objApplicantQualificationBO = new ApplicantQualificationBO();
                    objApplicantQualificationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objApplicantQualificationBO.Bachelors = objDataSet.Tables[0].Rows[0][1].ToString();
                    objApplicantQualificationBO.Diploma = objDataSet.Tables[0].Rows[0][2].ToString();
                    objApplicantQualificationBO.MSC = objDataSet.Tables[0].Rows[0][3].ToString();
                    objApplicantQualificationBO.PHD = objDataSet.Tables[0].Rows[0][4].ToString();
                    objApplicantQualificationBO.QuaStartDate = objDataSet.Tables[0].Rows[0][5].ToString();
                    objApplicantQualificationBO.QuaEndDate = objDataSet.Tables[0].Rows[0][6].ToString();
                    objApplicantQualificationBO.Discipline = objDataSet.Tables[0].Rows[0][7].ToString();
                    objApplicantQualificationBO.University = objDataSet.Tables[0].Rows[0][8].ToString();
                    objApplicantQualificationBO.QuaNationality = objDataSet.Tables[0].Rows[0][9].ToString();
                    objApplicantQualificationBO.Degree = objDataSet.Tables[0].Rows[0][10].ToString();
                    objApplicantQualificationBO.Class = objDataSet.Tables[0].Rows[0][11].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "editQualification");
                throw ex;
            }
            return objApplicantQualificationBO;
        }

        public static string ProcEditEmploymentHistory = "usp_editEmploymentHistory";
        public ApplicantEmploymentHistoryBO editEmploymentHistory(int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditEmploymentHistory, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objApplicantEmploymentHistoryBO = new ApplicantEmploymentHistoryBO();
                    objApplicantEmploymentHistoryBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objApplicantEmploymentHistoryBO.EmployerName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objApplicantEmploymentHistoryBO.TypeOfIndustry = objDataSet.Tables[0].Rows[0][2].ToString();
                    objApplicantEmploymentHistoryBO.EmpAddress = objDataSet.Tables[0].Rows[0][3].ToString();
                    objApplicantEmploymentHistoryBO.City = objDataSet.Tables[0].Rows[0][4].ToString();
                    objApplicantEmploymentHistoryBO.TelephoneNo = objDataSet.Tables[0].Rows[0][5].ToString();
                    objApplicantEmploymentHistoryBO.JobTitle = objDataSet.Tables[0].Rows[0][6].ToString();
                    objApplicantEmploymentHistoryBO.TitleOfSupervisor = objDataSet.Tables[0].Rows[0][7].ToString();
                    objApplicantEmploymentHistoryBO.EmpStartDate = objDataSet.Tables[0].Rows[0][8].ToString();
                    objApplicantEmploymentHistoryBO.EmpEndDate = objDataSet.Tables[0].Rows[0][9].ToString();
                    objApplicantEmploymentHistoryBO.Responsibility = objDataSet.Tables[0].Rows[0][10].ToString();
                    objApplicantEmploymentHistoryBO.MonthlySalary = objDataSet.Tables[0].Rows[0][11].ToString();
                    objApplicantEmploymentHistoryBO.NoticePeriod = objDataSet.Tables[0].Rows[0][12].ToString();
                    objApplicantEmploymentHistoryBO.EmpFirstName = objDataSet.Tables[0].Rows[0][13].ToString();
                    objApplicantEmploymentHistoryBO.SecondName = objDataSet.Tables[0].Rows[0][14].ToString();
                    objApplicantEmploymentHistoryBO.Position = objDataSet.Tables[0].Rows[0][15].ToString();
                    objApplicantEmploymentHistoryBO.RelationshipTOApplicant = objDataSet.Tables[0].Rows[0][16].ToString();
                    objApplicantEmploymentHistoryBO.NameOfTheOrganization = objDataSet.Tables[0].Rows[0][17].ToString();
                    objApplicantEmploymentHistoryBO.TelephoneContact = objDataSet.Tables[0].Rows[0][18].ToString();
                    objApplicantEmploymentHistoryBO.EmpEmailAddress = objDataSet.Tables[0].Rows[0][19].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "editEmploymentHistory");
                throw ex;
            }
            return objApplicantEmploymentHistoryBO;
        }

        public static string ProcEditMotivation = "usp_editMotivation";
        public ApplicantMotivationBO EditMotivation(int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantMotivationBO objApplicantMotivationBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditMotivation, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objApplicantMotivationBO = new ApplicantMotivationBO();
                    objApplicantMotivationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objApplicantMotivationBO.JobDescription = objDataSet.Tables[0].Rows[0][1].ToString();
                    objApplicantMotivationBO.Friends = objDataSet.Tables[0].Rows[0][2].ToString();
                    objApplicantMotivationBO.WIKWebsite = objDataSet.Tables[0].Rows[0][3].ToString();
                    objApplicantMotivationBO.SocialMedia = objDataSet.Tables[0].Rows[0][4].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditMotivation");
                throw ex;
            }
            return objApplicantMotivationBO;
        }
    }
}



