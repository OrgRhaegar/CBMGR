//-----------------------------------------------------------------------
// <copyright file="Dbi.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Common
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Database operator
    /// </summary>
    public class Dbi
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the Dbi class.
        /// </summary>
        public Dbi()
        {
        }
        #endregion

        #region Pulbic methods
        /// <summary>
        /// Test SQL connecion.
        /// </summary>
        /// <returns>Test result. Empty for good.</returns>
        public string TestConnection()
        {
            string testResult = string.Empty;
            using (SqlConnection con = this.CreateConnection())
            {
                try
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandText = "SELECT TOP 10 NAME FROM SYSOBJECTS";
                    con.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    testResult = ex.Message;
                }
            }

            return testResult;
        }

        /// <summary>
        /// Execute none sql query.
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parameter">slq parameter</param>
        /// <returns>Query result</returns>
        public int ExecuteNoneQuery(string sql, SqlParameter parameter)
        {
            SqlParameter[] parArray = new SqlParameter[] { parameter };
            int queryResult = this.ExecuteNoneQuery(sql, parArray);
            return queryResult;
        }

        /// <summary>
        /// Execute none sql query.
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parameters">slq parameter array. Null fro default.</param>
        /// <returns>Query result</returns>
        public int ExecuteNoneQuery(string sql, SqlParameter[] parameters = null)
        {
            int queryResult = -1;
            using (SqlConnection con = this.CreateConnection())
            {
                try
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandText = sql;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    con.Open();
                    queryResult = command.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Log log = new Log(ex);
                    LogQueue.AddToLogQueue(log);
                }
            }

            return queryResult;
        }

        /// <summary>
        /// Get data table
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parameter">sql parameter</param>
        /// <returns>Result data table</returns>
        public DataTable GetDataTable(string sql, SqlParameter parameter)
        {
            SqlParameter[] parArray = new SqlParameter[] { parameter };
            DataTable result = this.GetDataTable(sql, parArray);
            return result;
        }

        /// <summary>
        /// Get data table
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parameters">sql parameter array. Null for default.</param>
        /// <returns>Result data table</returns>
        public DataTable GetDataTable(string sql, SqlParameter[] parameters = null)
        {
            DataTable result = null;
            try
            {
                DataSet dataSet = this.GetDataSet(sql, parameters);
                result = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                LogQueue.AddToLogQueue(ex);
            }

            return result;
        }

        /// <summary>
        /// Get data set
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parameter">sql parameter</param>
        /// <returns>Result data set</returns>
        public DataSet GetDataSet(string sql, SqlParameter parameter)
        {
            SqlParameter[] parArray = new SqlParameter[] { parameter };
            DataSet result = this.GetDataSet(sql, parArray);
            return result;
        }

        /// <summary>
        /// Get data set
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parameters">Sql parameter array. Null for default.</param>
        /// <returns>Result data set</returns>
        public DataSet GetDataSet(string sql, SqlParameter[] parameters = null)
        {
            DataSet result = null;
            using (SqlCommand com = this.CreateCommand(sql, parameters))
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter(com);
                    sda.Fill(result);
                }
                catch (Exception ex)
                {
                    Log log = new Log(ex);
                    LogQueue.AddToLogQueue(log);
                }
            }

            return result;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Create a instance of sql connection.
        /// </summary>
        /// <returns>New connection</returns>
        private SqlConnection CreateConnection()
        {
            SqlConnection con;
            try
            {
                string conStr = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
                string dbServer = GlobalConfig.GlobalPars["DBServer"];
                string dbName = GlobalConfig.GlobalPars["DBName"];
                string dbUser = GlobalConfig.GlobalPars["DBUser"];
                string dbPwd = GlobalConfig.GlobalPars["DBPassword"];
                conStr = string.Format(conStr, dbServer, dbName, dbUser, dbPwd);
                con = new SqlConnection(conStr);
            }
            catch (Exception ex)
            {
                con = null;
                LogQueue.AddToLogQueue(ex);
            }

            return con;
        }

        /// <summary>
        /// Create a instance of sql command.
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parArray">Sql parameter array. Null for default.</param>
        /// <returns>New command</returns>
        private SqlCommand CreateCommand(string sql, SqlParameter[] parArray = null)
        {
            SqlCommand com = null;
            using (SqlConnection con = this.CreateConnection())
            {
                try
                {
                    com = con.CreateCommand();
                    com.CommandText = sql;
                    if (parArray != null)
                    {
                        com.Parameters.AddRange(parArray);
                    }
                }
                catch (Exception ex)
                {
                    LogQueue.AddToLogQueue(ex);
                }
            }

            return com;
        }
        #endregion
    }
}