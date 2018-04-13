﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Microsoft.Practices.Unity.Configuration;
using CBMGR.Interface;
using CBMGR.Common;

namespace UnityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = "ioc.config";

            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection("unity");

            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration(section);

            try
            {
                IUser iUSer = container.Resolve<IUser>();
                ActionResult login = iUSer.UserLogin("admin", "admin");
                string resultJosn = login.ToJSON();
                Console.WriteLine(resultJosn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}