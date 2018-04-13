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
    using Unity;

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
        public ActionResult CreateNewUser(string loginName, string password)
        {
            ActionResult result = new ActionResult();
            try
            {
                ISecurity sec = GlobalConfig.IocContainer.Resolve<ISecurity>();
                password = sec.GetMD5String(password);
                string sql = "EXEC CM_SP_CreateNewUser @LOGIN_NAME=@NAME,@LOGIN_PWD=@PWD";
                SqlParameter[] parArray = new SqlParameter[2];
                parArray[0] = new SqlParameter("@NAME", loginName);
                parArray[1] = new SqlParameter("@PWD", password);
                IDBHelper dbi = GlobalConfig.IocContainer.Resolve<IDBHelper>();
                DataTable newUser = dbi.GetDataTable(sql, parArray);
                result.ResultValue = newUser;
                result.Result = (int)newUser.Rows[0]["RESULT"] == 1;
                result.Message = newUser.Rows[0]["MSG"].ToString();
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Ex = ex;
                LogQueue.AddToLogQueue(ex);
            }

            return result;
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
        public ActionResult UserLogin(string loginName, string password)
        {
            ActionResult result = new ActionResult();
            try
            {
                ISecurity sec = GlobalConfig.IocContainer.Resolve<ISecurity>();
                password = sec.GetMD5String(password);
                string sql = "SELECT USER_ID FROM CM_UserLogin WHERE USER_LOGIN_NAME=@NAME AND USER_LOGIN_PWD=@PWD AND ENABLED=1";
                SqlParameter[] parArray = new SqlParameter[2];
                parArray[0] = new SqlParameter("@NAME", loginName);
                parArray[1] = new SqlParameter("@PWD", password);
                IDBHelper dbi = GlobalConfig.IocContainer.Resolve<IDBHelper>();
                object id = dbi.ExecuteScalar(sql, parArray);
                if (id != null)
                {
                    result.ResultValue = id.ToString();
                }
                else
                {
                    result.Result = false;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Ex = ex;
                LogQueue.AddToLogQueue(ex);
            }

            return result;
        }
        #endregion
    }
}