using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;
using CommonDB;
using Utils;

namespace DataAccessLayer
{
   public class DonorProgramDAL
    {
        DBAccess objDBAccess = new DBAccess();


        public static string ProcGetDonorList = "usp_SCH_GetDonorListDetails";
        public List<DonorProgramBO> GetDonorList()
        {
            DataSet objDataSet = null;
            DonorProgramBO objDonorProgramBO = null;
            List<DonorProgramBO> objListDonorProgramBO = new List<DonorProgramBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetDonorList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objDonorProgramBO = new DonorProgramBO();
                        objDonorProgramBO.DonorProgramId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objDonorProgramBO.DonorProgram = objDataSet.Tables[0].Rows[i][1].ToString();
                        objDonorProgramBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][2].ToString());
                        objListDonorProgramBO.Add(objDonorProgramBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetDonorList");
                throw ex;
            }
            return objListDonorProgramBO;
        }


        public static string ProcsaveDonor = "usp_SCH_saveDonorProgram";
        public string SaveorUpdateDonor(DonorProgramBO objDonorProgramBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iDonorProgramId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objDonorProgramBO.DonorProgramId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDonorProgram";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objDonorProgramBO.DonorProgram;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objDonorProgramBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcsaveDonor, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateDonor");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }



        public static string ProcEditDonor = "usp_SCH_EditDonor";
        public DonorProgramBO EditDonor(int iDonorProgramId)
        {
            DataSet objDataSet = null;
            DonorProgramBO objDonorProgramBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iDonorProgramId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iDonorProgramId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditDonor, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objDonorProgramBO = new DonorProgramBO();
                    objDonorProgramBO.DonorProgramId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objDonorProgramBO.DonorProgram = objDataSet.Tables[0].Rows[0][1].ToString();                
                    objDonorProgramBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][2].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditDonor");
                throw ex;
            }
            return objDonorProgramBO;
        }



        public static string ProcdeleteDonor = "usp_SCH_deleteDonor";
        public string deleteDonor(int iDonorProgramId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iDonorProgramId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iDonorProgramId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcdeleteDonor, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "deleteDonor");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

    }

}

