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
        #region Fields
        /// <summary>
        /// Database connection
        /// </summary>
        private SqlConnection con;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the Dbi class.
        /// </summary>
        public Dbi()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets database connection.
        /// </summary>
        private SqlConnection Connection
        {
            get
            {
                if (this.con == null)
                {
                    this.RestConnection();
                }

                return this.con;
            }
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
            try
            {
                SqlCommand command = this.Connection.CreateCommand();
                command.CommandText = "SELECT TOP 10 NAME FROM SYSOBJECTS";
                this.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                testResult = ex.Message;
            }
            finally
            {
                this.Connection.Close();
            }

            return testResult;
        }

        /// <summary>
        /// Resutl SQL connecion.
        /// </summary>
        /// <returns>Reset result</returns>
        public bool RestConnection()
        {
            bool resetResult = true;
            try
            {
                string conStr = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
                string dbServer = GlobalConfig.GlobalPars["DBServer"];
                string dbName = GlobalConfig.GlobalPars["DBName"];
                string dbUser = GlobalConfig.GlobalPars["DBUser"];
                string dbPwd = GlobalConfig.GlobalPars["DBPassword"];
                conStr = string.Format(conStr, dbServer, dbName, dbUser, dbPwd);
                this.con = new SqlConnection(conStr);
            }
            catch (Exception ex)
            {
                resetResult = false;
            }

            return resetResult;
        }
        #endregion
    }
}