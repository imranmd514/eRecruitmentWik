using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class UserRegistrationDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcRolesDropDown = "usp_RolesDropdown";
        public List<CommonDropDownBO> RolesList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcRolesDropDown, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "RolesList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }

        public static string ProcDonorDropDown = "usp_getDonorProgram";
        public List<CommonDropDownBO> getDonorProgramList(int iUserId)
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objParameterBO = new ProcParameterBO();
                objParameterBO.Direction = ParameterDirection.Input;
                objParameterBO.ParameterName = "@iUserId";
                objParameterBO.dbType = DbType.Int32;
                objParameterBO.ParameterValue = iUserId;
                objProcParameterBOList.Add(objParameterBO);

                objDataSet = objDBAccess.execuitDataSet(ProcDonorDropDown, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "getDonorProgramList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }

        //Country Dropdown

        public static string ProcCountriesList = "usp_SCH_dropdownCountry";
        public List<CommonDropDownBO> CountriesList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcCountriesList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "CountriesList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }

        //State Dropdown

        public static string ProcStatesList = "usp_SCH_dropdownState";
      
        public List<CommonDropDownBO> StatesList(int iCountryId)
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {

                ProcParameterBO objProcParameterBo = new ProcParameterBO();
                objProcParameterBo.Direction = ParameterDirection.Input;
                objProcParameterBo.ParameterName = "@iCountryId";
                objProcParameterBo.dbType = DbType.Int32;
                objProcParameterBo.ParameterValue = iCountryId;
                objProcParameterBOList.Add(objProcParameterBo);

                objDataSet = objDBAccess.execuitDataSet(ProcStatesList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "StatesList");
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

        public static string ProcLocationList = "usp_SCH_DropdownLocationList";
        public List<CommonDropDownBO> LocationList()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcLocationList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "LocationList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }


        //Users List

        public static string ProcGetUsersList = "usp_SCH_selectUser";
        public List<UserRegistrationBO> getUsersList()
        {
            DataSet objDataSet = null;
            UserRegistrationBO objUserRegistrationBO = null;
            List<UserRegistrationBO> objUserRegistrationBOList = new List<UserRegistrationBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetUsersList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objUserRegistrationBO = new UserRegistrationBO();
                        objUserRegistrationBO.UserId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objUserRegistrationBO.FirstName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objUserRegistrationBO.LastName = objDataSet.Tables[0].Rows[i][2].ToString();
                        objUserRegistrationBO.EmailAddress = objDataSet.Tables[0].Rows[i][3].ToString();
                        objUserRegistrationBO.MobileNumber = objDataSet.Tables[0].Rows[i][4].ToString();
                        objUserRegistrationBO.Department = objDataSet.Tables[0].Rows[i][5].ToString();
                        objUserRegistrationBO.City = objDataSet.Tables[0].Rows[i][6].ToString();
                        objUserRegistrationBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][7].ToString());
                        objUserRegistrationBOList.Add(objUserRegistrationBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getUsersList");
                throw ex;
            }
            return objUserRegistrationBOList;
        }

        //Save User

        public static string ProcSaveUserRegistration = "usp_SCH_saveUserRegistration";
        public string SaveorUpdateUserRegistration(UserRegistrationBO objUserRegistrationBO, int A_iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iUserId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objUserRegistrationBO.UserId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strFirstName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.FirstName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMiddleName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.MiddleName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLastName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.LastName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPhoto";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.Photo;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strActualFileName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.FileSavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPassword";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.Password;
                objProcParameterBOList.Add(objDBparameter);
                
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDateOfBirth";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.DateOfBirth;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strGender";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.Gender;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMobileNumber";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.MobileNumber;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAlternateMobileNumber";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.AlternateMobileNumber;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmailAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.EmailAddress;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLanguage";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.Language;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strQualification";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.Qualification;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCollege";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.College;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strUniversity";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.University;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAggregatePercentage";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.AggregatePercentage;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJoiningDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.JoiningDate;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCountry";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objUserRegistrationBO.CountryId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strState";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objUserRegistrationBO.StateId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCity";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.City;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iLocationId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objUserRegistrationBO.LocationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strUserType";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.UserType;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRoleId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.UserRole;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDonorProgram";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.DonorProgram;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDepartment";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.Department;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = 0;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objUserRegistrationBO.Address;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objUserRegistrationBO.IsActive;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@buserid";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = A_iUserId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Output;
                objDBparameter.ParameterName = "@strResult";
                objDBparameter.dbType = DbType.String;
                objDBparameter.Size = 100;
                objProcParameterBOList.Add(objDBparameter);


                objDBAccess.executeNonQuery(ProcSaveUserRegistration, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateUserRegistration");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        //Edit User

        public static string ProcEditUser = "usp_EditUser";
        public UserRegistrationBO EditUserDetails(int iUserId)
        {
            DataSet objDataSet = null;
            UserRegistrationBO objUserRegistrationBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iuserId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iUserId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditUser, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objUserRegistrationBO = new UserRegistrationBO();
                    objUserRegistrationBO.UserId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objUserRegistrationBO.FirstName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objUserRegistrationBO.MiddleName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objUserRegistrationBO.LastName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objUserRegistrationBO.Photo = objDataSet.Tables[0].Rows[0][4].ToString();
                    objUserRegistrationBO.Password = objDataSet.Tables[0].Rows[0][5].ToString();
                    //objUserRegistrationBO.ConfirmPassword = objDataSet.Tables[0].Rows[0][6].ToString();
                    objUserRegistrationBO.Gender = objDataSet.Tables[0].Rows[0][6].ToString();
                    objUserRegistrationBO.MobileNumber = objDataSet.Tables[0].Rows[0][7].ToString();
                    objUserRegistrationBO.AlternateMobileNumber = objDataSet.Tables[0].Rows[0][8].ToString();
                    objUserRegistrationBO.EmailAddress = objDataSet.Tables[0].Rows[0][9].ToString();
                    objUserRegistrationBO.Language = objDataSet.Tables[0].Rows[0][10].ToString();
                    objUserRegistrationBO.Qualification = objDataSet.Tables[0].Rows[0][11].ToString();
                    objUserRegistrationBO.College = objDataSet.Tables[0].Rows[0][12].ToString();
                    objUserRegistrationBO.University = objDataSet.Tables[0].Rows[0][13].ToString();
                    objUserRegistrationBO.AggregatePercentage = objDataSet.Tables[0].Rows[0][14].ToString();
                    objUserRegistrationBO.JoiningDate = objDataSet.Tables[0].Rows[0][15].ToString();
                    objUserRegistrationBO.CountryId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][16].ToString());
                    objUserRegistrationBO.StateId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][17].ToString());
                    objUserRegistrationBO.City = objDataSet.Tables[0].Rows[0][18].ToString();
                    objUserRegistrationBO.UserType = objDataSet.Tables[0].Rows[0][19].ToString();
                    objUserRegistrationBO.UserRole = objDataSet.Tables[0].Rows[0][20].ToString();
                    objUserRegistrationBO.DonorProgram = objDataSet.Tables[0].Rows[0][21].ToString();
                    objUserRegistrationBO.Department = objDataSet.Tables[0].Rows[0][22].ToString();
                    objUserRegistrationBO.Address = objDataSet.Tables[0].Rows[0][23].ToString();
                    objUserRegistrationBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][24].ToString());
                    objUserRegistrationBO.DateOfBirth = objDataSet.Tables[0].Rows[0][25].ToString();
                    objUserRegistrationBO.FileSavedName = objDataSet.Tables[0].Rows[0][26].ToString();
                    objUserRegistrationBO.LocationId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][27].ToString());

                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditUserDetails");
                throw ex;
            }
            return objUserRegistrationBO;
        }

        //View User
        public static string ProcViewUser = "usp_SCH_viewUser";
        public UserRegistrationBO DisplayUser(int iUserId)
        {
            DataSet objDataSet = null;
            UserRegistrationBO objUserRegistrationBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iUserId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iUserId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewUser, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objUserRegistrationBO = new UserRegistrationBO();
                    objUserRegistrationBO.UserId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objUserRegistrationBO.FirstName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objUserRegistrationBO.MiddleName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objUserRegistrationBO.LastName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objUserRegistrationBO.Gender = objDataSet.Tables[0].Rows[0][4].ToString();
                    objUserRegistrationBO.MobileNumber = objDataSet.Tables[0].Rows[0][5].ToString();
                    objUserRegistrationBO.AlternateMobileNumber = objDataSet.Tables[0].Rows[0][6].ToString();
                    objUserRegistrationBO.EmailAddress = objDataSet.Tables[0].Rows[0][7].ToString();
                    objUserRegistrationBO.Language = objDataSet.Tables[0].Rows[0][8].ToString();
                    objUserRegistrationBO.Qualification = objDataSet.Tables[0].Rows[0][9].ToString();
                    objUserRegistrationBO.College = objDataSet.Tables[0].Rows[0][10].ToString();
                    objUserRegistrationBO.University = objDataSet.Tables[0].Rows[0][11].ToString();
                    objUserRegistrationBO.AggregatePercentage = objDataSet.Tables[0].Rows[0][12].ToString();
                    objUserRegistrationBO.JoiningDate = objDataSet.Tables[0].Rows[0][13].ToString();
                    objUserRegistrationBO.Country = objDataSet.Tables[0].Rows[0][14].ToString();
                    objUserRegistrationBO.State = objDataSet.Tables[0].Rows[0][15].ToString();
                    objUserRegistrationBO.City = objDataSet.Tables[0].Rows[0][16].ToString();
                    objUserRegistrationBO.UserType = objDataSet.Tables[0].Rows[0][17].ToString();
                    objUserRegistrationBO.UserRole = objDataSet.Tables[0].Rows[0][18].ToString();
                    objUserRegistrationBO.Department = objDataSet.Tables[0].Rows[0][19].ToString();
                    objUserRegistrationBO.Address = objDataSet.Tables[0].Rows[0][20].ToString();
                    objUserRegistrationBO.Photo = objDataSet.Tables[0].Rows[0][21].ToString();
                    objUserRegistrationBO.FileSavedName = objDataSet.Tables[0].Rows[0][22].ToString();
                    objUserRegistrationBO.DonorProgram = objDataSet.Tables[0].Rows[0][23].ToString();
                    objUserRegistrationBO.Location = objDataSet.Tables[0].Rows[0][24].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DisplayUser");
                throw ex;
            }
            return objUserRegistrationBO;
        }

        
        //Delete User
        public static string ProcDeleteUser = "usp_SCH_deleteUser";
        public string deleteUser(int iUserId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iUserId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iUserId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteUser, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "deleteUser");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

    }

}

