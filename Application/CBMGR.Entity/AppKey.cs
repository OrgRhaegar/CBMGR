//-----------------------------------------------------------------------
// <copyright file="AppKey.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Entity
{
    #region using
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using CBMGR.Common;
    using CBMGR.Interface;
    using Unity;
    #endregion

    /// <summary>
    /// Entity of Sys
    /// </summary>
    public class AppKey : IAppKey
    {
        #region Field
        /// <summary>
        /// Key id
        /// </summary>
        private int keyId;

        /// <summary>
        /// App Key
        /// </summary>
        private string keyValue;

        /// <summary>
        /// Email address.
        /// </summary>
        private string email;

        /// <summary>
        /// Create date.
        /// </summary>
        private DateTime createDate;

        /// <summary>
        /// Last required date.
        /// </summary>
        private DateTime lastRequired;

        /// <summary>
        /// Key status.
        /// </summary>
        private bool enabled;

        /// <summary>
        /// Key comment.
        /// </summary>
        private string commetn;
        #endregion

        /// <summary>
        /// Enum of initialize method.
        /// </summary>
        private enum InitializeKeyFrom
        {
            /// <summary>
            /// Initialize key data from email address.
            /// </summary>
            EMAIL,
            
            /// <summary>
            /// Initialize key data from key value.
            /// </summary>
            KEY_VALUE
        }

        #region Members of ISystem
        /// <summary>
        /// Require a new app key
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns>action result</returns>
        public ActionResult RequestAppKey(string email)
        {
            ActionResult result = new ActionResult();
            bool verify = this.ValidateEmailAddress(email);
            if (!verify)
            {
                result.Message = "Mail address is illegal.";
            }
            else
            {
                this.email = email;
                this.Initialize(InitializeKeyFrom.EMAIL);
                if (!string.IsNullOrEmpty(this.keyValue))
                {
                    result.Message = "Email address is exists in key list.";
                }
                else
                {
                    string appKey = this.CreateNewKeyString();
                    bool create = this.Create(appKey);
                    if (create)
                    {
                        result.Result = true;
                        this.SendKeyByMail(email, appKey);
                    }
                    else
                    {
                        result.Message = "Failed to create app key.";
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Get app key by email address.
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns>result of action</returns>
        public ActionResult GetAppKeyByEmail(string email)
        {
            ActionResult result = new ActionResult();
            bool verify = this.ValidateEmailAddress(email);
            if (!verify)
            {
                result.Message = "Mail address is illegal.";
            }
            else
            {
                this.email = email;
                if (this.Initialize(InitializeKeyFrom.EMAIL))
                {
                    TimeSpan span = DateTime.Now - this.lastRequired;
                    if (span.Minutes > 10)
                    {
                        this.SendKeyByMail(this.email, this.keyValue);
                        result.Result = true;
                    }
                    else
                    {
                        result.Message = "Request app key once every ten minutes.";
                    }
                }
                else
                {
                    result.Message = "Didn't find eamil in key list.";
                }
            }

            return result;
        }

        /// <summary>
        /// Reset the app key.
        /// </summary>
        /// <param name="email">email address.</param>
        /// <returns>result of action</returns>
        public ActionResult ResetAppKey(string email)
        {
            ActionResult result = new ActionResult();
            bool verify = this.ValidateEmailAddress(email);
            if (!verify)
            {
                result.Message = "Mail address is illegal.";
            }
            else
            {
                this.email = email;
                if (this.Initialize(InitializeKeyFrom.EMAIL))
                {
                    TimeSpan span = DateTime.Now - this.lastRequired;
                    if (span.Minutes > 10)
                    {
                        this.keyValue = this.CreateNewKeyString();
                        this.Update();
                        this.SendKeyByMail(this.email, this.keyValue);
                        result.Result = true;
                    }
                    else
                    {
                        result.Message = "Request app key once every ten minutes.";
                    }
                }
                else
                {
                    result.Message = "Didn't find eamil in key list.";
                }
            }

            return result;
        }

        /// <summary>
        /// Validate key value
        /// </summary>
        /// <param name="key">app key</param>
        /// <returns>validata result</returns>
        public bool ValidateAppKey(string key)
        {
            this.keyValue = key;
            this.enabled = false;
            this.Initialize(InitializeKeyFrom.KEY_VALUE);
            return this.enabled;
        }
        #endregion

        #region private method
        /// <summary>
        /// Create a new app key
        /// </summary>
        /// <returns>new key</returns>
        private string CreateNewKeyString()
        {
            string keyChar = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] keyArray = keyChar.ToArray<char>();
            int charLength = keyArray.Length;
            Random ran = new Random(DateTime.Now.Millisecond);
            StringBuilder keyBuider = new StringBuilder();
            int index = -1;
            for (int i = 0; i < 32; i++)
            {
                index = ran.Next(charLength);
                keyBuider.Append(keyArray[index]);
            }

            string newKey = keyBuider.ToString();
            return newKey;
        }

        /// <summary>
        /// Verify the mail address.
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns>validate result</returns>
        private bool ValidateEmailAddress(string email)
        {
            Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            bool verify = r.IsMatch(email);
            return verify;
        }

        /// <summary>
        /// Send app key by email.
        /// </summary>
        /// <param name="email">email address</param>
        /// <param name="key">app key</param>
        private void SendKeyByMail(string email, string key)
        {
            IMail imail = GlobalConfig.IocContainer.Resolve<IMail>();
            string subject = "App Key";
            StringBuilder sbMailBody = new StringBuilder();
            sbMailBody.Append("<div>The app key you required from CBMGR:</div>");
            sbMailBody.Append(string.Format("<div><b>{0}</b></div>", key));
            sbMailBody.Append("<div>Please save it safely.</div>");
            string mailBody = sbMailBody.ToString();
            imail.SendMail(new string[] { email }, null, subject, mailBody);
        }

        /// <summary>
        /// Init key data from database;
        /// </summary>
        /// <param name="from">Initialize from</param>
        /// <returns>Wether find key data in database</returns>
        private bool Initialize(InitializeKeyFrom from)
        {
            bool init = false;
            string sql = $"SELECT KEY_ID,KEY_VALUE,EMAIL,CREATE_DATE,LAST_REQUIRED,ENABLED,COMMENT FROM CM_Sys_AppKey WHERE {from}=@PAR";
            IDBHelper dbi = GlobalConfig.IocContainer.Resolve<IDBHelper>();
            string parValue = from == InitializeKeyFrom.EMAIL ? this.email : this.keyValue;
            SqlParameter par = new SqlParameter("@PAR", parValue);
            DataTable table = dbi.GetDataTable(sql, par);
            if (table != null && table.Rows.Count > 0)
            {
                DataRow keyRow = table.Rows[0];
                this.keyId = (int)keyRow["KEY_ID"];
                this.keyValue = keyRow["KEY_VALUE"].ToString();
                this.email = keyRow["EMAIL"].ToString();
                this.createDate = (DateTime)keyRow["CREATE_DATE"];
                this.lastRequired = (DateTime)keyRow["LAST_REQUIRED"];
                this.enabled = (bool)keyRow["ENABLED"];
                this.commetn = keyRow["COMMENT"].ToString();
                init = true;
            }

            return init;
        }

        /// <summary>
        /// Insert new key into database;
        /// </summary>
        /// <param name="keyValue">Key value</param>
        /// <returns>create result</returns>
        private bool Create(string keyValue)
        {
            bool create = false;
            IAppKey iSys = GlobalConfig.IocContainer.Resolve<IAppKey>();
            string sql = "EXEC CM_SP_CreateAppKey @EMAIL=@mail, @KEY_VALUE=@key";
            SqlParameter[] parArray = new SqlParameter[2];
            parArray[0] = new SqlParameter("@mail", this.email);
            parArray[1] = new SqlParameter("@key", keyValue);
            IDBHelper dbi = GlobalConfig.IocContainer.Resolve<IDBHelper>();
            DataTable newKey = dbi.GetDataTable(sql, parArray);
            if (((int)newKey.Rows[0][0]) == 1)
            {
                create = true;
            }

            return create;
        }

        /// <summary>
        /// Update app key data to database.
        /// </summary>
        private void Update()
        {
            string sql = "UPDATE CM_Sys_AppKey SET KEY_VALUE=@KEY,LAST_REQUIRED=@LAST,ENABLED=@ENABLED,COMMENT=@COMMENT WHERE EMAIL=@EMAIL";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@KEY", this.keyValue),
                new SqlParameter("@LAST", DateTime.Now),
                new SqlParameter("@ENABLED", this.enabled),
                new SqlParameter("@COMMENT", this.commetn),
                new SqlParameter("@EMAIL", this.email)
            };
            IDBHelper dbi = GlobalConfig.IocContainer.Resolve<IDBHelper>();
            dbi.ExecuteNoneQuery(sql, pars);
        }
        #endregion
    }
}