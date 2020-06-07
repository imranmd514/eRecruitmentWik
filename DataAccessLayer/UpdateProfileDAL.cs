using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDB;
using Models;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class UpdateProfileDAL
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

        public static string ProcAcademicQualificationsList = "usp_SCH_DropdownAcademicQualifications";
        public List<CommonDropDownBO> AcademicQualificationsList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcAcademicQualificationsList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "AcademicQualificationsList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }

        public static string ProcTypeOfIndustryList = "usp_SCH_DropdownTypeOfIndustry";
        public List<CommonDropDownBO> TypeOfIndustryList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcTypeOfIndustryList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "TypeOfIndustryList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }


        //Edit Applicant
        public static string ProcGetApplicantData = "usp_SCH_GetApplicantRegistrationDetails";
        public ApplicantRegistrationBO GetApplicantDetails(int iApplicantId)
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

                objDataSet = objDBAccess.execuitDataSet(ProcGetApplicantData, ref objProcParameterBOList);
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
                    objApplicantRegistrationBO.IdTypeMasterId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][7].ToString());
                    objApplicantRegistrationBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
                    objApplicantRegistrationBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();

                    objApplicantRegistrationBO.CountryId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][10].ToString());
                    objApplicantRegistrationBO.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
                    objApplicantRegistrationBO.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
                    objApplicantRegistrationBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
                  
                    objApplicantRegistrationBO.MotherTongue = objDataSet.Tables[0].Rows[0][14].ToString();
                  
                    objApplicantRegistrationBO.Nationality = objDataSet.Tables[0].Rows[0][15].ToString();

                    objApplicantRegistrationBO.County = objDataSet.Tables[0].Rows[0][16].ToString();

                    objApplicantRegistrationBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][17].ToString();
                    objApplicantRegistrationBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][18].ToString();
                    objApplicantRegistrationBO.CV = objDataSet.Tables[0].Rows[0][19].ToString();
                    objApplicantRegistrationBO.CVSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
                    objApplicantRegistrationBO.SpecialNeed = Convert.ToInt32(objDataSet.Tables[0].Rows[0][21].ToString());
                    objApplicantRegistrationBO.Address = objDataSet.Tables[0].Rows[0][22].ToString();
                    objApplicantRegistrationBO.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][23].ToString();
                    objApplicantRegistrationBO.Photo = objDataSet.Tables[0].Rows[0][24].ToString();
                    objApplicantRegistrationBO.PhotoSavedName = objDataSet.Tables[0].Rows[0][25].ToString();

                    objApplicantRegistrationBO.ApplicantMotivationId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][26].ToString());
                    objApplicantRegistrationBO.Membership = Convert.ToInt32(objDataSet.Tables[0].Rows[0][27].ToString());
                    objApplicantRegistrationBO.NameofProfessionalBody = objDataSet.Tables[0].Rows[0][28].ToString();
                    objApplicantRegistrationBO.MembershipNumber = objDataSet.Tables[0].Rows[0][29].ToString();
                    objApplicantRegistrationBO.Validity = Convert.ToInt32(objDataSet.Tables[0].Rows[0][30].ToString());
                    objApplicantRegistrationBO.JobDescription = objDataSet.Tables[0].Rows[0][31].ToString();
                    objApplicantRegistrationBO.RefererId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][32].ToString());
                    objApplicantRegistrationBO.Others = objDataSet.Tables[0].Rows[0][33].ToString();
                    objApplicantRegistrationBO.ApplicationNote = objDataSet.Tables[0].Rows[0][34].ToString();

                    objApplicantRegistrationBO.TerminatedId = objDataSet.Tables[0].Rows[0][35].ToString();
                    objApplicantRegistrationBO.Terminatation = objDataSet.Tables[0].Rows[0][36].ToString();
                    objApplicantRegistrationBO.MisconductId = objDataSet.Tables[0].Rows[0][37].ToString();
                    objApplicantRegistrationBO.Misconduct = objDataSet.Tables[0].Rows[0][38].ToString();
                    objApplicantRegistrationBO.ManagementId = objDataSet.Tables[0].Rows[0][39].ToString();
                    objApplicantRegistrationBO.Management = objDataSet.Tables[0].Rows[0][40].ToString();
                    objApplicantRegistrationBO.InvestigationId = objDataSet.Tables[0].Rows[0][41].ToString();
                    objApplicantRegistrationBO.Investigation = objDataSet.Tables[0].Rows[0][42].ToString();


                    objApplicantRegistrationBO.CriminalOffenceId = objDataSet.Tables[0].Rows[0][43].ToString();
                    objApplicantRegistrationBO.CriminalOffence = objDataSet.Tables[0].Rows[0][44].ToString();
                    objApplicantRegistrationBO.ConvictionsId = objDataSet.Tables[0].Rows[0][45].ToString();
                    objApplicantRegistrationBO.Convictions = objDataSet.Tables[0].Rows[0][46].ToString();
                    objApplicantRegistrationBO.CorruptionId = objDataSet.Tables[0].Rows[0][47].ToString();
                    objApplicantRegistrationBO.Corruption = objDataSet.Tables[0].Rows[0][48].ToString();
                    objApplicantRegistrationBO.DisciplinaryId = objDataSet.Tables[0].Rows[0][49].ToString();
                    objApplicantRegistrationBO.Disciplinary = objDataSet.Tables[0].Rows[0][50].ToString();
                    objApplicantRegistrationBO.RelationToChildId = objDataSet.Tables[0].Rows[0][51].ToString();
                    objApplicantRegistrationBO.RelationToChild = objDataSet.Tables[0].Rows[0][52].ToString();
                    objApplicantRegistrationBO.RelationToAdultId = objDataSet.Tables[0].Rows[0][53].ToString();
                    objApplicantRegistrationBO.RelationToAdult = objDataSet.Tables[0].Rows[0][54].ToString();
                    objApplicantRegistrationBO.RelativeId = objDataSet.Tables[0].Rows[0][55].ToString();
                    objApplicantRegistrationBO.DealingsWithWIKId = objDataSet.Tables[0].Rows[0][56].ToString();
                    objApplicantRegistrationBO.DealingsWithWIK = objDataSet.Tables[0].Rows[0][57].ToString();
                    objApplicantRegistrationBO.Declarationinfo = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][58].ToString());
                    objApplicantRegistrationBO.Statement = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][59].ToString());

                    objApplicantRegistrationBO.DeclarationID = Convert.ToInt32(objDataSet.Tables[0].Rows[0][60].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetApplicantDetails");
                throw ex;
            }
            return objApplicantRegistrationBO;
        }


        public string ProcGetCheckApplicantExist = "usp_SCH_CheckApplicantExist";
        public string CheckApplicantExist(int iApplicantId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDbParameter = null;
            string strResult = "";
            try
            {
                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                strResult = objDBAccess.executeScalar(ProcGetCheckApplicantExist, ref objProcParameterBOList).ToString();

            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "CheckApplicantExist");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }



        public static string ProcSaveApplicantRegistration = "usp_SCH_saveApplicantRegistrations";
        public string SaveorUpdateApplicantRegistration(ApplicantPersonalInformationBO objApplicantPersonalInformationBO, int iUserId)
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
                objDBparameter.ParameterValue = "";
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iTitleId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.TitleId;
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
                objDBparameter.ParameterName = "@iGender";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.GenderId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iCitizenship";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.IdTypeMasterId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCitizenShipIdCopy";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.CitizenShipIdCopy;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCitizenShipIdCopySavedName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.CitizenShipIdCopySavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iCountry";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.CountryId;
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
                objDBparameter.ParameterName = "@strMotherTongue";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.MotherTongue;
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
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.ApplicationLetterSavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCV";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.CV;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCVSavedName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.CVSavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iSpecialNeed";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.SpecialNeed;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.Address;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSpecialNeedDetails";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.SpecialNeedDetails;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPhoto";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.Photo;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPhotoSavedName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.PhotoSavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCounty";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.County;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iAnyoneWorkinWIKId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantPersonalInformationBO.AnyoneWorkinWIKId;
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
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strType";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = "Update";
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


        public static string ProcSaveApplicantQualification = "usp_SCH_saveQualification";
        public string SaveorUpdateApplicantQualification(ApplicantQualificationBO objApplicantQualificationBO, int iUserId)
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
                objDBparameter.ParameterName = "@iAcademicQualificationId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantQualificationBO.AcademicQualificationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strOtherCertification";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.OtherCertification;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAcademicQualificationAttachment";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.AcademicQualificationAttachment;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAttachmentSavedName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.AttachmentSavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strStartDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.QuaStartDate;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEndDate";
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
                objDBparameter.ParameterName = "@iCountryId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantQualificationBO.QuaCountryId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strClass";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantQualificationBO.CreditScoreClass;
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
                ExceptionError.Error_Log(ex, "SaveorUpdateApplicantQualification");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcGetApplicantQualificationList = "usp_SCH_GetApplicantQualificationList";
        public List<ApplicantQualificationBO> GetApplicantQualificationList(int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantQualificationBO objApplicantQualificationBO = null;
            List<ApplicantQualificationBO> objApplicantQualificationBOList = new List<ApplicantQualificationBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcGetApplicantQualificationList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApplicantQualificationBO = new ApplicantQualificationBO();
                        objApplicantQualificationBO.ApplicantQualificationId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApplicantQualificationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        objApplicantQualificationBO.AcademicQualification = objDataSet.Tables[0].Rows[i][2].ToString();
                        objApplicantQualificationBO.AcademicQualificationAttachment = objDataSet.Tables[0].Rows[i][3].ToString();
                        objApplicantQualificationBO.AttachmentSavedName = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApplicantQualificationBO.StartDate = objDataSet.Tables[0].Rows[i][5].ToString();
                        objApplicantQualificationBO.EndDate = objDataSet.Tables[0].Rows[i][6].ToString();
                        objApplicantQualificationBO.Discipline = objDataSet.Tables[0].Rows[i][7].ToString();
                        objApplicantQualificationBO.University = objDataSet.Tables[0].Rows[i][8].ToString();
                        objApplicantQualificationBO.QuaCountry = objDataSet.Tables[0].Rows[i][9].ToString();
                        objApplicantQualificationBO.CreditScoreClass = objDataSet.Tables[0].Rows[i][10].ToString();
                        objApplicantQualificationBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][11].ToString());
                        objApplicantQualificationBOList.Add(objApplicantQualificationBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetApplicantQualificationList");
                throw ex;
            }
            return objApplicantQualificationBOList;
        }

        public static string ProcEditApplicantQualification = "usp_SCH_EditApplicantQualification";
        public ApplicantQualificationBO EditApplicantQualificationList(int iApplicantQualificationId,int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantQualificationBO objApplicantQualificationBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantQualificationId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantQualificationId;
                objProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditApplicantQualification, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApplicantQualificationBO = new ApplicantQualificationBO();
                        objApplicantQualificationBO.ApplicantQualificationId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApplicantQualificationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        objApplicantQualificationBO.AcademicQualificationId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][2].ToString());
                        objApplicantQualificationBO.AcademicQualificationAttachment = objDataSet.Tables[0].Rows[i][3].ToString();
                        objApplicantQualificationBO.AttachmentSavedName = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApplicantQualificationBO.QuaStartDate = objDataSet.Tables[0].Rows[i][5].ToString();
                        objApplicantQualificationBO.QuaEndDate = objDataSet.Tables[0].Rows[i][6].ToString();
                        objApplicantQualificationBO.Discipline = objDataSet.Tables[0].Rows[i][7].ToString();
                        objApplicantQualificationBO.University = objDataSet.Tables[0].Rows[i][8].ToString();
                        objApplicantQualificationBO.QuaCountryId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][9].ToString());
                        objApplicantQualificationBO.CreditScoreClass = objDataSet.Tables[0].Rows[i][10].ToString();
                        objApplicantQualificationBO.OtherCertification = objDataSet.Tables[0].Rows[i][11].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditApplicantQualificationList");
                throw ex;
            }
            return objApplicantQualificationBO;
        }

        public static string ProcDeleteApplicantQualification = "usp_SCH_DeleteApplicantQualification";
        public string DeleteApplicantQualification(int iApplicantQualificationId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantQualificationId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantQualificationId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteApplicantQualification, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DeleteApplicantQualification");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }



        public static string ProcSaveApplicantEmploymentHistory = "usp_SCH_SaveApplicantEmploymentHistory";
        public string SaveorUpdateApplicantEmploymentHistory(ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO, int iUserId)
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
                objDBparameter.ParameterName = "@strEmployerName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.EmployerName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iTypeOfIndustryId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.TypeOfIndustryId;
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
                objDBparameter.ParameterName = "@strStartDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.EmpStartDate;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEndDate";
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
                objDBparameter.ParameterName = "@strNoticePeriod";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.NoticePeriod;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strReasonforleaving";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.Reasonforleaving;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCity";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.City;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMonthlySalary";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.MonthlySalary;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iSubjectCombinations";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.SubjectCombinations;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSubject";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantEmploymentHistoryBO.Subject;
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

                objDBAccess.executeNonQuery(ProcSaveApplicantEmploymentHistory, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateApplicantEmploymentHistory");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcGetApplicantEmploymentHistoryList = "usp_SCH_GetEmploymentHistoryList";
        public List<ApplicantEmploymentHistoryBO> GetEmploymentHistoryList(int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO = null;
            List<ApplicantEmploymentHistoryBO> objApplicantEmploymentHistoryList = new List<ApplicantEmploymentHistoryBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcGetApplicantEmploymentHistoryList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApplicantEmploymentHistoryBO = new ApplicantEmploymentHistoryBO();
                        objApplicantEmploymentHistoryBO.EmploymentHistoryId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApplicantEmploymentHistoryBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        objApplicantEmploymentHistoryBO.EmployerName = objDataSet.Tables[0].Rows[i][2].ToString();
                        objApplicantEmploymentHistoryBO.TypeOfIndustry = objDataSet.Tables[0].Rows[i][3].ToString();
                        objApplicantEmploymentHistoryBO.JobTitle = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApplicantEmploymentHistoryBO.EmpStartDate = objDataSet.Tables[0].Rows[i][5].ToString();
                        objApplicantEmploymentHistoryBO.EmpEndDate = objDataSet.Tables[0].Rows[i][6].ToString();
                        objApplicantEmploymentHistoryBO.Responsibility = objDataSet.Tables[0].Rows[i][7].ToString();
                        objApplicantEmploymentHistoryBO.NoticePeriod = objDataSet.Tables[0].Rows[i][8].ToString();
                        objApplicantEmploymentHistoryBO.Reasonforleaving = objDataSet.Tables[0].Rows[i][9].ToString();
                        objApplicantEmploymentHistoryBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][10].ToString());
                        objApplicantEmploymentHistoryList.Add(objApplicantEmploymentHistoryBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetEmploymentHistoryList");
                throw ex;
            }
            return objApplicantEmploymentHistoryList;
        }

        public static string ProcEditApplicantEmploymentHistory = "usp_SCH_EditApplicantEmploymentHistory";
        public ApplicantEmploymentHistoryBO EditApplicantEmploymentHistory(int iEmploymentHistoryId, int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iEmploymentHistoryId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iEmploymentHistoryId;
                objProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditApplicantEmploymentHistory, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApplicantEmploymentHistoryBO = new ApplicantEmploymentHistoryBO();
                        objApplicantEmploymentHistoryBO.EmploymentHistoryId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApplicantEmploymentHistoryBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        objApplicantEmploymentHistoryBO.EmployerName =objDataSet.Tables[0].Rows[i][2].ToString();
                        objApplicantEmploymentHistoryBO.TypeOfIndustryId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][3].ToString());
                        objApplicantEmploymentHistoryBO.TelephoneNo = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApplicantEmploymentHistoryBO.JobTitle = objDataSet.Tables[0].Rows[i][5].ToString();
                        objApplicantEmploymentHistoryBO.TitleOfSupervisor = objDataSet.Tables[0].Rows[i][6].ToString();
                        objApplicantEmploymentHistoryBO.EmpStartDate = objDataSet.Tables[0].Rows[i][7].ToString();
                        objApplicantEmploymentHistoryBO.EmpEndDate = objDataSet.Tables[0].Rows[i][8].ToString();
                        objApplicantEmploymentHistoryBO.Responsibility = objDataSet.Tables[0].Rows[i][9].ToString();
                        objApplicantEmploymentHistoryBO.NoticePeriod = objDataSet.Tables[0].Rows[i][10].ToString();
                        objApplicantEmploymentHistoryBO.Reasonforleaving = objDataSet.Tables[0].Rows[i][11].ToString();
                        objApplicantEmploymentHistoryBO.City = objDataSet.Tables[0].Rows[i][12].ToString();
                        objApplicantEmploymentHistoryBO.MonthlySalary = objDataSet.Tables[0].Rows[i][13].ToString();
                        objApplicantEmploymentHistoryBO.SubjectCombinations = Convert.ToInt32(objDataSet.Tables[0].Rows[i][14].ToString());
                        objApplicantEmploymentHistoryBO.Subject = objDataSet.Tables[0].Rows[i][15].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditApplicantEmploymentHistory");
                throw ex;
            }
            return objApplicantEmploymentHistoryBO;
        }

        public static string ProcDeleteApplicantEmploymentHistory = "usp_SCH_DeleteApplicantEmploymentHistory";
        public string DeleteApplicantEmploymentHistory(int iEmploymentHistoryId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iEmploymentHistoryId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iEmploymentHistoryId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteApplicantEmploymentHistory, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DeleteApplicantEmploymentHistory");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }




        public static string ProcSaveRefereesDetails = "usp_SCH_SaveApplicantReferees";
        public string SaveorUpdateRefereesDetails(ApplicantRefereesBO objApplicantRefereesBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRefereesId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantRefereesBO.RefereesId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantRefereesBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strFirstName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRefereesBO.EmpFirstName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSecondName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRefereesBO.SecondName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPosition";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRefereesBO.Position;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strRelationshipTOApplicant";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRefereesBO.RelationshipTOApplicant;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strNameOfTheOrganization";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRefereesBO.NameOfTheOrganization;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strTelephoneContact";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRefereesBO.TelephoneContact;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmailAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRefereesBO.EmpEmailAddress;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objApplicantRefereesBO.IsActive;
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

                objDBAccess.executeNonQuery(ProcSaveRefereesDetails, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateRefereesDetails");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcGetApplicantRefereesList = "usp_SCH_GetRefereesList";
        public List<ApplicantRefereesBO> GetApplicantRefereesList(int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantRefereesBO objApplicantRefereesBO = null;
            List<ApplicantRefereesBO> objApplicantRefereesList = new List<ApplicantRefereesBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcGetApplicantRefereesList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApplicantRefereesBO = new ApplicantRefereesBO();
                        objApplicantRefereesBO.RefereesId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApplicantRefereesBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        objApplicantRefereesBO.EmpFirstName = objDataSet.Tables[0].Rows[i][2].ToString();
                        objApplicantRefereesBO.SecondName = objDataSet.Tables[0].Rows[i][3].ToString();
                        objApplicantRefereesBO.Position = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApplicantRefereesBO.RelationshipTOApplicant = objDataSet.Tables[0].Rows[i][5].ToString();
                        objApplicantRefereesBO.NameOfTheOrganization = objDataSet.Tables[0].Rows[i][6].ToString();
                        objApplicantRefereesBO.TelephoneContact = objDataSet.Tables[0].Rows[i][7].ToString();
                        objApplicantRefereesBO.EmpEmailAddress = objDataSet.Tables[0].Rows[i][8].ToString();
                        objApplicantRefereesBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][9].ToString());
                        objApplicantRefereesList.Add(objApplicantRefereesBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetApplicantRefereesList");
                throw ex;
            }
            return objApplicantRefereesList;
        }

        public static string ProcEditApplicantRefereesData = "usp_SCH_EditApplicantRefereesData";
        public ApplicantRefereesBO EditApplicantRefereesData(int iRefereesId, int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantRefereesBO objApplicantRefereesBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iRefereesId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iRefereesId;
                objProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditApplicantRefereesData, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApplicantRefereesBO = new ApplicantRefereesBO();
                        objApplicantRefereesBO.RefereesId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApplicantRefereesBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        objApplicantRefereesBO.EmpFirstName = objDataSet.Tables[0].Rows[i][2].ToString();
                        objApplicantRefereesBO.SecondName = objDataSet.Tables[0].Rows[i][3].ToString();
                        objApplicantRefereesBO.Position = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApplicantRefereesBO.RelationshipTOApplicant = objDataSet.Tables[0].Rows[i][5].ToString();
                        objApplicantRefereesBO.NameOfTheOrganization = objDataSet.Tables[0].Rows[i][6].ToString();
                        objApplicantRefereesBO.TelephoneContact = objDataSet.Tables[0].Rows[i][7].ToString();
                        objApplicantRefereesBO.EmpEmailAddress = objDataSet.Tables[0].Rows[i][8].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditApplicantRefereesData");
                throw ex;
            }
            return objApplicantRefereesBO;
        }

        public static string ProcDeleteApplicantRefereesData = "usp_SCH_DeleteApplicantRefereesData";
        public string DeleteApplicantRefereesData(int iRefereesId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iRefereesId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iRefereesId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteApplicantRefereesData, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DeleteApplicantRefereesData");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        public static string ProcSaveMembershipData = "usp_SCH_saveMembershipData";
        public string SaveorUpdateMembershipData(ApplicantMotivationalSkillBO objApplicantMotivationalSkillBO, int iUserId)
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
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.ApplicantMotivationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iProfessionalBody";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.Membership;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strProfessionalBodyName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.NameofProfessionalBody;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMembershipNumber";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.MembershipNumber;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iValidity";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.Validity;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.IsActive;
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

                objDBAccess.executeNonQuery(ProcSaveMembershipData, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateMembershipData");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcSaveMotivationSkills = "usp_SCH_saveMotivationSkillsAndExperience";
        public string SaveorUpdateMotivationSkills(ApplicantMotivationalSkillBO objApplicantMotivationalSkillBO, int iUserId)
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
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.ApplicantMotivationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                //objDBparameter = new ProcParameterBO();
                //objDBparameter.Direction = ParameterDirection.Input;
                //objDBparameter.ParameterName = "@iProfessionalBody";
                //objDBparameter.dbType = DbType.Int32;
                //objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.Membership;
                //objProcParameterBOList.Add(objDBparameter);

                //objDBparameter = new ProcParameterBO();
                //objDBparameter.Direction = ParameterDirection.Input;
                //objDBparameter.ParameterName = "@strProfessionalBodyName";
                //objDBparameter.dbType = DbType.String;
                //objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.NameofProfessionalBody;
                //objProcParameterBOList.Add(objDBparameter);

                //objDBparameter = new ProcParameterBO();
                //objDBparameter.Direction = ParameterDirection.Input;
                //objDBparameter.ParameterName = "@strMembershipNumber";
                //objDBparameter.dbType = DbType.String;
                //objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.MembershipNumber;
                //objProcParameterBOList.Add(objDBparameter);

                //objDBparameter = new ProcParameterBO();
                //objDBparameter.Direction = ParameterDirection.Input;
                //objDBparameter.ParameterName = "@iValidity";
                //objDBparameter.dbType = DbType.Int32;
                //objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.Validity;
                //objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDescription";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.JobDescription;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRefererId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.RefererId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strOthers";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.Others;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strApplicationNote";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.ApplicationNote;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objApplicantMotivationalSkillBO.IsActive;
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

                objDBAccess.executeNonQuery(ProcSaveMotivationSkills, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateMotivationSkills");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        public static string ProcSaveDeclarationDetails = "usp_SCH_SaveDeclarationDetails";
        public string SaveorUpdateDeclarationDetails(DeclarationBO objDeclarationBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iDeclarationID";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objDeclarationBO.DeclarationID;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objDeclarationBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iTerminatedId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.TerminatedId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strTerminatation";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.Terminatation;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iMisconductId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.MisconductId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMisconduct";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.Misconduct;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iManagementId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.ManagementId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strManagement";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.Management;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iInvestigationId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.InvestigationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strInvestigation";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.Investigation;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iCriminalOffenceId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.CriminalOffenceId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCriminalOffence";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.CriminalOffence;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iConvictionsId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.ConvictionsId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strConvictions";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.Convictions;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iCorruptionId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.CorruptionId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCorruption";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.Corruption;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iDisciplinaryId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.DisciplinaryId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDisciplinary";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.Disciplinary;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRelationToChildId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.RelationToChildId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strRelationToChild";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.RelationToChild;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRelationToAdultId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.RelationToAdultId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strRelationToAdult";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.RelationToAdult;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRelativeId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.RelativeId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iDealingsWithWIKId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.DealingsWithWIKId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDealingsWithWIK";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDeclarationBO.DealingsWithWIK;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bDeclaration";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objDeclarationBO.Declarationinfo;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bStatement";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objDeclarationBO.Statement;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objDeclarationBO.IsActive;
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

                objDBAccess.executeNonQuery(ProcSaveDeclarationDetails, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateDeclarationDetails");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        public static string ProcSaveApplicantLanguageDetails = "usp_SCH_SaveApplicantLanguage";
        public string SaveorUpdateApplicantLanguageDetails(LanguageSpokenBO objLanguageSpokenBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iLanguageSpokenId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objLanguageSpokenBO.LanguageSpokenId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objLanguageSpokenBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLanguage";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objLanguageSpokenBO.Language;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLanguageRead";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objLanguageSpokenBO.LanguageRead;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strWrite";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objLanguageSpokenBO.Write;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSpeak";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objLanguageSpokenBO.Speak;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strUnderstand";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objLanguageSpokenBO.Understand;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objLanguageSpokenBO.IsActive;
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

                objDBAccess.executeNonQuery(ProcSaveApplicantLanguageDetails, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateApplicantLanguageDetails");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcGetApplicantLanguageList = "usp_SCH_GetApplicantLanguageList";
        public List<LanguageSpokenBO> GetApplicantLanguageList(int iApplicantId)
        {
            DataSet objDataSet = null;
            LanguageSpokenBO objLanguageSpokenBO = null;
            List<LanguageSpokenBO> objLanguageSpokenBOList = new List<LanguageSpokenBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcGetApplicantLanguageList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objLanguageSpokenBO = new LanguageSpokenBO();
                        objLanguageSpokenBO.LanguageSpokenId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objLanguageSpokenBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        objLanguageSpokenBO.Language = objDataSet.Tables[0].Rows[i][2].ToString();
                        objLanguageSpokenBO.LanguageRead = objDataSet.Tables[0].Rows[i][3].ToString();
                        objLanguageSpokenBO.Write = objDataSet.Tables[0].Rows[i][4].ToString();
                        objLanguageSpokenBO.Speak = objDataSet.Tables[0].Rows[i][5].ToString();
                        objLanguageSpokenBO.Understand = objDataSet.Tables[0].Rows[i][6].ToString();
                        objLanguageSpokenBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][7].ToString());
                        objLanguageSpokenBOList.Add(objLanguageSpokenBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetApplicantLanguageList");
                throw ex;
            }
            return objLanguageSpokenBOList;
        }

        public static string ProcEditApplicantLanguageData = "usp_SCH_EditApplicantLanguage";
        public LanguageSpokenBO EditApplicantLanguageData(int iLanguageSpokenId, int iApplicantId)
        {
            DataSet objDataSet = null;
            LanguageSpokenBO objLanguageSpokenBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iLanguageSpokenId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iLanguageSpokenId;
                objProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditApplicantLanguageData, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objLanguageSpokenBO = new LanguageSpokenBO();
                        objLanguageSpokenBO.LanguageSpokenId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objLanguageSpokenBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        objLanguageSpokenBO.Language = objDataSet.Tables[0].Rows[i][2].ToString();
                        objLanguageSpokenBO.LanguageRead = objDataSet.Tables[0].Rows[i][3].ToString();
                        objLanguageSpokenBO.Write = objDataSet.Tables[0].Rows[i][4].ToString();
                        objLanguageSpokenBO.Speak = objDataSet.Tables[0].Rows[i][5].ToString();
                        objLanguageSpokenBO.Understand = objDataSet.Tables[0].Rows[i][6].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditApplicantLanguageData");
                throw ex;
            }
            return objLanguageSpokenBO;
        }

        public static string ProcDeleteApplicantLanguageData = "usp_SCH_DeleteApplicantLanguageData";
        public string DeleteApplicantLanguageData(int iLanguageSpokenId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iLanguageSpokenId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iLanguageSpokenId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteApplicantLanguageData, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DeleteApplicantLanguageData");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }



        public static string ProcSaveApplicantRelationDetails = "usp_SCH_SaveApplicantRelationData";
        public string SaveorUpdateApplicantRelationDetails(ApplicantRelationBO objApplicantRelationBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRelationId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantRelationBO.RelationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objApplicantRelationBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                //objDBparameter = new ProcParameterBO();
                //objDBparameter.Direction = ParameterDirection.Input;
                //objDBparameter.ParameterName = "@iAnyoneWorkinWIKId";
                //objDBparameter.dbType = DbType.Int32;
                //objDBparameter.ParameterValue = objApplicantRelationBO.AnyoneWorkinWIKId;
                //objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strRelativeName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRelationBO.RelativeName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strRelationship";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objApplicantRelationBO.Relationship;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objApplicantRelationBO.IsActive;
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

                objDBAccess.executeNonQuery(ProcSaveApplicantRelationDetails, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateApplicantRelationDetails");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcGetApplicantRelationDetailsList = "usp_SCH_GetApplicantRelationDetailsList";
        public List<ApplicantRelationBO> GetApplicantRelationDetailsList(int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantRelationBO objApplicantRelationBO = null;
            List<ApplicantRelationBO> objApplicantRelationBOList = new List<ApplicantRelationBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcGetApplicantRelationDetailsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApplicantRelationBO = new ApplicantRelationBO();
                        objApplicantRelationBO.RelationId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApplicantRelationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        //objApplicantRelationBO.AnyoneWorkinWIKId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][2].ToString());
                        objApplicantRelationBO.RelativeName = objDataSet.Tables[0].Rows[i][2].ToString();
                        objApplicantRelationBO.Relationship = objDataSet.Tables[0].Rows[i][3].ToString();
                        objApplicantRelationBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][4].ToString());
                        objApplicantRelationBOList.Add(objApplicantRelationBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetApplicantRelationDetailsList");
                throw ex;
            }
            return objApplicantRelationBOList;
        }

        public static string ProcEditApplicantRealativeData = "usp_SCH_EditApplicantRelativeData";
        public ApplicantRelationBO EditApplicantRelativeData(int iRelationId, int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplicantRelationBO objApplicantRelationBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iRelationId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iRelationId;
                objProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditApplicantRealativeData, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApplicantRelationBO = new ApplicantRelationBO();
                        objApplicantRelationBO.RelationId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApplicantRelationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        objApplicantRelationBO.AnyoneWorkinWIKId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][2].ToString());
                        objApplicantRelationBO.RelativeName = objDataSet.Tables[0].Rows[i][3].ToString();
                        objApplicantRelationBO.Relationship = objDataSet.Tables[0].Rows[i][4].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditApplicantRelativeData");
                throw ex;
            }
            return objApplicantRelationBO;
        }

        public static string ProcDeleteApplicantRelationData = "usp_SCH_DeleteApplicantRelationData";
        public string DeleteApplicantRelationData(int iRelationId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iRelationId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iRelationId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteApplicantRelationData, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DeleteApplicantRelationData");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }
    }
}
