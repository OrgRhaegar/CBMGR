//-----------------------------------------------------------------------
// <copyright file="IUserAccount.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Interface
{
    /// <summary>
    /// Interface of user
    /// </summary>
    public interface IUserAccount
    {
        /// <summary>
        /// Sign up for a new user.
        /// </summary>
        /// <param name="appKey">app key</param>
        /// <param name="loginName">login name</param>
        /// <param name="password">login password</param>
        /// <returns>login result</returns>
        ActionResult CreateNewUser(string appKey, string loginName, string password);

        /// <summary>
        /// Sign in as a exist user.
        /// </summary>
        /// <param name="appKey">app key</param>
        /// <param name="loginName">login name</param>
        /// <param name="password">login password</param>
        /// <returns>login result</returns>
        ActionResult UserLogin(string appKey, string loginName, string password);

        /// <summary>
        /// Login from we chat
        /// </summary>
        /// <param name="appKey">app key</param>
        /// <param name="weChatId">we chat id</param>
        /// <returns>login result</returns>
        ActionResult WeChatLogin(string appKey, string weChatId);

        /// <summary>
        /// Update user's password
        /// </summary>
        /// <param name="token">login token</param>
        /// <param name="userId">user id</param>
        /// <param name="password">old password</param>
        /// <param name="newPwd">new password</param>
        /// <returns>update result</returns>
        ActionResult UpdatePassword(string token, string userId, string password, string newPwd);

        /// <summary>
        /// Reset user's pasword
        /// </summary>
        /// <param name="appKey">app key</param>
        /// <param name="loginName">login name</param>
        /// <param name="email">email address</param>
        /// <returns>update result</returns>
        ActionResult ResertPassowrd(string appKey, string loginName, string email);
    }
}