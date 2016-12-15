//-----------------------------------------------------------------------
// <copyright file="GlobalConfig.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Common
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;

    /// <summary>
    /// Global config
    /// </summary>
    public class GlobalConfig
    {
        #region Fileds
        /// <summary>
        /// Dictionary of global settings.
        /// </summary>
        public static readonly Dictionary<string, string> GlobalPars;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes static members of the GlobalConfig class.
        /// </summary>
        static GlobalConfig()
        {
            GlobalPars = new Dictionary<string, string>();
            NameValueCollection settings = ConfigurationManager.AppSettings;
            foreach (string key in settings.AllKeys)
            {
                GlobalPars.Add(key, settings[key]);
            }
        }
        #endregion
    }
}