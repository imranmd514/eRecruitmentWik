using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;


namespace DataAccessLayer
{
    public class ApplicantRegistrationDAL
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

        public static string ProcRefererList = "usp_SCH_dropdownApplicantReference";
        public List<CommonDropDownBO> RefererList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcRefererList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "RefererList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }

        public static string ProcIdTypeList = "usp_SCH_DropdownIdType";
        public List<CommonDropDownBO> IdTypeList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcIdTypeList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "IdTypeList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }


        public static string ProcGetApplicantList = "usp_SCH_GetApplicantRegistration";
        public List<ApplicantRegistrationBO> getApplicantsList()
        {
            DataSet objDataSet = null;
            ApplicantRegistrationBO objApplicantRegistrationBO = null;
            List<ApplicantRegistrationBO> objApplicantRegistrationBOList = new List<ApplicantRegistrationBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetApplicantList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApplicantRegistrationBO = new ApplicantRegistrationBO();
                        objApplicantRegistrationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApplicantRegistrationBO.FirstName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objApplicantRegistrationBO.EmailAddress = objDataSet.Tables[0].Rows[i][2].ToString();
                        objApplicantRegistrationBO.PhoneNumber = objDataSet.Tables[0].Rows[i][3].ToString();
                        objApplicantRegistrationBO.Address = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApplicantRegistrationBOList.Add(objApplicantRegistrationBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getApplicantsList");
                throw ex;
            }
            return objApplicantRegistrationBOList;
        }

        //Save Applicant

