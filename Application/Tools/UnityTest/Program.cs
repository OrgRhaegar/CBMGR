using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBMGR.Interface;
using CBMGR.Entity;
using Microsoft.Practices.Unity.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Unity;

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
                UpdateToken(resultJosn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }

        private static void VerifyToken(string jStr)
        {
            JObject result =  JsonConvert.DeserializeObject<JObject>(jStr);
            string token = result["ResultValue"].ToString();
            bool verify = LoginToken.VerifyToken(token);
            Console.WriteLine("Verify result: {0}", verify);
        }

        private static void UpdateToken(string jStr)
        {
            JObject result = JsonConvert.DeserializeObject<JObject>(jStr);
            string token = result["ResultValue"].ToString();
            token = LoginToken.UpdateToken(token).ToJSON();
            Console.WriteLine(token);
        }
    }
}