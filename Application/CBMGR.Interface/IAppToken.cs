//-----------------------------------------------------------------------
// <copyright file="IAppToken.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Interface
{
    #region using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Interface of app token
    /// </summary>
    public interface IAppToken
    {
        /// <summary>
        /// Create a new token by user id.
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>new token</returns>
        string CreateNewToken(string userId);

        /// <summary>
        /// Check the token wether is verified
        /// Update the token expire data if it is verified.
        /// </summary>
        /// <param name="tokenStr">app token</param>
        /// <returns>new token</returns>
        ActionResult VerifyAppToken(string tokenStr);
    }
}