        public static string ProcSaveApplicantRegistration = "usp_SCH_saveApplicantRegistrations";
        public string SaveorUpdateApplicantRegistration(ApplicantRegistrationBO objApplicantRegistrationBO, string strPassword, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPassword";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = strPassword;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iTitleId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.TitleId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strFirstName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.FirstName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMiddleName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.MiddleName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLastName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.LastName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDateOfBirth";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.DateOfBirth;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iGender";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.GenderId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iCitizenship";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.IdTypeMasterId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCitizenShipIdCopy";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.CitizenShipIdCopy;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCitizenShipIdCopySavedName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.CitizenShipIdCopySavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iCountry";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.CountryId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmailAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.EmailAddress;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPhoneNumber";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.PhoneNumber;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAlternativePhoneNumber";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.AlternativePhoneNumber;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMotherTongue";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.MotherTongue;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strNationality";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.Nationality;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strApplicationLetter";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.ApplicationLetter;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSaveApplicationLetter";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.ApplicationLetterSavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCV";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.CV;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCVSavedName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.CVSavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iSpecialNeed";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.SpecialNeed;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.Address;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSpecialNeedDetails";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.SpecialNeedDetails;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPhoto";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.Photo;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPhotoSavedName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.PhotoSavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCounty";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.County;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objApplicantRegistrationBO.IsActive;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iUserId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = iUserId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strType";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = "Create";
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Output;
                objDBparameter.ParameterName = "@strResult";
                objDBparameter.dbType = DbType.String;
                objDBparameter.Size = 100;
                objProcParameterBOList.Add(objDBparameter);

                objDBAccess.executeNonQuery(ProcSaveApplicantRegistration, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateApplicantRegistration");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        //Edit Applicant

        public static string ProcEditApplicant = "usp_SCH_EditApplicantRegistrationDetails";
        public ApplicantRegistrationBO EditApplicantDetails(int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantRegistrationBO objApplicantRegistrationBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditApplicant, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objApplicantRegistrationBO = new ApplicantRegistrationBO();
                    objApplicantRegistrationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objApplicantRegistrationBO.TitleId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][1].ToString());
                    objApplicantRegistrationBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objApplicantRegistrationBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objApplicantRegistrationBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
                    objApplicantRegistrationBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
                    objApplicantRegistrationBO.GenderId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][6].ToString());
                    objApplicantRegistrationBO.Citizenship = objDataSet.Tables[0].Rows[0][7].ToString();
                    objApplicantRegistrationBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
                    objApplicantRegistrationBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();

                    objApplicantRegistrationBO.CountryId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][10].ToString());
                    objApplicantRegistrationBO.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
                    objApplicantRegistrationBO.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
                    objApplicantRegistrationBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
                    objApplicantRegistrationBO.English = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][14].ToString());
                    objApplicantRegistrationBO.Kiswahili = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][15].ToString());
                    objApplicantRegistrationBO.MotherTongue = objDataSet.Tables[0].Rows[0][16].ToString();
                    objApplicantRegistrationBO.OtherLanguages = objDataSet.Tables[0].Rows[0][17].ToString();
                    objApplicantRegistrationBO.Nationality = objDataSet.Tables[0].Rows[0][18].ToString();

                    objApplicantRegistrationBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][19].ToString();
                    objApplicantRegistrationBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
                    objApplicantRegistrationBO.CV = objDataSet.Tables[0].Rows[0][21].ToString();
                    objApplicantRegistrationBO.CVSavedName = objDataSet.Tables[0].Rows[0][22].ToString();
                    objApplicantRegistrationBO.SpecialNeed = Convert.ToInt32(objDataSet.Tables[0].Rows[0][23].ToString());
                    objApplicantRegistrationBO.Address = objDataSet.Tables[0].Rows[0][24].ToString();
                    objApplicantRegistrationBO.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][25].ToString();
                    objApplicantRegistrationBO.Photo = objDataSet.Tables[0].Rows[0][26].ToString();
                    objApplicantRegistrationBO.PhotoSavedName = objDataSet.Tables[0].Rows[0][27].ToString();



                    objApplicantRegistrationBO.Bachelors = objDataSet.Tables[0].Rows[0][28].ToString();
                    objApplicantRegistrationBO.BachelorsSavedName = objDataSet.Tables[0].Rows[0][29].ToString();
                    objApplicantRegistrationBO.Diploma = objDataSet.Tables[0].Rows[0][30].ToString();
                    objApplicantRegistrationBO.DiplomaSavedName = objDataSet.Tables[0].Rows[0][31].ToString();
                    objApplicantRegistrationBO.MSC = objDataSet.Tables[0].Rows[0][32].ToString();
                    objApplicantRegistrationBO.MSCSavedName = objDataSet.Tables[0].Rows[0][33].ToString();
                    objApplicantRegistrationBO.PHD = objDataSet.Tables[0].Rows[0][34].ToString();
                    objApplicantRegistrationBO.PHDSavedName = objDataSet.Tables[0].Rows[0][35].ToString();
                    objApplicantRegistrationBO.QuaStartDate = objDataSet.Tables[0].Rows[0][36].ToString();
                    objApplicantRegistrationBO.QuaEndDate = objDataSet.Tables[0].Rows[0][37].ToString();
                    objApplicantRegistrationBO.Discipline = objDataSet.Tables[0].Rows[0][38].ToString();
                    objApplicantRegistrationBO.University = objDataSet.Tables[0].Rows[0][39].ToString();
                    objApplicantRegistrationBO.QuaNationality = objDataSet.Tables[0].Rows[0][40].ToString();
                    objApplicantRegistrationBO.Degree = objDataSet.Tables[0].Rows[0][41].ToString();
                    objApplicantRegistrationBO.Class = objDataSet.Tables[0].Rows[0][42].ToString();


                    objApplicantRegistrationBO.EmployerName = objDataSet.Tables[0].Rows[0][43].ToString();
                    objApplicantRegistrationBO.TypeOfIndustry = objDataSet.Tables[0].Rows[0][44].ToString();
                    objApplicantRegistrationBO.TelephoneNo = objDataSet.Tables[0].Rows[0][45].ToString();
                    objApplicantRegistrationBO.TitleOfSupervisor = objDataSet.Tables[0].Rows[0][46].ToString();
                    objApplicantRegistrationBO.JobTitle = objDataSet.Tables[0].Rows[0][47].ToString();
                    objApplicantRegistrationBO.City = objDataSet.Tables[0].Rows[0][48].ToString();
                    objApplicantRegistrationBO.EmpStartDate = objDataSet.Tables[0].Rows[0][49].ToString();
                    objApplicantRegistrationBO.EmpEndDate = objDataSet.Tables[0].Rows[0][50].ToString();
                    objApplicantRegistrationBO.Responsibility = objDataSet.Tables[0].Rows[0][51].ToString();
                    objApplicantRegistrationBO.MonthlySalary = objDataSet.Tables[0].Rows[0][52].ToString();
                    objApplicantRegistrationBO.NoticePeriod = objDataSet.Tables[0].Rows[0][53].ToString();
                    objApplicantRegistrationBO.EmpAddress = objDataSet.Tables[0].Rows[0][54].ToString();
                    objApplicantRegistrationBO.EmpFirstName = objDataSet.Tables[0].Rows[0][55].ToString();
                    objApplicantRegistrationBO.SecondName = objDataSet.Tables[0].Rows[0][56].ToString();
                    objApplicantRegistrationBO.Position = objDataSet.Tables[0].Rows[0][57].ToString();
                    objApplicantRegistrationBO.RelationshipTOApplicant = objDataSet.Tables[0].Rows[0][58].ToString();
                    objApplicantRegistrationBO.NameOfTheOrganization = objDataSet.Tables[0].Rows[0][59].ToString();
                    objApplicantRegistrationBO.TelephoneContact = objDataSet.Tables[0].Rows[0][60].ToString();
                    objApplicantRegistrationBO.EmpEmailAddress = objDataSet.Tables[0].Rows[0][61].ToString();

                    objApplicantRegistrationBO.JobDescription = objDataSet.Tables[0].Rows[0][62].ToString();
                    objApplicantRegistrationBO.RefererId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][63].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditApplicantDetails");
                throw ex;
            }
            return objApplicantRegistrationBO;
        }


        //View Applicant

        public static string ProcViewApplicant = "usp_SCH_ViewApplicantRegistration";
        public ApplicantRegistrationBO ViewApplicant(int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantRegistrationBO objApplicantRegistrationBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewApplicant, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objApplicantRegistrationBO = new ApplicantRegistrationBO();
                    objApplicantRegistrationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objApplicantRegistrationBO.Title = objDataSet.Tables[0].Rows[0][1].ToString();
                    objApplicantRegistrationBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objApplicantRegistrationBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objApplicantRegistrationBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
                    objApplicantRegistrationBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
                    objApplicantRegistrationBO.Gender = objDataSet.Tables[0].Rows[0][6].ToString();
                    objApplicantRegistrationBO.Citizenship = objDataSet.Tables[0].Rows[0][7].ToString();
                    objApplicantRegistrationBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
                    objApplicantRegistrationBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();
                    objApplicantRegistrationBO.Country = objDataSet.Tables[0].Rows[0][10].ToString();
                    objApplicantRegistrationBO.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
                    objApplicantRegistrationBO.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
                    objApplicantRegistrationBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
                    objApplicantRegistrationBO.English = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][14].ToString());
                    objApplicantRegistrationBO.Kiswahili = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][15].ToString());
                    objApplicantRegistrationBO.MotherTongue = objDataSet.Tables[0].Rows[0][16].ToString();
                    objApplicantRegistrationBO.OtherLanguages = objDataSet.Tables[0].Rows[0][17].ToString();
                    objApplicantRegistrationBO.Nationality = objDataSet.Tables[0].Rows[0][18].ToString();
                    objApplicantRegistrationBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][19].ToString();
                    objApplicantRegistrationBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
                    objApplicantRegistrationBO.CV = objDataSet.Tables[0].Rows[0][21].ToString();
                    objApplicantRegistrationBO.CVSavedName = objDataSet.Tables[0].Rows[0][22].ToString();
                    objApplicantRegistrationBO.Address = objDataSet.Tables[0].Rows[0][23].ToString();
                    objApplicantRegistrationBO.Photo = objDataSet.Tables[0].Rows[0][24].ToString();
                    objApplicantRegistrationBO.PhotoSavedName = objDataSet.Tables[0].Rows[0][25].ToString();



                    objApplicantRegistrationBO.Bachelors = objDataSet.Tables[0].Rows[0][26].ToString();
                    objApplicantRegistrationBO.BachelorsSavedName = objDataSet.Tables[0].Rows[0][27].ToString();
                    objApplicantRegistrationBO.Diploma = objDataSet.Tables[0].Rows[0][28].ToString();
                    objApplicantRegistrationBO.DiplomaSavedName = objDataSet.Tables[0].Rows[0][29].ToString();
                    objApplicantRegistrationBO.MSC = objDataSet.Tables[0].Rows[0][30].ToString();
                    objApplicantRegistrationBO.MSCSavedName = objDataSet.Tables[0].Rows[0][31].ToString();
                    objApplicantRegistrationBO.PHD = objDataSet.Tables[0].Rows[0][32].ToString();
                    objApplicantRegistrationBO.PHDSavedName = objDataSet.Tables[0].Rows[0][33].ToString();
                    objApplicantRegistrationBO.QuaStartDate = objDataSet.Tables[0].Rows[0][34].ToString();
                    objApplicantRegistrationBO.QuaEndDate = objDataSet.Tables[0].Rows[0][35].ToString();
                    objApplicantRegistrationBO.Discipline = objDataSet.Tables[0].Rows[0][36].ToString();
                    objApplicantRegistrationBO.University = objDataSet.Tables[0].Rows[0][37].ToString();
                    objApplicantRegistrationBO.QuaNationality = objDataSet.Tables[0].Rows[0][38].ToString();
                    objApplicantRegistrationBO.Degree = objDataSet.Tables[0].Rows[0][39].ToString();
                    objApplicantRegistrationBO.Class = objDataSet.Tables[0].Rows[0][40].ToString();



                    objApplicantRegistrationBO.EmployerName = objDataSet.Tables[0].Rows[0][41].ToString();
                    objApplicantRegistrationBO.TypeOfIndustry = objDataSet.Tables[0].Rows[0][42].ToString();
                    objApplicantRegistrationBO.TelephoneNo = objDataSet.Tables[0].Rows[0][43].ToString();
                    objApplicantRegistrationBO.TitleOfSupervisor = objDataSet.Tables[0].Rows[0][44].ToString();
                    objApplicantRegistrationBO.JobTitle = objDataSet.Tables[0].Rows[0][45].ToString();
                    objApplicantRegistrationBO.City = objDataSet.Tables[0].Rows[0][46].ToString();
                    objApplicantRegistrationBO.EmpStartDate = objDataSet.Tables[0].Rows[0][47].ToString();
                    objApplicantRegistrationBO.EmpEndDate = objDataSet.Tables[0].Rows[0][48].ToString();
                    objApplicantRegistrationBO.Responsibility = objDataSet.Tables[0].Rows[0][49].ToString();
                    objApplicantRegistrationBO.MonthlySalary = objDataSet.Tables[0].Rows[0][50].ToString();
                    objApplicantRegistrationBO.NoticePeriod = objDataSet.Tables[0].Rows[0][51].ToString();
                    objApplicantRegistrationBO.EmpAddress = objDataSet.Tables[0].Rows[0][52].ToString();
                    objApplicantRegistrationBO.EmpFirstName = objDataSet.Tables[0].Rows[0][53].ToString();
                    objApplicantRegistrationBO.SecondName = objDataSet.Tables[0].Rows[0][54].ToString();
                    objApplicantRegistrationBO.Position = objDataSet.Tables[0].Rows[0][55].ToString();
                    objApplicantRegistrationBO.RelationshipTOApplicant = objDataSet.Tables[0].Rows[0][56].ToString();
                    objApplicantRegistrationBO.NameOfTheOrganization = objDataSet.Tables[0].Rows[0][57].ToString();
                    objApplicantRegistrationBO.TelephoneContact = objDataSet.Tables[0].Rows[0][58].ToString();
                    objApplicantRegistrationBO.EmpEmailAddress = objDataSet.Tables[0].Rows[0][59].ToString();

                    objApplicantRegistrationBO.JobDescription = objDataSet.Tables[0].Rows[0][60].ToString();
                    objApplicantRegistrationBO.Referer = objDataSet.Tables[0].Rows[0][61].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "ViewApplicant");
                throw ex;
            }
            return objApplicantRegistrationBO; ;
        }



        //Delete Applicant

        public static string ProcDeleteApplicant = "usp_SCH_deleteApplicant";
        public string deleteApplicant(int iApplicantId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteApplicant, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "deleteApplicant");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

    }
}
