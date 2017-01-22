//-----------------------------------------------------------------------
// <copyright file="User.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Entity
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using CBMGR.Common;
    using CBMGR.Interface;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// Entity of user
    /// </summary>
    public class User : IUser
    {
        #region Members of IUser
        /// <summary>
        /// Sign up for a new user.
        /// </summary>
        /// <param name="loginName">login name</param>
        /// <param name="password">login password</param>
        /// <returns>user guid</returns>
        public string CreateNewUser(string loginName, string password)
        {
            string userId = string.Empty;
            try
            {
                ISecurity sec = GlobalConfig.IocContainer.Resolve<ISecurity>();
                password = sec.GetMD5String(password);
                string sql = "EXEC CBMG_SP_CreateNewUser @LOGIN_NAME=@NAME,@LOGIN_PWD=@PWD";
                SqlParameter[] parArray = new SqlParameter[2];
                parArray[0] = new SqlParameter("@NAME", loginName);
                parArray[1] = new SqlParameter("@PWD", password);
                Dbi dbi = new Dbi();
                DataTable result = dbi.GetDataTable(sql, parArray);
                userId = result.Rows[0]["MSG"].ToString();
            }
            catch (Exception ex)
            {
                LogQueue.AddToLogQueue(ex);
            }

            return userId;
        }
        
        /// <summary>
        /// Sign in as a exist user.
        /// </summary>
        /// <param name="loginName">login name</param>
        /// <param name="password">login password</param>
        /// <returns>user guid</returns>
        public DataTable GetClubList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get club list of current user.
        /// </summary>
        /// <returns>Club list</returns>
        public string UserLogin(string loginName, string password)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}