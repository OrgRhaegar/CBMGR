//-----------------------------------------------------------------------
// <copyright file="UserAccount.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Entity
{
    #region using
    using System;
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
                LogQueue.AddToLogQueue(ex);
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
        public ActionResult UserLogin(string appKey, string loginName, string password)
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
                    string userId = id.ToString();
                }
                else
                {
                    result.Result = false;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                LogQueue.AddToLogQueue(ex);
            }

            return result;
        }

        /// <summary>
        /// Login from we chat
        /// </summary>
        /// <param name="appKey">app key</param>
        /// <param name="weChatId">we chat id</param>
        /// <returns>login result</returns>
        public ActionResult WeChatLogin(string appKey, string weChatId)
        {
            throw new Exception();
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
    }
}