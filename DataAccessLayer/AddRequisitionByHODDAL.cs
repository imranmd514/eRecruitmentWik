using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDB;
using System.Data;
using Models;
using Utils;


namespace DataAccessLayer
{
    public class AddRequisitionByHODDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcSaveAddRequisitionByHOD = "usp_SCH_saveAddRequisitionByHOD";
        public string SaveAddRequisitionByHOD(AddRequisitionByHODBO objAddRequisitionByHODBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iJobId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAddRequisitionByHODBO.JobId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobTitle";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAddRequisitionByHODBO.JobTitle;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDescription";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAddRequisitionByHODBO.Description;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobType";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAddRequisitionByHODBO.JobType;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSkills";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAddRequisitionByHODBO.Skills;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strExperience";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAddRequisitionByHODBO.Experience;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iCurrentSalary";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAddRequisitionByHODBO.CurrentSalary;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iExpectedSalary";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAddRequisitionByHODBO.ExpectedSalary;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strStatus";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAddRequisitionByHODBO;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objAddRequisitionByHODBO.IsActive;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strResult";
                objDBparameter.dbType = DbType.String;
                objDBparameter.Size = 100;
                objProcParameterBOList.Add(objDBparameter);

                objDBAccess.executeNonQuery(ProcSaveAddRequisitionByHOD, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveAddRequisitionByHOD");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

    }
}