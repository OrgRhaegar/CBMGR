//-----------------------------------------------------------------------
// <copyright file="Login.aspx.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.WebModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using CBMGR.Interface;
    using CBMGR.Common;

    /// <summary>
    /// Login page
    /// </summary>
    public partial class Login : Page
    {
        #region Event
        /// <summary>
        /// Page load event
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Button Login click
        /// </summary>
        /// <param name="sender">even sender</param>
        /// <param name="e">event parameter</param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Button Register click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event parameter</param>
        protected void btnRegist_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text.Trim();
            string pwd = this.txtPwd.Text.Trim();
        }
        #endregion
    }
}