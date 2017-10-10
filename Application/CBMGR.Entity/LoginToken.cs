//-----------------------------------------------------------------------
// <copyright file="LoginToken.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Entity
{
    using System;
    using CBMGR.Common;
    using CBMGR.Interface;
    using Microsoft.Practices.Unity;
    using Newtonsoft.Json;

    /// <summary>
    /// Login token
    /// </summary>
    public class LoginToken
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the LoginToken class.
        /// <param name="userId">User id</param>
        /// <param name="initType">Initialization type of token string.</param>
        /// </summary>
        public LoginToken(string userId)
        {
            this.userId = userId;
            this.createDate = DateTime.Now;
            this.updateCount = 0;
        }
        #endregion

        #region Property
        /// <summary>
        /// User id.
        /// </summary>
        private string userId;

        /// <summary>
        /// Gets a value of user id.
        /// </summary>
        public string UserId
        {
            get
            {
                return this.userId;
            }
        }

        /// <summary>
        /// Date of this token created.
        /// </summary>
        private DateTime createDate;

        /// <summary>
        /// Gets a value of create date.
        /// </summary>
        public DateTime CreateDate
        {
            get
            {
                return this.createDate;
            }
        }

        /// <summary>
        /// Gets a value wether this token is valid.
        /// </summary>
        public bool IsValid
        {
            get
            {
                int sec = Convert.ToInt32(GlobalConfig.GlobalPars["Expire"]);
                DateTime expDate = this.createDate.AddSeconds(sec);
                return expDate > DateTime.Now;
            }
        }

        /// <summary>
        /// Count of this token updating time.
        /// </summary>
        private int updateCount;

        /// <summary>
        /// Gets a value of update count.
        /// </summary>
        public int UpdateCount
        {
            get
            {
                return this.updateCount;
            }
        }
        #endregion

        #region Pulbic method
        /// <summary>
        /// Get json string of this entity
        /// </summary>
        /// <returns>Json string of this entity.</returns>
        public string ToJSON()
        {
            string jsonStr = JsonConvert.SerializeObject(this);
            return jsonStr;
        }

        /// <summary>
        /// Get encrypted token string.
        /// </summary>
        /// <returns></returns>
        public string GetToken()
        {
            if (!this.IsValid)
            {
                return string.Empty;
            }
            else
            {
                string token = this.ToJSON();
                IUnityContainer container = GlobalConfig.IocContainer;
                ISecurity iSecurity = container.Resolve<ISecurity>();
                token = iSecurity.GetAesEncryptedString(token);
                return token;
            }
        }
        #endregion

        #region Static method
        /// <summary>
        /// Verify token string.
        /// </summary>
        /// <param name="tokenStr">Encrypted token string.</param>
        /// <returns>Verify result.</returns>
        public static bool VerifyToken(string tokenStr)
        {
            bool verify = false;
            try
            {
                IUnityContainer container = GlobalConfig.IocContainer;
                ISecurity iSecurity = container.Resolve<ISecurity>();
                tokenStr = iSecurity.GetAesDecryptedString(tokenStr);
                LoginToken token = JsonConvert.DeserializeObject<LoginToken>(tokenStr);
                verify = token.IsValid;
            }
            catch (Exception ex)
            {
                verify = false;
            }

            return verify;
        }

        /// <summary>
        /// Prolong token's period of validity.
        /// Number of updating times must less then 10.
        /// </summary>
        /// <param name="totokenStrken">Original token.</param>
        /// <returns>Update result.</returns>
        public static ActionResult UpdateToken(string tokenStr)
        {
            ActionResult result = new ActionResult();
            result.Result = false;
            try
            {
                IUnityContainer container = GlobalConfig.IocContainer;
                ISecurity iSecurity = container.Resolve<ISecurity>();
                tokenStr = iSecurity.GetAesDecryptedString(tokenStr);
                LoginToken token = JsonConvert.DeserializeObject<LoginToken>(tokenStr);
                if (string.IsNullOrEmpty(token.UserId))
                {
                    result.Message = "Validation of token failed.";
                }
                else if (token.UpdateCount > 9)
                {
                    result.Message = "This token can not be updated anymore.";
                }
                else
                {
                    result.Result = true;
                    token.createDate = DateTime.Now;
                    token.updateCount++;
                    result.ResultValue = token.GetToken();
                }
            }
            catch (Exception ex)
            {
                result.Message = "Validation of token failed.";
            }

            return result;
        }
        #endregion
    }
}