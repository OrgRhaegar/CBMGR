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
    using Microsoft.Practices.Unity.Configuration;
    using Unity;

    /// <summary>
    /// Global config
    /// </summary>
    public class GlobalConfig
    {
        #region Fileds
        /// <summary>
        /// Dictionary of global settings
        /// </summary>
        private static Dictionary<string, string> globalPars;
        #endregion

        #region Property
        /// <summary>
        /// Gets dictionary of global settings
        /// </summary>
        public static Dictionary<string, string> GlobalPars
        {
            get
            {
                if (globalPars == null)
                {
                    globalPars = new Dictionary<string, string>();
                    NameValueCollection settings = ConfigurationManager.AppSettings;
                    foreach (string key in settings.AllKeys)
                    {
                        globalPars.Add(key, settings[key]);
                    }
                }

                return globalPars;
            }
        }

        /// <summary>
        /// Gets IOC container
        /// </summary>
        public static IUnityContainer IocContainer
        {
            get
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = GlobalPars["IOCMappingFile"];
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection("unity");
                IUnityContainer iocContainer = new UnityContainer();
                iocContainer.LoadConfiguration(section);
                return iocContainer;
            }
        }
        #endregion
    }
}