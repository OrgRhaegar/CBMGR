//-----------------------------------------------------------------------
// <copyright file="IDBHelper.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Interface
{
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Interface of DB helper
    /// </summary>
    public interface IDBHelper
    {
        /// <summary>
        /// Test SQL connecion.
        /// </summary>
        /// <returns>Test result. Empty for good.</returns>
        string TestConnection();

        /// <summary>
        /// Execute none sql query.
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parameter">slq parameter</param>
        /// <returns>Query result</returns>
        int ExecuteNoneQuery(string sql, SqlParameter parameter);

        /// <summary>
        /// Execute none sql query.
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parameters">slq parameter array. Null fro default.</param>
        /// <returns>Query result</returns>
        int ExecuteNoneQuery(string sql, SqlParameter[] parameters = null);

        /// <summary>
        /// Get data table
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parameter">sql parameter</param>
        /// <returns>Result data table</returns>
        DataTable GetDataTable(string sql, SqlParameter parameter);

        /// <summary>
        /// Get data table
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parameters">sql parameter array. Null for default.</param>
        /// <returns>Result data table</returns>
        DataTable GetDataTable(string sql, SqlParameter[] parameters = null);

        /// <summary>
        /// Get data set
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parameter">sql parameter</param>
        /// <returns>Result data set</returns>
        DataSet GetDataSet(string sql, SqlParameter parameter);

        /// <summary>
        /// Get data set
        /// </summary>
        /// <param name="sql">sql command</param>
        /// <param name="parameters">Sql parameter array. Null for default.</param>
        /// <returns>Result data set</returns>
        DataSet GetDataSet(string sql, SqlParameter[] parameters = null);
    }
}