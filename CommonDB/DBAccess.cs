using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace CommonDB
{
    public class DBAccess
    {
        Database database = null;
        DbCommand dbCommand = null;        
        public int executeNonQuery(string strProcedureName, ref List<ProcParameterBO> objDBParameters)
        {
            int result = 0;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                database = factory.Create(DBConstants.ConnectionString);
                dbCommand = database.GetStoredProcCommand(strProcedureName);

                if (objDBParameters != null && objDBParameters.Count > 0)
                {
                    for (int i = 0; i < objDBParameters.Count; i++)
                    {
                        if (objDBParameters[i].Direction == ParameterDirection.Input)
                        {
                            database.AddInParameter(dbCommand, objDBParameters[i].ParameterName, objDBParameters[i].dbType, objDBParameters[i].ParameterValue);
                        }
                        else if (objDBParameters[i].Direction == ParameterDirection.Output)
                        {
                            database.AddOutParameter(dbCommand, objDBParameters[i].ParameterName, objDBParameters[i].dbType, objDBParameters[i].Size);
                        }
                    }
                }

                result = database.ExecuteNonQuery(dbCommand);

                if (objDBParameters != null && objDBParameters.Count > 0)
                {
                    for (int i = 0; i < objDBParameters.Count; i++)
                    {
                        if (objDBParameters[i].Direction == ParameterDirection.Output)
                        {
                            objDBParameters[i].ParameterValue = database.GetParameterValue(dbCommand, objDBParameters[i].ParameterName).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public DataSet execuitDataSet(string strProcedureName, ref List<ProcParameterBO> objDBParameters)
        {
            DataSet objResult = null;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                database = factory.Create(DBConstants.ConnectionString);
                dbCommand = database.GetStoredProcCommand(strProcedureName);

                if (objDBParameters != null && objDBParameters.Count > 0)
                {
                    for (int i = 0; i < objDBParameters.Count; i++)
                    {
                        if (objDBParameters[i].Direction == ParameterDirection.Input)
                        {
                            database.AddInParameter(dbCommand, objDBParameters[i].ParameterName, objDBParameters[i].dbType, objDBParameters[i].ParameterValue);
                        }
                        else if (objDBParameters[i].Direction == ParameterDirection.Output)
                        {
                            database.AddOutParameter(dbCommand, objDBParameters[i].ParameterName, objDBParameters[i].dbType, objDBParameters[i].Size);
                        }
                    }
                }

                objResult = database.ExecuteDataSet(dbCommand);

                if (objDBParameters != null && objDBParameters.Count > 0)
                {
                    for (int i = 0; i < objDBParameters.Count; i++)
                    {
                        if (objDBParameters[i].Direction == ParameterDirection.Output)
                        {
                            objDBParameters[i].ParameterValue = database.GetParameterValue(dbCommand, objDBParameters[i].ParameterName).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResult;
        }

        public IDataReader execuitDataReader(string strProcedureName, ref List<ProcParameterBO> objDBParameters)
        {
            IDataReader objReader = null;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                database = factory.Create(DBConstants.ConnectionString);
                dbCommand = database.GetStoredProcCommand(strProcedureName);
                if (objDBParameters != null && objDBParameters.Count > 0)
                {
                    for (int i = 0; i < objDBParameters.Count; i++)
                    {
                        if (objDBParameters[i].Direction == ParameterDirection.Input)
                        {
                            database.AddInParameter(dbCommand, objDBParameters[i].ParameterName, objDBParameters[i].dbType, objDBParameters[i].ParameterValue);
                        }
                        else if (objDBParameters[i].Direction == ParameterDirection.Output)
                        {
                            database.AddOutParameter(dbCommand, objDBParameters[i].ParameterName, objDBParameters[i].dbType, objDBParameters[i].Size);
                        }
                    }
                }

                objReader = database.ExecuteReader(dbCommand);

                if (objDBParameters != null && objDBParameters.Count > 0)
                {
                    for (int i = 0; i < objDBParameters.Count; i++)
                    {
                        if (objDBParameters[i].Direction == ParameterDirection.Output)
                        {
                            objDBParameters[i].ParameterValue = database.GetParameterValue(dbCommand, objDBParameters[i].ParameterName).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objReader;
        }

        public Object executeScalar(string strProcedureName, ref List<ProcParameterBO> objDBParameters)
        {
            Object result = null;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                database = factory.Create(DBConstants.ConnectionString);
                dbCommand = database.GetStoredProcCommand(strProcedureName);

                if (objDBParameters != null && objDBParameters.Count > 0)
                {
                    for (int i = 0; i < objDBParameters.Count; i++)
                    {
                        if (objDBParameters[i].Direction == ParameterDirection.Input)
                        {
                            database.AddInParameter(dbCommand, objDBParameters[i].ParameterName, objDBParameters[i].dbType, objDBParameters[i].ParameterValue);
                        }
                        else if (objDBParameters[i].Direction == ParameterDirection.Output)
                        {
                            database.AddOutParameter(dbCommand, objDBParameters[i].ParameterName, objDBParameters[i].dbType, objDBParameters[i].Size);
                        }
                    }
                }

                result = database.ExecuteScalar(dbCommand);

                if (objDBParameters != null && objDBParameters.Count > 0)
                {
                    for (int i = 0; i < objDBParameters.Count; i++)
                    {
                        if (objDBParameters[i].Direction == ParameterDirection.Output)
                        {
                            objDBParameters[i].ParameterValue = database.GetParameterValue(dbCommand, objDBParameters[i].ParameterName).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

    }
}
