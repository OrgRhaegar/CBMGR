//-----------------------------------------------------------------------
// <copyright file="Dbi.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Common
{
    using System;
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

        public int ExecuteNoneQuery(string sql, SqlParameter parameter)
        {
            int queryResult = -1;
            using (SqlConnection con = this.CreateConnection())
            {
                try
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandText = sql;
                    command.Parameters.Add(parameter);
                    con.Open();
                    queryResult = command.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    // Tudo: add to log querys
                }
            }

            return queryResult;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Create a instance of sql connection.
        /// </summary>
        /// <returns>New connection</returns>
        private SqlConnection CreateConnection()
        {
            string conStr = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
            string dbServer = GlobalConfig.GlobalPars["DBServer"];
            string dbName = GlobalConfig.GlobalPars["DBName"];
            string dbUser = GlobalConfig.GlobalPars["DBUser"];
            string dbPwd = GlobalConfig.GlobalPars["DBPassword"];
            conStr = string.Format(conStr, dbServer, dbName, dbUser, dbPwd);
            SqlConnection con = new SqlConnection(conStr);
            return con;
        }
        #endregion
    }
}