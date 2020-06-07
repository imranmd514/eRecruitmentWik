using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlTypes;
using Utils;

namespace DataAccessLayer
{
    public class AllApplicantsDAL
    {
       
        DBAccess objDBAccess = new DBAccess();

        string strPhotoUploadPath = ConfigurationManager.AppSettings["Photo"].ToString();

        public static string ProcGetAllApplicantsList = "usp_getAllApplicants";
        public List<AllApplicantsBO> getAllApplicantsList()
        {
            DataSet objDataSet = null;
            AllApplicantsBO objAllApplicantsBO = null;
            List<AllApplicantsBO> objAllApplicantsBOList = new List<AllApplicantsBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetAllApplicantsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objAllApplicantsBO = new AllApplicantsBO();
                        objAllApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objAllApplicantsBO.FirstName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objAllApplicantsBO.PhoneNumber = objDataSet.Tables[0].Rows[i][2].ToString();
                        objAllApplicantsBO.EmailAddress = objDataSet.Tables[0].Rows[i][3].ToString();
                        objAllApplicantsBO.Gender = objDataSet.Tables[0].Rows[i][4].ToString();
                        objAllApplicantsBO.MotherTongue = objDataSet.Tables[0].Rows[i][5].ToString();
                        objAllApplicantsBO.Nationality = objDataSet.Tables[0].Rows[i][6].ToString();

                        // objAllApplicantsBO.Address = objDataSet.Tables[0].Rows[i][4].ToString();
                        // objAllApplicantsBO.Status = objDataSet.Tables[0].Rows[i][5].ToString();
                        // objAllApplicantsBO.ApprovedBy = objDataSet.Tables[0].Rows[i][6].ToString();
                        // objAllApplicantsBO.RejectedBy = objDataSet.Tables[0].Rows[i][7].ToString();
                        // objAllApplicantsBO.Comments = objDataSet.Tables[0].Rows[i][6].ToString();
                        objAllApplicantsBOList.Add(objAllApplicantsBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getAllApplicantsList");
                throw ex;
            }
            return objAllApplicantsBOList;
        }


        //save Approved Applicant

        public static string ProcSaveApprovedApplicant = "usp_SCH_SaveApprovedApplicant";
        public string saveApprovedApplicant(AllApplicantsBO objAllApplicantsBO, int iUserId)
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
                objDBparameter.ParameterValue = objAllApplicantsBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strFirstName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.FirstName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMiddleName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.MiddleName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLastName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.LastName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPhoneNumber";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.PhoneNumber;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmailAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.EmailAddress;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.Address;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCV";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.CV;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCVSavedName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.CVSavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iStatusId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllApplicantsBO.StatusId;
                objProcParameterBOList.Add(objDBparameter);
                
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApprovedBy";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllApplicantsBO.ApprovedById;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strApprovedDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.ApprovedDate;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.Comments;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objAllApplicantsBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcSaveApprovedApplicant, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "saveApprovedApplicant");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


      //  Save Rejected Applicant

        public static string ProcRejectedApplicant = "usp_SCH_saveApplicantRejected";
        public string saveRejectedApplicant(AllApplicantsBO objAllApplicantsBO, int iUserId)
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
                objDBparameter.ParameterValue = objAllApplicantsBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strFirstName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.FirstName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMiddleName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.MiddleName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLastName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.LastName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPhoneNumber";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.PhoneNumber;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmailAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.EmailAddress;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.Address;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCV";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.CV;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCVSavedName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.CVSavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iStatusId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllApplicantsBO.StatusId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRejectedBy";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllApplicantsBO.RejectedById;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strRejectedDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.RejectedDate;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.Comments;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objAllApplicantsBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcRejectedApplicant, ref objProcParameterBOList);

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


    //    Save OnHold Applicant

