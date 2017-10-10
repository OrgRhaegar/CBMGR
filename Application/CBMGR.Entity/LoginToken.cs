//-----------------------------------------------------------------------
// <copyright file="LoginToken.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CBMGR.Common;
    using CBMGR.Interface;
    using Microsoft.Practices.Unity;
    using Newtonsoft.Json;

    /// <summary>
    /// Login token
    /// </summary>
    public class LoginToken
    {
        /// <summary>
        /// Initializes a new instance of the LoginToken class.
        /// <param name="userId">User id</param>
        /// <param name="initType">Initialization type of token string.</param>
        /// </summary>
        public LoginToken(string userId)
        {
            this.userId = userId;
            this.createDate = DateTime.Now;
        }

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
    }
}