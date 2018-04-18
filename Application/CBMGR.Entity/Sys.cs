﻿//-----------------------------------------------------------------------
// <copyright file="Sys.cs" company="RGS">
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
    public class Sys : ISystem
    {
        #region members of ISystem
        /// <summary>
        /// Require a new app key
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns>action result</returns>
        public ActionResult RequestAppKey(string email)
        {
            ActionResult resutl = new ActionResult();
            bool verify = this.ValidateEmailAddress(email);
            if (!verify)
            {
                resutl.Result = false;
                resutl.Message = "Mail address is illegal.";
            }
            else
            {
                try
                {
                    string appKey = this.CreateNewKey();
                    ISystem iSys = GlobalConfig.IocContainer.Resolve<ISystem>();
                    string sql = "EXEC CM_SP_CreateAppKey @EMAIL=@mail, @KEY_VALUE=@key";
                    SqlParameter[] parArray = new SqlParameter[2];
                    parArray[0] = new SqlParameter("@mail", email);
                    parArray[1] = new SqlParameter("@key", appKey);
                    IDBHelper dbi = GlobalConfig.IocContainer.Resolve<IDBHelper>();
                    DataTable newKey = dbi.GetDataTable(sql, parArray);
                    if (((int)newKey.Rows[0][0]) == 1)
                    {
                        resutl.Result = true;
                        resutl.ResultValue = appKey;
                        this.SendKeyMail(email, appKey);
                    }
                    else
                    {
                        resutl.Result = false;
                        resutl.Message = newKey.Rows[0][1].ToString();
                    }
                }
                catch
                {
                    resutl.Result = false;
                    resutl.Message = "Failed to request a new app key.";
                }
            }

            return resutl;
        }
        #endregion

        #region private method
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
        /// Create a new app key
        /// </summary>
        /// <returns>new key</returns>
        private string CreateNewKey()
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
        /// Send app key by email.
        /// </summary>
        /// <param name="email">email address</param>
        /// <param name="key">app key</param>
        private void SendKeyMail(string email, string key)
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
        #endregion
    }
}