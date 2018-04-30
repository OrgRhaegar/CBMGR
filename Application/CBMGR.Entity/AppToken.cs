//-----------------------------------------------------------------------
// <copyright file="AppToken.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Entity
{
    #region using
    using System;
    using CBMGR.Common;
    using CBMGR.Interface;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Unity;
    #endregion

    /// <summary>
    /// Login token
    /// </summary>
    public class AppToken : IAppToken
    {
        #region Property
        /// <summary>
        /// Gets or sets a value of User id.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets a value of expired date.
        /// </summary>
        public DateTime ExpireDate { get; set; }
        #endregion

        #region Member of IAppToken
        /// <summary>
        /// Create a new token by user id.
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>new token</returns>
        public string CreateNewToken(string userId)
        {
            this.UserId = userId;
            this.ExpireDate = DateTime.Now.AddMinutes(10);
            string token = JsonConvert.SerializeObject(this);
            ISecurity iSec = GlobalConfig.IocContainer.Resolve<ISecurity>();
            token = iSec.GetAesEncryptedString(token);
            return token;
        }

        /// <summary>
        /// Check the token wether is verified
        /// Update the token expire data if it is verified.
        /// </summary>
        /// <param name="tokenStr">app token</param>
        /// <returns>new token</returns>
        public ActionResult VerifyAppToken(string tokenStr)
        {
            ActionResult result = new ActionResult();
            try
            {
                this.Initialize(tokenStr);
                if (this.ExpireDate < DateTime.Now)
                {
                    result.Message = "Token has been expired.";
                }
                else
                {
                    result.ResultValue = this;
                    result.Result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        #endregion

        #region private method
        /// <summary>
        /// Initialize token data from encrypted token string.
        /// </summary>
        /// <param name="tokenStr">token string</param>
        private void Initialize(string tokenStr)
        {
            ISecurity iSec = GlobalConfig.IocContainer.Resolve<ISecurity>();
            tokenStr = iSec.GetAesDecryptedString(tokenStr);
            JObject oToken = JObject.Parse(tokenStr);
            this.UserId = oToken["UserId"].ToString();
            DateTime expDate = Convert.ToDateTime(oToken["ExpireDate"]);
            this.ExpireDate = expDate.AddMinutes(10);
        }

        /// <summary>
        /// Get encrypted token string.
        /// </summary>
        /// <returns>login token</returns>
        private string GetToken()
        {
            string tokenStr = string.Empty;
            if (!string.IsNullOrEmpty(this.UserId))
            {
                tokenStr = JsonConvert.SerializeObject(this);
                IUnityContainer container = GlobalConfig.IocContainer;
                ISecurity iSecurity = container.Resolve<ISecurity>();
                tokenStr = iSecurity.GetAesEncryptedString(tokenStr);
            }

            return tokenStr;
        }
        #endregion
    }
}