using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using CBMGR.Interface;
using CBMGR.Entity;
using CBMGR.Common;
using Newtonsoft.Json;

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
                VerifyToken(resultJosn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }

        private static void VerifyToken(string jStr)
        {
            ActionResult result =  JsonConvert.DeserializeObject<ActionResult>(jStr);
            bool verify = LoginToken.VerifyToken(result.ResultValue.ToString());
            Console.WriteLine("Verify result: {0}", verify);
        }
    }
}