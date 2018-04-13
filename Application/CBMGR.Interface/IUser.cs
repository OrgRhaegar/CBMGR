﻿//-----------------------------------------------------------------------
// <copyright file="IUser.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface of user
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Sign up for a new user.
        /// </summary>
        /// <param name="loginName">login name</param>
        /// <param name="password">login password</param>
        /// <returns>user guid</returns>
        ActionResult CreateNewUser(string loginName, string password);

        /// <summary>
        /// Sign in as a exist user.
        /// </summary>
        /// <param name="loginName">login name</param>
        /// <param name="password">login password</param>
        /// <returns>user guid</returns>
        ActionResult UserLogin(string loginName, string password);

        /// <summary>
        /// Get club list of a user.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Clubs that this user belongs to.</returns>
        ActionResult GetClubListByUserId(string userId);
    }
}