        public static string ProcOnHoldApplicant = "usp_SCH_saveApplicantOnHold";
        public string saveOnHoldApplicant(AllApplicantsBO objAllApplicantsBO, int iUserId)
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
                objDBparameter.ParameterValue = objAllApplicantsBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strFirstName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.FirstName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMiddleName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.MiddleName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLastName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.LastName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPhoneNumber";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.PhoneNumber;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmailAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.EmailAddress;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.Address;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCV";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.CV;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCVSavedName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.CVSavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iStatusId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllApplicantsBO.StatusId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApprovedBy";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllApplicantsBO.ApprovedById;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strApprovedDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.ApprovedDate;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRejectedBy";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllApplicantsBO.RejectedBy;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strRejectedDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.RejectedDate;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllApplicantsBO.Comments;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objAllApplicantsBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcOnHoldApplicant, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "saveOnHoldApplicant");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }



      //  Edit All Applicants

        public static string ProcEditAllApplicants = "usp_EditAllApplicantDetails";
        public AllApplicantsBO EditAllApplicants(int iApplicantId)
        {
            DataSet objDataSet = null;
            AllApplicantsBO objAllApplicantsBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditAllApplicants, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objAllApplicantsBO = new AllApplicantsBO();
                    objAllApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objAllApplicantsBO.FirstName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objAllApplicantsBO.MiddleName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objAllApplicantsBO.LastName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objAllApplicantsBO.PhoneNumber = objDataSet.Tables[0].Rows[0][4].ToString();
                    objAllApplicantsBO.EmailAddress = objDataSet.Tables[0].Rows[0][5].ToString();
                    objAllApplicantsBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][6].ToString();
                    objAllApplicantsBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][7].ToString();
                    objAllApplicantsBO.Address = objDataSet.Tables[0].Rows[0][8].ToString();
                    objAllApplicantsBO.CV = objDataSet.Tables[0].Rows[0][9].ToString();
                    objAllApplicantsBO.CVSavedName = objDataSet.Tables[0].Rows[0][10].ToString();
                    objAllApplicantsBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][11].ToString();
                    objAllApplicantsBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][12].ToString();
                    objAllApplicantsBO.Comments = objDataSet.Tables[0].Rows[0][13].ToString();
                    objAllApplicantsBO.Bachelors = objDataSet.Tables[0].Rows[0][14].ToString();
                    objAllApplicantsBO.BachelorsSavedName = objDataSet.Tables[0].Rows[0][15].ToString();
                    objAllApplicantsBO.Diploma = objDataSet.Tables[0].Rows[0][16].ToString();
                    objAllApplicantsBO.DiplomaSavedName = objDataSet.Tables[0].Rows[0][17].ToString();
                    objAllApplicantsBO.MSC = objDataSet.Tables[0].Rows[0][18].ToString();
                    objAllApplicantsBO.MSCSavedName = objDataSet.Tables[0].Rows[0][19].ToString();
                    objAllApplicantsBO.PHD = objDataSet.Tables[0].Rows[0][20].ToString();
                    objAllApplicantsBO.PHDSavedName = objDataSet.Tables[0].Rows[0][21].ToString();
                    objAllApplicantsBO.QuaStartDate = objDataSet.Tables[0].Rows[0][22].ToString();
                    objAllApplicantsBO.QuaEndDate = objDataSet.Tables[0].Rows[0][23].ToString();
                    objAllApplicantsBO.Discipline = objDataSet.Tables[0].Rows[0][24].ToString();
                    objAllApplicantsBO.University = objDataSet.Tables[0].Rows[0][25].ToString();
                    objAllApplicantsBO.QuaNationality = objDataSet.Tables[0].Rows[0][26].ToString();
                    objAllApplicantsBO.Degree = objDataSet.Tables[0].Rows[0][27].ToString();
                    objAllApplicantsBO.Class = objDataSet.Tables[0].Rows[0][28].ToString();
                    objAllApplicantsBO.EmployerName = objDataSet.Tables[0].Rows[0][29].ToString();
                    objAllApplicantsBO.TypeOfIndustry = objDataSet.Tables[0].Rows[0][30].ToString();
                    objAllApplicantsBO.TelephoneContact = objDataSet.Tables[0].Rows[0][31].ToString();
                    objAllApplicantsBO.JobTitle = objDataSet.Tables[0].Rows[0][32].ToString();
                    objAllApplicantsBO.City = objDataSet.Tables[0].Rows[0][33].ToString();
                    objAllApplicantsBO.EmpStartDate = objDataSet.Tables[0].Rows[0][34].ToString();
                    objAllApplicantsBO.EmpEndDate = objDataSet.Tables[0].Rows[0][35].ToString();
                    objAllApplicantsBO.Responsibility = objDataSet.Tables[0].Rows[0][36].ToString();
                    objAllApplicantsBO.MonthlySalary = objDataSet.Tables[0].Rows[0][37].ToString();
                    objAllApplicantsBO.NoticePeriod = objDataSet.Tables[0].Rows[0][38].ToString();
                    
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditAllApplicants");
                throw ex;
            }
            return objAllApplicantsBO;
        }


     


        public static string ProcViewApplicant = "usp_SCH_ViewApplicantRegistration";
        public AllApplicantsBO ViewAllApplicant(int iApplicantId)
        {
            DataSet objDataSet = null;
            AllApplicantsBO objAllApplicantsBO = null;
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
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewApplicant, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objAllApplicantsBO = new AllApplicantsBO();
                    objAllApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objAllApplicantsBO.Title = objDataSet.Tables[0].Rows[0][1].ToString();
                    objAllApplicantsBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objAllApplicantsBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objAllApplicantsBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
                    objAllApplicantsBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
                    objAllApplicantsBO.Gender = objDataSet.Tables[0].Rows[0][6].ToString();
                    objAllApplicantsBO.IdType = objDataSet.Tables[0].Rows[0][7].ToString();
                    objAllApplicantsBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][8].ToString();
                    objAllApplicantsBO.CitizenShipIdCopySavedName = objDataSet.Tables[0].Rows[0][9].ToString();
                    objAllApplicantsBO.Country = objDataSet.Tables[0].Rows[0][10].ToString();
                    objAllApplicantsBO.EmailAddress = objDataSet.Tables[0].Rows[0][11].ToString();
                    objAllApplicantsBO.PhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
                    objAllApplicantsBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][13].ToString();
                    objAllApplicantsBO.MotherTongue = objDataSet.Tables[0].Rows[0][14].ToString();
                    objAllApplicantsBO.Nationality = objDataSet.Tables[0].Rows[0][15].ToString();
                    objAllApplicantsBO.County = objDataSet.Tables[0].Rows[0][16].ToString();
                    objAllApplicantsBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][17].ToString();
                    objAllApplicantsBO.ApplicationLetterSavedName = objDataSet.Tables[0].Rows[0][18].ToString();
                    objAllApplicantsBO.CV = objDataSet.Tables[0].Rows[0][19].ToString();
                    objAllApplicantsBO.CVSavedName = objDataSet.Tables[0].Rows[0][20].ToString();
                    objAllApplicantsBO.SpecialNeed = objDataSet.Tables[0].Rows[0][21].ToString();
                    objAllApplicantsBO.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][22].ToString();
                    objAllApplicantsBO.Address = objDataSet.Tables[0].Rows[0][23].ToString();
                    objAllApplicantsBO.Photo = objDataSet.Tables[0].Rows[0][24].ToString();
                    objAllApplicantsBO.PhotoSavedName = objDataSet.Tables[0].Rows[0][25].ToString();

                    if (objDataSet != null && objDataSet.Tables[1].Rows.Count > 0)
                    {
                        objAllApplicantsBO.ApplicantRelationList = new List<ApplicantRelationBO>();
                        for (int i = 0; i < objDataSet.Tables[1].Rows.Count; i++)
                        {
                            objApplicantRelationBO = new ApplicantRelationBO();
                            objApplicantRelationBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[1].Rows[i][0].ToString());
                            objApplicantRelationBO.RelationId = Convert.ToInt32(objDataSet.Tables[1].Rows[i][1].ToString());
                            objApplicantRelationBO.AnyoneWorkinWIK = objDataSet.Tables[1].Rows[i][2].ToString();
                            objApplicantRelationBO.RelativeName = objDataSet.Tables[1].Rows[i][3].ToString();
                            objApplicantRelationBO.Relationship = objDataSet.Tables[1].Rows[i][4].ToString();
                            objAllApplicantsBO.ApplicantRelationList.Add(objApplicantRelationBO);
                        }
                    }

                    if (objDataSet != null && objDataSet.Tables[2].Rows.Count > 0)
                    {
                        objAllApplicantsBO.ApplicantLanguageList = new List<LanguageSpokenBO>();
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
                            objAllApplicantsBO.ApplicantLanguageList.Add(objLanguageSpokenBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[3].Rows.Count > 0)
                    {
                        objAllApplicantsBO.ApplicantQualificationList = new List<ApplicantQualificationBO>();
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
                            objAllApplicantsBO.ApplicantQualificationList.Add(objApplicantQualificationBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[4].Rows.Count > 0)
                    {
                        objAllApplicantsBO.ApplicantEmploymentList = new List<ApplicantEmploymentHistoryBO>();
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
                            objAllApplicantsBO.ApplicantEmploymentList.Add(objApplicantEmploymentHistoryBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[5].Rows.Count > 0)
                    {
                        objAllApplicantsBO.ApplicantRefereesList = new List<ApplicantRefereesBO>();
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
                            objAllApplicantsBO.ApplicantRefereesList.Add(objApplicantRefereesBO);
                        }
                    }
                    if (objDataSet != null && objDataSet.Tables[6].Rows.Count > 0)
                    {
                        objAllApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[6].Rows[0][0].ToString());
                        objAllApplicantsBO.ApplicantMotivationId = Convert.ToInt32(objDataSet.Tables[6].Rows[0][1].ToString());
                        objAllApplicantsBO.MembershipData = objDataSet.Tables[6].Rows[0][2].ToString();
                        objAllApplicantsBO.NameofProfessionalBody = objDataSet.Tables[6].Rows[0][3].ToString();
                        objAllApplicantsBO.MembershipNumber = objDataSet.Tables[6].Rows[0][4].ToString();
                        objAllApplicantsBO.ValidityData = objDataSet.Tables[6].Rows[0][5].ToString();
                        objAllApplicantsBO.JobDescription = objDataSet.Tables[6].Rows[0][6].ToString();
                        objAllApplicantsBO.Referer = objDataSet.Tables[6].Rows[0][7].ToString();
                        objAllApplicantsBO.ApplicationNote = objDataSet.Tables[6].Rows[0][8].ToString();
                    }

                    if (objDataSet != null && objDataSet.Tables[7].Rows.Count > 0)
                    {
                        objAllApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[7].Rows[0][0].ToString());
                        objAllApplicantsBO.TerminatedId = objDataSet.Tables[7].Rows[0][1].ToString();
                        objAllApplicantsBO.Terminatation = objDataSet.Tables[7].Rows[0][2].ToString();
                        objAllApplicantsBO.MisconductId = objDataSet.Tables[7].Rows[0][3].ToString();
                        objAllApplicantsBO.Misconduct = objDataSet.Tables[7].Rows[0][4].ToString();
                        objAllApplicantsBO.ManagementId = objDataSet.Tables[7].Rows[0][5].ToString();
                        objAllApplicantsBO.Management = objDataSet.Tables[7].Rows[0][6].ToString();
                        objAllApplicantsBO.InvestigationId = objDataSet.Tables[7].Rows[0][7].ToString();
                        objAllApplicantsBO.Investigation = objDataSet.Tables[7].Rows[0][8].ToString();


                        objAllApplicantsBO.CriminalOffenceId = objDataSet.Tables[7].Rows[0][9].ToString();
                        objAllApplicantsBO.CriminalOffence = objDataSet.Tables[7].Rows[0][10].ToString();
                        objAllApplicantsBO.ConvictionsId = objDataSet.Tables[7].Rows[0][11].ToString();
                        objAllApplicantsBO.Convictions = objDataSet.Tables[7].Rows[0][12].ToString();
                        objAllApplicantsBO.CorruptionId = objDataSet.Tables[7].Rows[0][13].ToString();
                        objAllApplicantsBO.Corruption = objDataSet.Tables[7].Rows[0][14].ToString();
                        objAllApplicantsBO.DisciplinaryId = objDataSet.Tables[7].Rows[0][15].ToString();
                        objAllApplicantsBO.Disciplinary = objDataSet.Tables[7].Rows[0][16].ToString();
                        objAllApplicantsBO.RelationToChildId = objDataSet.Tables[7].Rows[0][17].ToString();
                        objAllApplicantsBO.RelationToChild = objDataSet.Tables[7].Rows[0][18].ToString();
                        objAllApplicantsBO.RelationToAdultId = objDataSet.Tables[7].Rows[0][19].ToString();
                        objAllApplicantsBO.RelationToAdult = objDataSet.Tables[7].Rows[0][20].ToString();
                        objAllApplicantsBO.RelativeId = objDataSet.Tables[7].Rows[0][21].ToString();
                        objAllApplicantsBO.DealingsWithWIKId = objDataSet.Tables[7].Rows[0][22].ToString();
                        objAllApplicantsBO.DealingsWithWIK = objDataSet.Tables[7].Rows[0][23].ToString();
                        objAllApplicantsBO.Declarationinfo = Convert.ToBoolean(objDataSet.Tables[7].Rows[0][24].ToString());
                        objAllApplicantsBO.Statement = Convert.ToBoolean(objDataSet.Tables[7].Rows[0][25].ToString());

                        objAllApplicantsBO.DeclarationID = Convert.ToInt32(objDataSet.Tables[7].Rows[0][26].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "ViewAllApplicant");
                throw ex;
            }
            return objAllApplicantsBO; ;
        }

        //Delete All Applicants

        public static string ProcDeleteAllApplicants = "usp_deleteAllApplicant";
        public string deleteAllApplicants(int iApplicantId)
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

                objDBAccess.executeNonQuery(ProcDeleteAllApplicants, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "deleteAllApplicants");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        //public static string ProcViewAllApplicant = "usp_SCH_ViewAllApplicants";
        //public AllApplicantsBO ViewAllApplicant(int iApplicantId)
        //{
        //    DataSet objDataSet = null;
        //    AllApplicantsBO objAllApplicantsBO = null;
        //    List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

        //    try
        //    {
        //        ProcParameterBO objDbParameter = new ProcParameterBO();
        //        objDbParameter.Direction = ParameterDirection.Input;
        //        objDbParameter.ParameterName = "@iApplicantId";
        //        objDbParameter.dbType = DbType.Int32;
        //        objDbParameter.ParameterValue = iApplicantId;
        //        objProcParameterBOList.Add(objDbParameter);

        //        objDataSet = objDBAccess.execuitDataSet(ProcViewAllApplicant, ref objProcParameterBOList);
        //        if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            objAllApplicantsBO = new AllApplicantsBO();
        //            objAllApplicantsBO.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
        //            objAllApplicantsBO.Title = objDataSet.Tables[0].Rows[0][1].ToString();
        //            objAllApplicantsBO.FirstName = objDataSet.Tables[0].Rows[0][2].ToString();
        //            objAllApplicantsBO.MiddleName = objDataSet.Tables[0].Rows[0][3].ToString();
        //            objAllApplicantsBO.LastName = objDataSet.Tables[0].Rows[0][4].ToString();
        //            objAllApplicantsBO.DateOfBirth = objDataSet.Tables[0].Rows[0][5].ToString();
        //            objAllApplicantsBO.Citizenship = objDataSet.Tables[0].Rows[0][6].ToString();
        //            objAllApplicantsBO.Gender = objDataSet.Tables[0].Rows[0][7].ToString();
        //            objAllApplicantsBO.Address = objDataSet.Tables[0].Rows[0][8].ToString();
        //            objAllApplicantsBO.Country = objDataSet.Tables[0].Rows[0][9].ToString();
        //            objAllApplicantsBO.EmailAddress = objDataSet.Tables[0].Rows[0][10].ToString();
        //            objAllApplicantsBO.PhoneNumber = objDataSet.Tables[0].Rows[0][11].ToString();
        //            objAllApplicantsBO.AlternativePhoneNumber = objDataSet.Tables[0].Rows[0][12].ToString();
        //            objAllApplicantsBO.LanguageSpoken = objDataSet.Tables[0].Rows[0][13].ToString();
        //            objAllApplicantsBO.Nationality = objDataSet.Tables[0].Rows[0][14].ToString();
        //            objAllApplicantsBO.ApplicationLetter = objDataSet.Tables[0].Rows[0][15].ToString();
        //            objAllApplicantsBO.FileSavedName1 = objDataSet.Tables[0].Rows[0][16].ToString();
        //            objAllApplicantsBO.Resume = objDataSet.Tables[0].Rows[0][17].ToString();
        //            objAllApplicantsBO.FileSavedName = objDataSet.Tables[0].Rows[0][18].ToString();
        //            objAllApplicantsBO.CitizenShipIdCopy = objDataSet.Tables[0].Rows[0][19].ToString();
        //            objAllApplicantsBO.CitizenShipIdSaveCopy = objDataSet.Tables[0].Rows[0][20].ToString();
        //            objAllApplicantsBO.Endlish = objDataSet.Tables[0].Rows[0][21].ToString();
        //            objAllApplicantsBO.Kiswahili = objDataSet.Tables[0].Rows[0][22].ToString();
        //            objAllApplicantsBO.SpecialNeed = objDataSet.Tables[0].Rows[0][23].ToString();
        //            objAllApplicantsBO.SpecialNeedDetails = objDataSet.Tables[0].Rows[0][24].ToString();
        //            objAllApplicantsBO.Bachelors = objDataSet.Tables[0].Rows[0][25].ToString();
        //            objAllApplicantsBO.FileSavedName2 = objDataSet.Tables[0].Rows[0][26].ToString();
        //            objAllApplicantsBO.Diploma = objDataSet.Tables[0].Rows[0][27].ToString();
        //            objAllApplicantsBO.FileSavedName3 = objDataSet.Tables[0].Rows[0][28].ToString();
        //            objAllApplicantsBO.MSC = objDataSet.Tables[0].Rows[0][29].ToString();
        //            objAllApplicantsBO.FileSavedName4 = objDataSet.Tables[0].Rows[0][30].ToString();
        //            objAllApplicantsBO.PHD = objDataSet.Tables[0].Rows[0][31].ToString();
        //            objAllApplicantsBO.FileSavedName5 = objDataSet.Tables[0].Rows[0][32].ToString();
        //            objAllApplicantsBO.QuaStartDate = objDataSet.Tables[0].Rows[0][33].ToString();
        //            objAllApplicantsBO.QuaEndDate = objDataSet.Tables[0].Rows[0][34].ToString();
        //            objAllApplicantsBO.Discipline = objDataSet.Tables[0].Rows[0][35].ToString();
        //            objAllApplicantsBO.University = objDataSet.Tables[0].Rows[0][36].ToString();
        //            objAllApplicantsBO.QuaCountry = objDataSet.Tables[0].Rows[0][37].ToString();
        //            objAllApplicantsBO.Degree = objDataSet.Tables[0].Rows[0][38].ToString();
        //            objAllApplicantsBO.Class = objDataSet.Tables[0].Rows[0][39].ToString();
        //            objAllApplicantsBO.EmployerName = objDataSet.Tables[0].Rows[0][40].ToString();
        //            objAllApplicantsBO.TypeOfIndustry = objDataSet.Tables[0].Rows[0][41].ToString();
        //            objAllApplicantsBO.EmpAddress = objDataSet.Tables[0].Rows[0][42].ToString();
        //            objAllApplicantsBO.City = objDataSet.Tables[0].Rows[0][43].ToString();
        //            objAllApplicantsBO.PostalCode = objDataSet.Tables[0].Rows[0][44].ToString();
        //            objAllApplicantsBO.JobTitle = objDataSet.Tables[0].Rows[0][45].ToString();
        //            objAllApplicantsBO.TelephoneNo = objDataSet.Tables[0].Rows[0][46].ToString();
        //            objAllApplicantsBO.TitleOfSupervisor = objDataSet.Tables[0].Rows[0][47].ToString();
        //            objAllApplicantsBO.StartDate = objDataSet.Tables[0].Rows[0][48].ToString();
        //            objAllApplicantsBO.EndDate = objDataSet.Tables[0].Rows[0][49].ToString();
        //            objAllApplicantsBO.Responsibility = objDataSet.Tables[0].Rows[0][50].ToString();
        //            objAllApplicantsBO.MonthlySalary = objDataSet.Tables[0].Rows[0][51].ToString();
        //            objAllApplicantsBO.NoticePeriod = objDataSet.Tables[0].Rows[0][52].ToString();
        //            objAllApplicantsBO.EmpFirstName = objDataSet.Tables[0].Rows[0][53].ToString();
        //            objAllApplicantsBO.SecondName = objDataSet.Tables[0].Rows[0][54].ToString();
        //            objAllApplicantsBO.Position = objDataSet.Tables[0].Rows[0][55].ToString();
        //            objAllApplicantsBO.RelationshipTOApplicant = objDataSet.Tables[0].Rows[0][56].ToString();
        //            objAllApplicantsBO.NameOfTheOrganization = objDataSet.Tables[0].Rows[0][57].ToString();
        //            objAllApplicantsBO.TelephoneContact = objDataSet.Tables[0].Rows[0][58].ToString();
        //            objAllApplicantsBO.EmpEmailAddress = objDataSet.Tables[0].Rows[0][59].ToString();
        //            objAllApplicantsBO.JobDescription = objDataSet.Tables[0].Rows[0][60].ToString();
        //            objAllApplicantsBO.Referer = objDataSet.Tables[0].Rows[0][61].ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objAllApplicantsBO;
        //}
    }
}
