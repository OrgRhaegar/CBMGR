//-----------------------------------------------------------------------
// <copyright file="UserAccount.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Entity
{
    #region using
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using CBMGR.Common;
    using CBMGR.Interface;
    using Unity;
    #endregion

    /// <summary>
    /// Entity of user
    /// </summary>
    public class UserAccount : IUserAccount
    {
        #region Members of IUser
        /// <summary>
        /// Sign up for a new user.
        /// </summary>
        /// <param name="appKey">app key</param>
        /// <param name="loginName">login name</param>
        /// <param name="password">login password</param>
        /// <returns>login result</returns>
        public ActionResult CreateNewUser(string appKey, string loginName, string password)
        {
            ActionResult result = new ActionResult();
            IAppKey iKey = GlobalConfig.IocContainer.Resolve<IAppKey>();
            if (iKey.ValidateAppKey(appKey))
            {
                if (this.CheckUserNameExist(loginName))
                {
                    result.Message = "LoginName already exits.";
                }
                else
                {
                    string sql = "EXEC CM_SP_CreateNewUser @LOGIN_NAME=@NAME,@LOGIN_PWD=@PWD";
                    SqlParameter[] parArray = new SqlParameter[2];
                    parArray[0] = new SqlParameter("@NAME", loginName);
                    parArray[1] = new SqlParameter("@PWD", password);
                    IDBHelper dbi = GlobalConfig.IocContainer.Resolve<IDBHelper>();
                    DataTable newUser = dbi.GetDataTable(sql, parArray);
                    result.Result = (int)newUser.Rows[0]["RESULT"] == 1;
                    result.Message = newUser.Rows[0]["MSG"].ToString();
                }
            }
            else
            {
                result.Message = "App key not valided.";
            }

            return result;
        }

        /// <summary>
        /// Sign in as a exist user.
        /// </summary>
        /// <param name="appKey">app key</param>
        /// <param name="loginName">login name</param>
        /// <param name="password">login password</param>
        /// <returns>login result</returns>
        public ActionResult UserLogin(string appKey, string loginName, string password = null)
        {
            ActionResult result = new ActionResult();
            IAppKey iKey = GlobalConfig.IocContainer.Resolve<IAppKey>();
            if (iKey.ValidateAppKey(appKey))
            {
                string userId = string.Empty;
                if (string.IsNullOrEmpty(password))
                {
                    //// login from wechat
                    userId = this.GetUserId(loginName);
                }
                else
                {
                    //// common login
                    userId = this.GetUserId(loginName, password);
                }

                if (string.IsNullOrEmpty(userId))
                {
                    result.Message = "Login failed.";
                }
                else
                {
                    LoginToken token = new LoginToken(userId);
                    result.ResultValue = token.GetToken();
                    result.Result = true;
                }
            }
            else
            {
                result.Message = "App key not valided.";
            }

            return result;
        }

        /// <summary>
        /// Update user's password
        /// </summary>
        /// <param name="token">login token</param>
        /// <param name="userId">user id</param>
        /// <param name="password">old password</param>
        /// <param name="newPwd">new password</param>
        /// <returns>update result</returns>
        public ActionResult UpdatePassword(string token, string userId, string password, string newPwd)
        {
            throw new Exception();
        }

        /// <summary>
        /// Reset user's pasword
        /// </summary>
        /// <param name="appKey">app key</param>
        /// <param name="loginName">login name</param>
        /// <param name="email">email address</param>
        /// <returns>update result</returns>
        public ActionResult ResertPassowrd(string appKey, string loginName, string email)
        {
            throw new Exception();
        }
        #endregion

        #region private method
        /// <summary>
        /// Check wether the login name is exist.
        /// </summary>
        /// <param name="loginName">user login name</param>
        /// <returns>check result</returns>
        private bool CheckUserNameExist(string loginName)
        {
            string userId = this.GetUserId(loginName, null);
            return string.IsNullOrEmpty(userId);
        }

        /// <summary>
        /// Get user id by login name
        /// </summary>
        /// <param name="loginName">user login name</param>
        /// <param name="password">user login password</param>
        /// <returns>user id</returns>
        private string GetUserId(string loginName, string password)
        {
            string userId = string.Empty;
            string sql = "SELECT USER_ID FROM CM_UserLogin WHERE USER_LOGIN_NAME=@NAME";
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@NAME", "loginName"));
            if (!string.IsNullOrEmpty(password))
            {
                ISecurity sec = GlobalConfig.IocContainer.Resolve<ISecurity>();
                password = sec.GetMD5String(password);
                sql += " AND USER_LOGIN_PWD=@PWD";
                pars.Add(new SqlParameter("@PWD", "password"));
            }

            IDBHelper dbi = GlobalConfig.IocContainer.Resolve<IDBHelper>();
            DataTable user = dbi.GetDataTable(sql, pars.ToArray());
            if (user.Rows.Count > 0)
            {
                userId = user.Rows[0]["USER_ID"].ToString();
            }

            return userId;
        }

        /// <summary>
        /// Get user id by wechat id
        /// </summary>
        /// <param name="wechatId">wechat id</param>
        /// <returns>user id</returns>
        private string GetUserId(string wechatId)
        {
            string userId = string.Empty;
            string sql = "SELECT USER_ID FROM CM_UserLogin WHERE WECHART_ID=@ID AND WECHART_AUTO_LOGIN=1";
            SqlParameter par = new SqlParameter("@ID", "wechatId");
            IDBHelper dbi = GlobalConfig.IocContainer.Resolve<IDBHelper>();
            DataTable user = dbi.GetDataTable(sql, par);
            if (user.Rows.Count > 0)
            {
                userId = user.Rows[0]["USER_ID"].ToString();
            }

            return userId;
        }
        #endregion
    }
}