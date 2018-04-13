//-----------------------------------------------------------------------
// <copyright file="Login.aspx.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.WebModule
{
    using System;
    using System.Web.UI;
    using CBMGR.Common;
    using CBMGR.Interface;
    using Unity;

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
            IUser user = GlobalConfig.IocContainer.Resolve<IUser>();
            ActionResult login = user.UserLogin(userName, pwd);
            this.lbUserId.Text = login.Result.ToString();
        }
        #endregion
    }
}