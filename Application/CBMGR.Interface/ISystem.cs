﻿//-----------------------------------------------------------------------
// <copyright file="ISystem.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Interface
{
    /// <summary>
    /// Interface of system
    /// </summary>
    public interface ISystem
    {
        /// <summary>
        /// Request a new app key.
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns>result of action</returns>
        ActionResult RequestAppKey(string email);

        /// <summary>
        /// Get app key by email address.
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns>result of action</returns>
        ActionResult GetAppKeyByEmail(string email);

        /// <summary>
        /// Reset the app key.
        /// </summary>
        /// <param name="email">email address.</param>
        /// <returns>result of action</returns>
        ActionResult RestAppKey(string email);
    }
}